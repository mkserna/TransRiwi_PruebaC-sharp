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
        protected string Email { get; set; }
        protected string Address { get; set; }

        public string GetName() => Name;
        public string GetLastName() => LastName;
        public string GetTypeDocument() => TypeDocument;
        public string GetIdentificationNumber() => IdentificationNumber;
        public DateOnly GetBirthDate() => BirthDate;
        public string GetPhoneNumber() => PhoneNumber;
        public string GetEmail() => Email;
        public string GetAddress() => Address;

        public string SetName(string name) => Name = name;
        public string SetLastName(string lastName) => LastName = lastName;
        public string SetTypeDocument(string typeDocument) => TypeDocument = typeDocument;
        public string SetIdentificationNumber(string identificationNumber) => IdentificationNumber = identificationNumber;
        public DateOnly SetBirthDate(DateOnly birthDate) => BirthDate = birthDate;
        public string SetPhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public string SetEmail(string email) => Email = email;
        public string SetAddress(string address) => Address = address;

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
            Console.WriteLine($"Nombre: {GetName()}");
            Console.WriteLine($"Apellido: {GetLastName()}");
            Console.WriteLine($"Tipo de documento: {GetTypeDocument()}");
            Console.WriteLine($"Numero de identificación: {GetIdentificationNumber()}");
            Console.WriteLine($"Fecha de nacimiento (aaaa/mm/dd): {GetBirthDate()}");
            Console.WriteLine($"Número de teléfono: {GetPhoneNumber()}");
            Console.WriteLine($"Dirección: {GetAddress()}");
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