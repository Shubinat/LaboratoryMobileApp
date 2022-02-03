using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryMobileApp.Models
{
    public class News
    {       
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatingDate { get; set; }
        public string CreatingDateText => CreatingDate.ToString("dd.MM.yyyy HH:mm");
    }
}
