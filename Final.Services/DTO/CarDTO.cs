using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Service.DTO 
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }  
        public string Model { get; set; } 
        public DateTime Year { get; set; }
        public string Manufacturer { get; set; }

    }
}