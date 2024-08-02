using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class User
    {
        protected Guid Id { get; set; }
        protected string Name { get; set; }
        protected string LastName { get; set; }
        protected string TypeDocument { get; set; }
        protected string IdentificationNumber { get; set; }
        protected DateOnly BirthDate { get; set; }
        protected string PhoneNumber { get; set; }
        protected string Address { get; set; }

        public User(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthDate, string phoneNumber, string address)
        {
            Name = name;
            LastName = lastName;
            TypeDocument = typeDocument;
            IdentificationNumber = identificationNumber;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        protected void ShowDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"LastName: {LastName}");
            Console.WriteLine($"TypeDocument: {TypeDocument}");
            Console.WriteLine($"IdentificationNumber: {IdentificationNumber}");
            Console.WriteLine($"BirthDate: {BirthDate}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }

        protected int CalculateAge()
        {
            var age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Month)
            {
                age--;
            }
            return age;
        }

        protected void ShowAge(){
            Console.WriteLine($"Age: {CalculateAge()}");
        }
    }
}