using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryMobileApp.Models
{
    public class UserService
    {

        public int ID { get; set; }

        public int ServiceID { get; set; }

        public int UserID { get; set; }

        public DateTime Date { get; set; }

        public Service Service { get; set; }
        public string DateText => Date.ToString("dd.MM.yyyy");
    }
}
