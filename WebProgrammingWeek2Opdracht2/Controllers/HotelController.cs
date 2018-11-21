using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingWeek2Opdracht2.Models;

namespace WebProgrammingWeek2Opdracht2.Controllers
{
    public class HotelController : Controller
    {
        [HttpGet]
        [Route("Hotel/index")]
        public IActionResult Index()
        {

            return View("index",HotelBoeking.AllBoeking);
        }

        [HttpGet]
        [Route("Hotel/create")]
        public IActionResult AddBoeking()
        {

            return View();
        }


        [HttpPost]
        [Route("Hotel/create")]
        public IActionResult AddBoeking(string name, double price, DateTime date)
        {
            HotelBoeking boeking = new HotelBoeking()
            {
                Name = name,
                Price = price,
                Date = date
            };

            HotelBoeking.AllBoeking.Add(boeking);

            TempData["status"] = "Boeking " + boeking.Name + " is toegevoegd.";
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("Hotel/edit/{id}")]
        public IActionResult EditBoeking(int id)
        {
            HotelBoeking hotel = null;

            foreach(HotelBoeking getHotel in HotelBoeking.AllBoeking){
                if(getHotel.BoekingID == id){
                    hotel = getHotel;
                }
            }

            return View(hotel);
        }


        [HttpPost]
        [Route("Hotel/edit/{id}")]
        public IActionResult EditBoeking(int id,string name, double price, DateTime date)
        {
            foreach (HotelBoeking getHotel in HotelBoeking.AllBoeking)
            {
                if (getHotel.BoekingID == id)
                {
                    getHotel.Name = name;
                    getHotel.Price = price;
                    getHotel.Date = date;
                }
            }


            TempData["status"] = "Boeking " + name + " is gewijzigd.";
            return RedirectToAction("index");
        }


    }
}
