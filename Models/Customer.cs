using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class Customer(string name,
    string lastName,
    string typeDocument,
    string identificationNumber,
    DateOnly birthDate,
    string phoneNumber,
    string address,
    string membershipLevel,
    string preferredPaymentMethod) :
    User(name,
    lastName,
    typeDocument,
    identificationNumber,
    birthDate,
    phoneNumber,
    address)
    {
        public string MembershipLevel { get; set; }
        public string PreferredPaymentMethod { get; set; }

        public void UpdateMembershipLevel(string membershipLevel)
        {
            MembershipLevel = membershipLevel;
        }

        public void ShowCustomer()
        {
            Settings.Header("CLIENTE");
            base.ShowDetails();
            Console.WriteLine($"Nivel de membresía: {MembershipLevel}");
            Console.WriteLine($"Método de pago: {PreferredPaymentMethod}");
        }
    }
}