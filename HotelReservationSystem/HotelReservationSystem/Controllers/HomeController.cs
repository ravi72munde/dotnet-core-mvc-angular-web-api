using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HotelReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:53617/";      
        public async Task<ActionResult> Index()  
        {  
            List<User> UserInfo = new List<User>();  
              
            using (var client = new HttpClient())  
            {  
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);  
  
                client.DefaultRequestHeaders.Clear();  
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                  
                //Sending request to find web api REST service resource users using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/user");  
  
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)  
                {  
                    //Storing the response details recieved from web api   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;  
  
                    //Deserializing the response recieved from web api and storing into the user list  
                    UserInfo = JsonConvert.DeserializeObject<List<User>>(UserResponse);  
  
                }  
                //returning the user list to view  
                return View(UserInfo);  
            }  
        }  

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Added for Login and Authentication
        public ActionResult Login()
        {
            return View();
        }

    }
}
