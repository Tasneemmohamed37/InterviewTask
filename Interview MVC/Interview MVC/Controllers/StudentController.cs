using Interview_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Interview_MVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            return View("Index");
        }

        public IActionResult Edit(int id)
        {
            string apiUrl = $"http://localhost:5022/api/Student/{id}";

            // AJAX request to the API
            string jsonData = "";
            using (WebClient webClient = new WebClient())
            {
                jsonData = webClient.DownloadString(apiUrl);
            }

            // Deserialize the JSON to Student 
            Student student = JsonConvert.DeserializeObject<Student>(jsonData);

            return View("Edit", student);
        }


        [HttpPost]
        public IActionResult SaveEdit([FromBody]Student std)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Student Edited successfully.";
                return RedirectToAction("Index");
            }
            return View("Edit", std);
        }


        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New([FromBody]Student std)
        {
            if (ModelState.IsValid == true)
            {
                TempData["SuccessMessage"] = "Student added successfully.";
                return RedirectToAction("index");
            }
            return View("New", std);
        }
    }
}
