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
        public string TypeVehicle { get; set; }
        public string EngineNumber { get; set; }
        public string SerialNumber { get; set; }
        public byte PeopleCapacity { get; set; }
        public Driver Owner { get; set; }

        public Vehicle(string licensePlate, string typeVehicle, string engineNumber, string serialNumber, byte peopleCapacity , Driver owner)
        {
            LicensePlate = licensePlate;
            TypeVehicle = typeVehicle;
            EngineNumber = engineNumber;
            SerialNumber = serialNumber;
            PeopleCapacity = peopleCapacity;
            Owner = owner;
        }

        public void ShowVehicle()
        {
            Settings.Header("VEHICULO");
            Console.WriteLine($"Matrícula: {LicensePlate}");
            Console.WriteLine($"Tipo de vehículo: {TypeVehicle}");
            Console.WriteLine($"Número de motor: {EngineNumber}");
            Console.WriteLine($"Número de serie: {SerialNumber}");
            Console.WriteLine($"Capacidad de personas: {PeopleCapacity}");
            Console.WriteLine($"Propietario: {Owner.GetName()}");
            Settings.Separator();
        }
    }
}