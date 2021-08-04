using BooksKeeperAPI.Infrustructure;
using BooksKeeperAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksKeeperAPI.Controllers
{
    public class AuthorController : ApiController
    {
        
  

            public async Task<List<Author>> Get()
            {

                try
                {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                    {
                        var authors = await db.Authors.ToListAsync();
                        authors = authors.Where(_ => _.IsDeleted == false).ToList();
                        return authors;
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                    return null;
                }
            }

            // GET api/<controller>/5

            public async Task<Author> Get(Guid id)
            {
                try
                {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                    {
                        var temp = await repo.GetByIdAsync<Author>(id);

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
        public async Task<HttpResponseMessage> Post(Author model)
        {

            try
            {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var entity = new Author()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CreatedAt = model.CreatedAt


                    };

                    repo.Create<Author>(entity);
                    var result = await db.SaveChangesAsync() == 0 ? null : entity;
                    if (result != null)
                    {
                        HttpResponseMessage message = Request.CreateResponse<Author>(HttpStatusCode.OK, entity);
                        return message;
                    }
                    else
                    {
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Error message");
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
        public async Task Put( Author author)
            {
                try
                {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                    {
                        repo.Update<Author>(author);
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
        }
        public async Task<Author> Put(Guid authID)
        {
            try
            {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                   var author =  await  repo.GetByIdAsync<Author>(authID);
                    if (author != null)
                    {
                        return author;
                    }
                    else
                    {
                        return null;
                    }
                }
                  
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }
        // DELETE api/<controller>/5
        public async Task Delete(Author author)
            {
                try
                {
                using (var db = new BookDBContext())
                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                    {
                        repo.Delete<Author>(author);
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