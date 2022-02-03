using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratoryMobileApp.Models
{
    public class Service
    {

        public Service(int id, string name, string description, decimal price)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ShortDescription => Description.Length > 25? new string(Description.Take(25).ToArray()) + "..." : Description;
    }
}
