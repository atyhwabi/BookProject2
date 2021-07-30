using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using BooksKeeperAPI.Infrustructure;
using BooksKeeperAPI.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace BooksKeeperAPI.Controllers
{
    public class BookController : ApiController
    {
        public BookDBContext db = new BookDBContext();
        // GET api/<controller>pg
       
        public async Task<List<Book>> GetBooks()
        {
         
            try
            { 
                
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var booklist = await db.Books.ToListAsync();
                    return booklist;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }

        // GET api/<controller>/5
     
        public async Task<Book> Get(Guid id)
        {
            try
            {
          
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                { 
                    var temp = await repo.GetByIdAsync<Book>(id);
                 
                    return temp;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromUri]Book model)
        {
            
            try
            {
            
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var entity = new Book()
                    {
                        BookName = model.BookName,
                        ISBN = model.ISBN,
                        Edition = model.Edition,
                        CreatedAt = model.CreatedAt,
      
                    };

                    

                    repo.Create<Book>(entity);
                    var result = await db.SaveChangesAsync() == 0 ? null : entity;
                    if (result != null)
                    {
                        var bookAuth = new BookAuthor()
                        {
                            BookId = result.Id,
                            AuthorID = result.BookAuthor.AuthorID

                        };

                        repo.Create<BookAuthor>(bookAuth);
                        var result2 = await db.SaveChangesAsync() == 0 ? null : bookAuth;

                        if (result2 != null)
                        {
                            HttpResponseMessage message2 = Request.CreateResponse<Book>(HttpStatusCode.OK, entity);
                            return message2;
                        }
                        else
                        {
                            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Auth book failed to save");
                            return response;

                        }
                      

                      
                    }
                    else
                    {
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Book failed to save");
                        return response;
                    }
                }
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Error message");
                return response;
            }
        }

        // PUT api/<controller>/5
        public async Task Put(int id, [FromBody]Book book)
        {
            try
            {
               
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Update<Book>(book);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        // DELETE api/<controller>/5
        public async Task Delete(Book book)
        {
            try
            {
          
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Delete<Book>(book);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

    }
}