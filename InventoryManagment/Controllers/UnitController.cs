using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagment.Models;


using System.Net.Http;


namespace InventoryManagment.Controllers
{
    public class UnitController : Controller
    {

        public IActionResult Index()
        {
            IEnumerable<UnitModels> unit = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Unit");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UnitModels>>();
                    readTask.Wait();

                    unit = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    unit = Enumerable.Empty<UnitModels>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(unit);
        }
    

        public IActionResult Create()
        {
            UnitModels unit = new UnitModels();
            return View(unit);
        }
        [HttpPost]
        public IActionResult Create(UnitModels unit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/api/Unit/Create");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<UnitModels>("", unit);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(unit);
        }
        public IActionResult Details(int id)
        {
            UnitModels unit = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Unit/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UnitModels>();
                    readTask.Wait();

                    unit = readTask.Result;
                }
            }

            return View(unit);

        }

        public IActionResult Edit(int id)
        {
            UnitModels unit = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Unit/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UnitModels>();
                    readTask.Wait();

                    unit = readTask.Result;
                }
            }

            return View(unit);

        }
        [HttpPost]
        public IActionResult Edit(UnitModels unit)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44394/api/Unit/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<UnitModels>("Edit", unit);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(unit);
            }
            catch
            {


            }
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            UnitModels unit = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Unit/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UnitModels>();
                    readTask.Wait();

                    unit = readTask.Result;
                }
            }

            return View(unit);

        }

        [HttpPost]
        public IActionResult Delete(UnitModels unit)
        {
            try
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44394/api/Unit/");
                        var id = unit.Id;
                        //HTTP POST
                        var postTask = client.DeleteAsync("Delete"+ id.ToString());
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return View(unit);
                }
                catch
                {


                }
                return RedirectToAction("Index");
            }
            catch
            {


            }
            return RedirectToAction("Index");

        }

    }
}