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
        public void UpdateDrivingExperience()
        {

        }

        public void AddExperience(int experience)
        {
            DrivingExperience += experience;
        }
    }
}