using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelReservationSystem.Controllers
{
    public class BookingController : Controller
    {
        string Baseurl = "http://localhost:53617/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Bookings(String User_id)
        {
            using (var client = new HttpClient())
            {
                List<Room> RoomBookings = new List<Room>();
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource users using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/user/bookings/1" );

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    var BookingResponse = Res.Content.ReadAsStringAsync().Result;
                    RoomBookings = JsonConvert.DeserializeObject<List<Room>>(BookingResponse);
                }
                //returning the user list to view  
                return View(RoomBookings);
            }
        }
    }
}