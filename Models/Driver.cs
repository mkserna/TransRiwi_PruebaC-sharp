using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class Driver(string name,
    string lastName,
    string typeDocument,
    string identificationNumber,
    DateOnly birthDate,
    string phoneNumber,
    string address,
    string licenseNumber,
    string licenseCategory,
    int drivingExperience) :
    User(name,
    lastName,
    typeDocument,
    identificationNumber,
    birthDate,
    phoneNumber,
    address)
    {
        public string LicenseNumber { get; set; }
        public string LicenseCategory { get; set; }
        public int DrivingExperience { get; set; }
        public void UpdateDrivingExperience(){
            Console.WriteLine("Ingrese la experiencia del conductor: ");
            int experience = Convert.ToInt32(Console.ReadLine());
            DrivingExperience = experience;
        }

        public void AddExperience(int years)
        {
            DrivingExperience += years;
        }

        public void ShowDriver()
        {
            Settings.Header("CONDUCTOR");
            base.ShowDetails();
            Console.WriteLine("Licencia:" + LicenseNumber);
            Console.WriteLine("Categoría de la licencia: " + LicenseCategory);
            Console.WriteLine("Experiencia: " + DrivingExperience);

        }
    }
}