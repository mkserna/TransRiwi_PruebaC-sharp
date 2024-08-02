using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string TypeLicense { get; set; }
        public string EngineNumber { get; set; }
        public string SerialNumber { get; set; }
        public byte PeopleCapacity { get; set; }
        public Driver Owner { get; set; }

    }
}