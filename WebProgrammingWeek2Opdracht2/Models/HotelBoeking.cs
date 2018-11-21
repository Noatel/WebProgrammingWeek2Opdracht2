using System;
using System.Collections.Generic;

namespace WebProgrammingWeek2Opdracht2.Models
{
    public class HotelBoeking
    {
        public int BoekingID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public static List<HotelBoeking> AllBoeking = new List<HotelBoeking>();


        public HotelBoeking(string name, double Price, DateTime date)
        {
            this.Name = name;
            this.Price = Price;
            this.Date = date;
        }

        public HotelBoeking()
        {
        }
    }
}
