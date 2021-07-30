using ConsumeBookKeepAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumeBookKeepAPI.Controllers
{
    public class BookController : Controller
    {
        public struct ConvertEnum
        {
            public Guid Value
            {
                get;
                set;
            }
            public String Text
            {
                get;
                set;
            }
        }

        string Baseurl = "http://localhost:64726";
        // GET: Book
        public async Task<ActionResult> Index()
        {
            List<Book> BookList = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage restRes = await client.GetAsync("/api/Book/GetBooks");
                if (restRes.IsSuccessStatusCode)
                {
                    var BookResponse = restRes.Content.ReadAsStringAsync().Result;
                    BookList = JsonConvert.DeserializeObject<List<Book>>(BookResponse);
                }
            }
            var test = new Book();
            test.BookName = "TestBook";
            test.ISBN = "23424342344";
            test.Edition = "3rd";

            BookList.Add(test);

                return View(BookList);
        }

        public async Task<ActionResult> Create()
        {
            List<Author> AuthorList = new List<Author>();
            var authors = new List<ConvertEnum>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage restRes = await client.GetAsync("/api/Author/Get");
                if (restRes.IsSuccessStatusCode)
                {
                    var AuthResponse = restRes.Content.ReadAsStringAsync().Result;
                    AuthorList = JsonConvert.DeserializeObject<List<Author>>(AuthResponse);
                }

                authors.Add(new ConvertEnum
                {
                    Value = new Guid(),
                    Text = "Test Auth" 
                });

                foreach (var lang in AuthorList)
                    authors.Add(new ConvertEnum
                    {
                        Value = lang.Id,
                        Text = lang.FirstName + " " + lang.LastName
                    });
            }
            ViewBag.BookAuthors = authors;
            return View();
        }

        [HttpPost]
        public ActionResult create(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl +"/api/Book");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Book>("Book", book);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(book);
        }

        public ActionResult Edit(Guid id)
        {
            Book book = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "/api/Book");
                //HTTP GET
                var responseTask = client.GetAsync("Get?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "/api/Book");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Book>("Book", book);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        public ActionResult Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "/api/Book/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}