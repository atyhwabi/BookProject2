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
    public class AuthorController : Controller
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
                List<Author> authList = new List<Author>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage restRes = await client.GetAsync("/api/Author/Get");
                    if (restRes.IsSuccessStatusCode)
                    {
                        var BookResponse = restRes.Content.ReadAsStringAsync().Result;
                    authList = JsonConvert.DeserializeObject<List<Author>>(BookResponse);
                    }
                }
                var test = new Author();
                test.FirstName = "Steve";
                test.LastName = "Job";
      

                  authList.Add(test);

                return View(authList);
            }

            public async Task<ActionResult> Create()
            {
                List<Book> bookList = new List<Book>();
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
                        bookList = JsonConvert.DeserializeObject<List<Book>>(AuthResponse);
                    }

                    authors.Add(new ConvertEnum
                    {
                        Value = new Guid(),
                        Text = "Test Auth"
                    });

                    foreach (var lang in bookList)
                        authors.Add(new ConvertEnum
                        {
                            Value = lang.Id,
                            Text = lang.BookName + " " + lang.Edition
                        });
                }
                ViewBag.BookAuthors = authors;
                return View();
            }

            [HttpPost]
            public ActionResult create(Author author)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + "/api/Author");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Author>("Author", author);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(author);
            }

            public ActionResult Edit(Guid id)
            {
                 Author author = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + "/api/Author");
                    //HTTP GET
                    var responseTask = client.GetAsync("Get?id=" + id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Author>();
                        readTask.Wait();

                        author = readTask.Result;
                    }
                }

                return View(author);
            }

            [HttpPost]
            public ActionResult Edit(Author author)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + "/api/Author");

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<Author>("Author", author);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }
                return View(author);
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