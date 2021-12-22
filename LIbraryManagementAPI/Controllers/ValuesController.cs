using LIbraryManagementAPI.EFModels;
using LIbraryManagementAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        [Route("getrecordsbyuserid")] // GET RECORDS BY USER ID
        public JsonResult GetRecordByUserId(int userId)
        {
            try
            {
                var context = new LibraryContext();
                var recordList = context.Records.Where(r => r.userId == userId).ToList();
                return new JsonResult(recordList);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        [HttpGet]
        [Route("getrecord")] // GET RECORD BY ID
        public JsonResult GetRecordById(int id)
        {
            try
            {
                var context = new LibraryContext();
                Record record = context.Records.Find(id);
                return new JsonResult(record);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPost]
        [Route("changerecordstatus")] // EDIT RECORD STATUS
        public JsonResult EditRecordStatus([FromBody] RecordModel recordModel)
        {
            try
            {
                var context = new LibraryContext();

                // set borrowing record attributes, 
                Record record = context.Records.Find(recordModel.recId);
                record.returnDate = recordModel.returnDate;
                record.status = recordModel.status;

                context.SaveChanges();

                return new JsonResult(record);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        
        [HttpPost]
        [Route("editrecord")] // EDIT RECORD
        public JsonResult EditRecord([FromBody] RecordModel recordModel)
        {
            try
            {
                var context = new LibraryContext();

                // set borrowing record attributes, 
                Record record = context.Records.Find(recordModel.recId);
                record.bookId = recordModel.bookId;
                record.userId = recordModel.userId;
                record.borrowDate = recordModel.borrowDate;
                record.returnDate = recordModel.returnDate;
                record.returnDueDate = recordModel.returnDueDate;
                record.status = recordModel.status;

                context.SaveChanges();

                return new JsonResult(record);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }

        }

        [HttpPost]
        [Route("addrecord")] // INSERT RECORD
        public JsonResult AddRecord([FromBody] RecordModel recordModel)
        {
            try
            {
                var context = new LibraryContext();

                // set borrowing record attributes, 
                Record record = new Record();
                record.bookId = recordModel.bookId;
                record.userId = recordModel.userId;
                record.borrowDate = recordModel.borrowDate;
                record.returnDueDate = recordModel.returnDueDate;
                record.status = recordModel.status;
         
                //add to context and save
                context.Records.Add(record);
                context.SaveChanges();

                return new JsonResult(record);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }

        }

        [HttpGet]
        [Route("getmember")] // GET MEMBER BY ID
        public JsonResult GetMember(int id)
        {
            try
            {
                var context = new LibraryContext();
                User user = context.Users.Find(id);
                return new JsonResult(user);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        [HttpGet]
        [Route("getbook")] // GET BOOK BY ID
        public JsonResult GetBook(int id)
        {
            try
            {
                var context = new LibraryContext();
                Book book = context.Books.Find(id);
                return new JsonResult(book);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPost]
        [Route("changebookstatus")] // EDIT RECORD STATUS
        public JsonResult EditBookStatus([FromBody] BookModel bookModel)
        {
            try
            {
                var context = new LibraryContext();

                // set book record attributes, 
                Book book = context.Books.Find(bookModel.bookId);
                book.status = bookModel.status;

                context.SaveChanges();

                return new JsonResult(book);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
        [HttpPost]
        [Route("editbook")] // EDIT BOOK
        public JsonResult EditBook([FromBody] BookModel bookModel)
        {
            try
            {
                var context = new LibraryContext();

                // set book attributes, 
                Book book = context.Books.Find(bookModel.bookId);
                book.serialNo = bookModel.serialNo;
                book.title = bookModel.title;
                book.description = bookModel.description;
                book.author = bookModel.author;
                book.image = bookModel.image.FileName;
                book.category = bookModel.category;
                book.status = bookModel.status;
                var img = bookModel.image;

                //add to context and save
                context.Books.Add(book);
                context.SaveChanges();

                return new JsonResult(book);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }


        [HttpPost]
        [Route("addbook")] // INSERT BOOK
        public JsonResult AddBook([FromBody] BookModel bookModel)
        {
                try
                {
                    var context = new LibraryContext();

                    // set book attributes, 
                    Book book = new Book();
                    book.serialNo = bookModel.serialNo;
                    book.title = bookModel.title;
                    book.description = bookModel.description;
                    book.author = bookModel.author;
                    book.image = bookModel.image.FileName;
                    book.category = bookModel.category;
                    book.status = "available";
                     var img = bookModel.image;
             

                    //add to context and save
                    context.Books.Add(book);
                    context.SaveChanges();
                   
                    return new JsonResult(book);
                }
                catch (Exception e)
                {
                    return new JsonResult(e.Message);
                }
            
        }

        [HttpPost]
        [Route("login")] // LOGIN MEMBER
        public JsonResult Login([FromBody] Login login)
        {        
                try
                {
                    var context = new LibraryContext();      
                    var user = context.Users
                    .Where(u => u.email == login.email)
                    .Where(u => u.password == login.password)
                    .FirstOrDefault<User>();   // get user with same password and email
                    return new JsonResult(user);
                }
                catch (Exception e)
                {
                    return new JsonResult(e.Message);
                }
        }

        [HttpPost]
        [Route("register")] // REGISTER MEMBER
        public JsonResult Register([FromBody] Register register)
        {
            var context = new LibraryContext();

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // set user attributes, 
                    User user = new User();
                    user.firstname = register.firstname;
                    user.lastname = register.lastname;
                    user.email = register.email;   
                    user.password = register.password;
                    user.birthday = register.birthday;
                    user.contact = register.contact;

                    //add to context and save
                    context.Users.Add(user);
                    context.SaveChanges();

                    // set address attributes,
                    Address address = new Address();
                    var regUser = context.Users.Where(u => u.email == register.email).FirstOrDefault<User>();   // get registered user
                    address.strAddress = register.strAddress;
                    address.buildNo = register.buildNo;
                    address.unitNo = register.unitNo;
                    address.postcode = register.postcode;
                    address.buildNo = register.buildNo;
                    address.userId = regUser.userId;

                    //add to context and save
                    context.Addresses.Add(address);
                    context.SaveChanges();

                    //commit changes
                    transaction.Commit();

                    return new JsonResult(user);
                }
                catch (Exception e)
                {
                    //rollback changes
                    transaction.Rollback();
                    return new JsonResult(e.Message);
                }
            }
        }

        [HttpGet]
        [Route("getallmembers")] // GET ALL MEMBERS
        public JsonResult GetAllMembers()
        {
            try
            {
                var context = new LibraryContext();
                var userList = context.Users.Where(u => u.type == "member").ToList();// get all user who are members 

                return new JsonResult(userList);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }


        [HttpGet]
        [Route("getallbooks")] // GET ALL BOOKS
        public JsonResult GetAllBooks()
        {
            try
            {
                var context = new LibraryContext();
                var bookList = context.Books.ToList(); //get all books

                return new JsonResult(bookList);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }


        [HttpGet]
        [Route("getallrecords")] // GET ALL BOOKS
        public JsonResult GetAllRecords()
        {
            try
            {
                var context = new LibraryContext();
                var bookList = context.Records.ToList(); //get all borrowing records

                return new JsonResult(bookList);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
