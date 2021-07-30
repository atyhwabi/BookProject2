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
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace BooksKeeperAPI.Controllers
{
    public class BookAuthorController : ApiController
    {
        public BookDBContext db = new BookDBContext();
        // GET api/<controller>pg

        public async Task<List<BookAuthor>> GetBookAuthors()
        {

            try
            {

                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var bookauthlist = await db.BookAuthors.ToListAsync();
                    return bookauthlist;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }

        // GET api/<controller>/5

        public async Task<BookAuthor> Get(Guid? bookId, Guid? authID)
        {

            try
            {

                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var tm =   db.BookAuthors.FirstOrDefault(_ => _.BookId == bookId && _.AuthorID == authID);
                    var temp = await repo.GetByIdAsync<BookAuthor>(tm.Id);

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
        public async Task<HttpResponseMessage> Post([FromUri]BookAuthor model)
        {

            try
            {

                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    var entity = new BookAuthor()
                    {
                        PublishDate = model.PublishDate,
                        AuthorID = model.AuthorID,
                        BookId = model.BookId,
                        CreatedAt = model.CreatedAt

                    };



                    repo.Create<BookAuthor>(entity);
                    var result = await db.SaveChangesAsync() == 0 ? null : entity;
                    if (result != null)
                    {
                        HttpResponseMessage message = Request.CreateResponse<BookAuthor>(HttpStatusCode.OK, entity);
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
        public async Task Put(int id, [FromBody]BookAuthor bookAuth)
        {
            try
            {

                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Update<BookAuthor>(bookAuth);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        // DELETE api/<controller>/5
        public async Task Delete(BookAuthor bookAuth)
        {
            try
            {

                using (var repo = new EntityFrameWorkRepository<BookDBContext>(db))
                {
                    repo.Delete<BookAuthor>(bookAuth);
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
