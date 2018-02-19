using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservationSystem.Controllers
{
    public class RegisterController : Controller
    {
        string Baseurl = "http://localhost:5000/";
        // GET: /<controller>/
        public IActionResult Registration()
        {
            User user = new User() { Username = "meven", Password = "meven", FirstName = "meven", LastName = "meven" };
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Index(User obj)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource users using HttpClient  
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/user", obj);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    
                }
                //returning the user list to view  
                return View();
            }
        }
    }
}
