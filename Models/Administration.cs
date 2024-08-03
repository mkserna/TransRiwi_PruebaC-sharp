using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class Administration
    {
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public static List<Customer> Customers { get; set; } = [
            new Customer("MARIANA", "SERNA", "CC", "123456789", new DateOnly(2000, 12, 22), "3008387411", "Calle 37", "Standard", "Tarjeta"),
            new Customer("JUAN", "LOPEZ", "CC", "123456789", new DateOnly(2003, 12, 22), "3008387411", "Calle 37", "Standard", "Tarjeta"),
            new Customer("MARIA", "PEREZ", "CC", "123456789", new DateOnly(1980, 12, 22), "3008387411", "Calle 37", "Standard", "Efectivo")];
        public static List<Driver> Drivers { get; set; } = [
            new Driver("MARIANA", "SERNA", "CC", "123456789", new DateOnly(2000, 12 ,22), "3008387411", "Calle 37", "711454", "A1", 15),
            new Driver("JUAN", "LOPEZ", "CC", "123456789", new DateOnly(2003, 12, 22), "3008387411", "Calle 37", "711454", "A1", 3),
            new Driver("MARIA", "PEREZ", "CC", "123456789", new DateOnly(1980, 12, 22), "3008387411", "Calle 37", "711454", "A1", 10)
        ];


        //CRUC PARA VEHICULOS
        public void AddVehicle()
        {
            Settings.Header("AGREGANDO VEHICULO");

            Console.Write("Ingrese la matrícula del vehículo: ");
            string? licensePlate = Console.ReadLine();
            Console.Write(@"Ingrese el tipo de vehiculo: 
                            1. Moto
                            2. Carro
                            3. Camioneta
                            4. Microbus
                            Ingresa una opción: ");
            int selectedTypeVehicle = Convert.ToInt32(Console.ReadLine());
            string? typeVehicle = null;
            switch (selectedTypeVehicle)
            {
                case 1:
                    typeVehicle = "Moto";
                    break;
                case 2:
                    typeVehicle = "Carro";
                    break;
                case 3:
                    typeVehicle = "Camioneta";
                    break;
                case 4:
                    typeVehicle = "Microbus";
                    break;
                default:
                    Settings.Footer("TIPO DE VEHICULO NO VÁLIDO");
                    return;
            }
            Console.Write("Ingrese el número de motor del vehículo: ");
            string? engineNumber = Console.ReadLine();
            Console.Write("Ingrese el número de serie del vehículo: ");
            string? serialNumber = Console.ReadLine();
            Console.Write("Ingrese la capacidad de personas del vehículo: ");
            byte peopleCapacity = Convert.ToByte(Console.ReadLine());
            Console.Write("Ingrese el propietario del vehículo: ");
            string? owner = Console.ReadLine();
            Driver? driver = Drivers.Find(x => x.GetName() == owner);

            Vehicle vehicle = new Vehicle(licensePlate, typeVehicle, engineNumber, serialNumber, peopleCapacity, driver);

            Vehicles.Add(vehicle);
            Settings.Footer("AGREGANDO VEHICULO CON ÉXITO");
        }
        public void DeleteVehicle()
        {
            Settings.Header("ELIMINANDO VEHICULO");
            Console.Write("Ingrese la matrícula del vehículo: ");
            string? licensePlate = Console.ReadLine();
            licensePlate = licensePlate.ToUpper().Trim();

            if (licensePlate != null)
            {
                Vehicle? vehicle = Vehicles.Find(x => x.LicensePlate == licensePlate.ToUpper());
                if (vehicle != null)
                {
                    Vehicles.Remove(vehicle);
                    Settings.Footer("ELIMINANDO VEHICULO CON ÉXITO");
                }
                else
                {
                    Settings.Footer("MATRÍCULA NO ENCONTRADA");
                }
            }
        }
        public void ShowAllVehicles()
        {
            Settings.Header("VEHICULOS GUARDADOS");
            foreach (Vehicle vehicle in Vehicles)
            {
                vehicle.ShowVehicle();
            }
        }

        //CRUC PARA CONDUCTORES
        public void AddDriver()
        {
            Settings.Header("AGREGANDO DRIVER");
            Console.Write("Ingrese el nombre del conductor: ");
            string name = Console.ReadLine();
            Console.Write("Ingrese el apellido del conductor: ");
            string lastName = Console.ReadLine();
            Console.Write("Ingrese el tipo de documento del conductor: ");
            string typeDocument = Console.ReadLine();
            Console.Write("Ingrese el número de identificación del conductor: ");
            string identificationNumber = Console.ReadLine();
            Console.Write("Ingrese la fecha de nacimiento del conductor (aaaa/mm/dd): ");
            DateOnly birthDate = DateOnly.Parse(Console.ReadLine());
            Console.Write("Ingrese el número de teléfono del conductor: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Ingrese la dirección del conductor: ");
            string address = Console.ReadLine();
            Console.Write("Ingrese el número de licencia del conductor: ");
            string licenseNumber = Console.ReadLine();

            Console.Write(@"Ingrese la categoría de la licencia del conductor
                            1. A1
                            2. A2
                            Ingresa una opción: ");
            int selectedLicenseCategory = Convert.ToInt32(Console.ReadLine());
            string? licenseCategory = null;
            switch (selectedLicenseCategory)
            {
                case 1:
                    licenseCategory = "A1";
                    break;
                case 2:
                    licenseCategory = "A2";
                    break;
                default:
                    Settings.Footer("CATEGORÍA DE LA LICENCIA NO VÁLIDO");
                    return;
            }

            Console.Write("Ingrese la experiencia del conductor: ");
            int drivingExperience = Convert.ToInt32(Console.ReadLine());
            Driver driver = new Driver(name, lastName, typeDocument, identificationNumber, birthDate, phoneNumber, address, licenseNumber, licenseCategory, drivingExperience);

            Drivers.Add(driver);
            Settings.Footer("AGREGANDO DRIVER CON ÉXITO");
        }
        public void UpdateDriver()
        {
            Settings.Header("ACTUALIZANDO DRIVER");
            Console.Write("Ingrese el nombre del conductor: ");
            string name = Console.ReadLine();
            name = name.Trim();

            Driver driver = Drivers.Find(x => x.GetName() == name);

            if (driver != null)
            {
                Console.Write($"Nuevo nombre del conductor o presione enter para mantener el mismo ({driver.GetName()}): ");
                string nameUpdate = Console.ReadLine();
                nameUpdate = nameUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo apellido del conductor o presione enter para mantener el mismo ({driver.GetLastName()}): ");
                string lastNameUpdate = Console.ReadLine();
                lastNameUpdate = lastNameUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo tipo de documento del conductor o presione enter para mantener el mismo ({driver.GetTypeDocument()}): ");
                string typeDocumentUpdate = Console.ReadLine();
                typeDocumentUpdate = typeDocumentUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo número de identificación del conductor o presione enter para mantener el mismo ({driver.GetIdentificationNumber()}): ");
                string identificationNumberUpdate = Console.ReadLine();
                identificationNumberUpdate = identificationNumberUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nueva fecha de nacimiento del conductor (aaaa/mm/dd) o presione enter para mantener el mismo ({driver.GetBirthDate()}): ");
                DateOnly birthDateUpdate = DateOnly.Parse(Console.ReadLine());
                Settings.Separator();

                Console.Write($"Nuevo número de teléfono del conductor o presione enter para mantener el mismo ({driver.GetPhoneNumber()}): ");
                string phoneNumberUpdate = Console.ReadLine();
                phoneNumberUpdate = phoneNumberUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo número de email del conductor o presione enter para mantener el mismo ({driver.GetPhoneNumber()}): ");
                string emailUpdate = Console.ReadLine();
                emailUpdate = emailUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nueva dirección del conductor o presione enter para mantener el mismo ({driver.GetAddress()}): ");
                string addressUpdate = Console.ReadLine();
                addressUpdate = addressUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo número de licencia del conductor o presione enter para mantener el mismo ({driver.LicenseNumber}): ");
                string licenseNumberUpdate = Console.ReadLine();
                licenseNumberUpdate = licenseNumberUpdate.Trim();
                Settings.Separator();

                Console.Write(@"Nueva categoría de la licencia del conductor 
                                    1. A1
                                    2. A2
                                o presione enter para mantener el mismo{driver.LicenseCategory}: ");
                int selectedLicenseCategory = Convert.ToInt32(Console.ReadLine());
                string? licenseCategoryUpdate = null;
                switch (selectedLicenseCategory)
                {
                    case 1:
                        licenseCategoryUpdate = "A1";
                        break;
                    case 2:
                        licenseCategoryUpdate = "A2";
                        break;
                    default:
                        Settings.Footer("CATEGORÍA DE LA LICENCIA NO VÁLIDO");
                        return;
                }

                Console.Write($"Nueva experiencia del conductor o presione enter para mantener el mismo ({driver.DrivingExperience}): ");
                string? drivingExperienceUpdate = Console.ReadLine();
                int drivingExperienceUpdateInt = Convert.ToInt32(Console.ReadLine());
                Settings.Separator();

                driver.SetName(string.IsNullOrEmpty(nameUpdate) ? driver.GetName() : nameUpdate);
                driver.SetLastName(string.IsNullOrEmpty(lastNameUpdate) ? driver.GetLastName() : lastNameUpdate);
                driver.SetTypeDocument(string.IsNullOrEmpty(typeDocumentUpdate) ? driver.GetTypeDocument() : typeDocumentUpdate);
                driver.SetIdentificationNumber(string.IsNullOrEmpty(identificationNumberUpdate) ? driver.GetIdentificationNumber() : identificationNumberUpdate);
                driver.SetBirthDate(birthDateUpdate == null ? driver.GetBirthDate() : birthDateUpdate);
                driver.SetPhoneNumber(string.IsNullOrEmpty(phoneNumberUpdate) ? driver.GetPhoneNumber() : phoneNumberUpdate);
                driver.SetEmail(string.IsNullOrEmpty(emailUpdate) ? driver.GetEmail() : emailUpdate);
                driver.SetAddress(string.IsNullOrEmpty(addressUpdate) ? driver.GetAddress() : addressUpdate);
                driver.LicenseNumber = string.IsNullOrEmpty(licenseNumberUpdate) ? driver.LicenseNumber : licenseNumberUpdate;
                driver.LicenseCategory = string.IsNullOrEmpty(licenseCategoryUpdate) ? driver.LicenseCategory : licenseCategoryUpdate;
                driver.DrivingExperience = drivingExperienceUpdateInt == 0 ? driver.DrivingExperience : drivingExperienceUpdateInt;
                Settings.Footer("CONDUCTOR ACTUALIZANDO CON ÉXITO");
            }
        }
        public void DeleteDriver()
        {
            Settings.Header("ELIMINANDO CONDUCTOR");
            Console.Write("Ingrese el documento del conductor: ");
            string document = Console.ReadLine();
            document = document.Trim();

            Driver driver = Drivers.Find(x => x.GetIdentificationNumber() == document);
            if (driver != null)
            {
                Drivers.Remove(driver);
                Settings.Footer("ELIMINANDO CONDUCTOR CON ÉXITO");
            }
            else
            {
                Settings.Footer("CONDUCTOR NO ENCONTRADO");
            }
        }
        public void ShowAllDrivers()
        {
            Settings.Header("CONDUCTORES GUARDADOS");
            foreach (Driver driver in Drivers)
            {
                driver.ShowDriver();
            }
        }

        //CRUC PARA CLINTES
        public void AddClient()
        {
            Settings.Header("AGREGANDO CLIENTE");
            Console.Write("Ingrese el nombre: ");
            string name = Console.ReadLine();
            Settings.Separator();

            Console.Write("Ingrese el apellido: ");
            string lastName = Console.ReadLine();
            Settings.Separator();

            Console.Write("Ingrese el tipo de documento: ");
            string typeDocument = Console.ReadLine();
            Settings.Separator();

            Console.Write("Ingrese el número de identificación: ");
            string identificationNumber = Console.ReadLine();
            Settings.Separator();

            Console.Write("Ingrese la fecha de nacimiento (aaaa/mm/dd): ");
            DateOnly birthDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Ingrese el número de teléfono: ");
            string phoneNumber = Console.ReadLine();
            Settings.Separator();

            Console.Write("Ingrese la dirección: ");
            string address = Console.ReadLine();
            Settings.Separator();

            Console.Write(@"Ingrese el nivel de membresía: 
                            1. Basica
                            2. Standard
                            3. Premium
                            Ingresa una opción: ");
            int selectedMembershipLevel = Convert.ToInt32(Console.ReadLine());
            string? membershipLevel = null;
            switch (selectedMembershipLevel)
            {
                case 1:
                    membershipLevel = "Basica";
                    break;
                case 2:
                    membershipLevel = "Standard";
                    break;
                case 3:
                    membershipLevel = "Premium";
                    break;
                default:
                    Settings.Footer("NIVEL DE MEMBRESÍA NO VÁLIDO");
                    return;
            }

            Settings.Separator();

            Console.Write(@"Ingrese el método de pago: 
                            1. Efectivo
                            2. Tarjeta
                            Ingresa una opción: ");
            int selectedTypePaymentMethod = Convert.ToInt32(Console.ReadLine());
            string? preferredPaymentMethod = null;
            switch (selectedTypePaymentMethod)
            {
                case 1:
                    preferredPaymentMethod = "Efectivo";
                    break;
                case 2:
                    preferredPaymentMethod = "Tarjeta";
                    break;

                default:
                    Settings.Footer("TIPO DE PAGO NO VÁLIDO");
                    return;
            }
            Settings.Separator();

            Customer customer = new Customer(name, lastName, typeDocument, identificationNumber, birthDate, phoneNumber, address, membershipLevel, preferredPaymentMethod);
            Customers.Add(customer);
            Settings.Footer("AGREGANDO CLIENTE CON ÉXITO");
        }
        public void DeleteCustomer()
        {
            Settings.Header("ELIMINANDO CLIENTE");
            Console.Write("Ingrese el documento del cliente: ");
            string document = Console.ReadLine();
            document = document.Trim();

            Customer customer = Customers.Find(x => x.GetIdentificationNumber() == document);
            if (customer != null)
            {
                Customers.Remove(customer);
                Settings.Footer("CLIENTE ELIMINANDO CON ÉXITO");
            }
            else
            {
                Settings.Footer("CLIENTE NO ENCONTRADO");
            }
        }
        public void ShowAllCustomers()
        {
            Settings.Header("CLIENTES GUARDADOS");
            foreach (Customer customer in Customers)
            {
                customer.ShowCustomer();
            }
        }
        public void UpdateCustomer()
        {
            Settings.Header("ACTUALIZANDO CLIENTE");
            Console.Write("Ingrese el nombre del cliente: ");
            string name = Console.ReadLine();
            name = name.Trim();

            Customer customer = Customers.Find(x => x.GetName() == name);

            if (customer != null)
            {
                Console.Write($"Nuevo nombre del cliente o presione enter para mantener el mismo ({customer.GetName()}): ");
                string nameUpdate = Console.ReadLine();
                nameUpdate = nameUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo apellido del cliente o presione enter para mantener el mismo ({customer.GetLastName()}): ");
                string lastNameUpdate = Console.ReadLine();
                lastNameUpdate = lastNameUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo tipo de documento del cliente o presione enter para mantener el mismo ({customer.GetTypeDocument()}): ");
                string typeDocumentUpdate = Console.ReadLine();
                typeDocumentUpdate = typeDocumentUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo número de identificación del cliente o presione enter para mantener el mismo ({customer.GetIdentificationNumber()}): ");
                string identificationNumberUpdate = Console.ReadLine();
                identificationNumberUpdate = identificationNumberUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nueva fecha de nacimiento del cliente (aaaa/mm/dd) o presione enter para mantener el mismo ({customer.GetBirthDate()}): ");
                DateOnly birthDateUpdate = DateOnly.Parse(Console.ReadLine());
                Settings.Separator();

                Console.Write($"Nuevo número de teléfono del cliente o presione enter para mantener el mismo ({customer.GetPhoneNumber()}): ");
                string phoneNumberUpdate = Console.ReadLine();
                phoneNumberUpdate = phoneNumberUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nuevo email del cliente o presione enter para mantener el mismo ({customer.GetEmail()}): ");
                string emailUpdate = Console.ReadLine();
                emailUpdate = emailUpdate.Trim();
                Settings.Separator();

                Console.Write($"Nueva dirección del cliente o presione enter para mantener el mismo ({customer.GetAddress()}): ");
                string addressUpdate = Console.ReadLine();
                addressUpdate = addressUpdate.Trim();
                Settings.Separator();

                Console.Write(@"Ingrese el nivel de membresía: 
                            1. Basica
                            2. Standard
                            3. Premium
                            Ingresa una opción: ");
                int selectedMembershipLevel = Convert.ToInt32(Console.ReadLine());
                string? membershipLevelUpdate = null;
                switch (selectedMembershipLevel)
                {
                    case 1:
                        membershipLevelUpdate = "Basica";
                        break;
                    case 2:
                        membershipLevelUpdate = "Standard";
                        break;
                    case 3:
                        membershipLevelUpdate = "Premium";
                        break;
                    default:
                        Settings.Footer("NIVEL DE MEMBRESÍA NO VÁLIDO");
                        return;
                }
                Settings.Separator();

                Console.Write($@"Nuevo método de pago del cliente
                                    1. Efectivo
                                    2. Tarjeta
                                o presione enter para mantener el mismo{customer.PreferredPaymentMethod}: ");
                int selectedTypePaymentMethod = Convert.ToInt32(Console.ReadLine());
                string? preferredPaymentMethod = null;
                switch (selectedTypePaymentMethod)
                {
                    case 1:
                        preferredPaymentMethod = "Efectivo";
                        break;
                    case 2:
                        preferredPaymentMethod = "Tarjeta";
                        break;

                    default:
                        Settings.Footer("TIPO DE PAGO NO VÁLIDO");
                        return;
                }

                customer.SetName(string.IsNullOrEmpty(nameUpdate) ? customer.GetName() : nameUpdate);
                customer.SetLastName(string.IsNullOrEmpty(lastNameUpdate) ? customer.GetLastName() : lastNameUpdate);
                customer.SetTypeDocument(string.IsNullOrEmpty(typeDocumentUpdate) ? customer.GetTypeDocument() : typeDocumentUpdate);
                customer.SetIdentificationNumber(string.IsNullOrEmpty(identificationNumberUpdate) ? customer.GetIdentificationNumber() : identificationNumberUpdate);
                customer.SetBirthDate(birthDateUpdate == null ? customer.GetBirthDate() : birthDateUpdate);
                customer.SetPhoneNumber(string.IsNullOrEmpty(phoneNumberUpdate) ? customer.GetPhoneNumber() : phoneNumberUpdate);
                customer.SetEmail(string.IsNullOrEmpty(emailUpdate) ? customer.GetEmail() : emailUpdate);
                customer.SetAddress(string.IsNullOrEmpty(addressUpdate) ? customer.GetAddress() : addressUpdate);
                customer.MembershipLevel = string.IsNullOrEmpty(membershipLevelUpdate) ? customer.MembershipLevel : membershipLevelUpdate;
                customer.PreferredPaymentMethod = string.IsNullOrEmpty(preferredPaymentMethod) ? customer.PreferredPaymentMethod : preferredPaymentMethod;
                Settings.Footer("CLIENTE ACTUALIZANDO CON ÉXITO");
            }
        }

        //Usuarios con mas de 30 años 
        public void UserOverThirty()
        {
            Settings.Header("USUARIOS CON MAS DE 30 AÑOS");
            foreach (Customer customer in Customers.Where(x => x.GetBirthDate().Year > DateTime.Now.Year - 30))
            {
                customer.ShowCustomer();
            }
        }

        //Usuarios que pagan con tarjeta 
        public void UserPayWithCard()
        {
            Settings.Header("USUARIOS QUE PAGAN CON TARJETA");
            foreach (Customer customer in Customers.Where(x => x.PreferredPaymentMethod == "Tarjeta"))
            {
                customer.ShowCustomer();
            }
        }

        //Usuarios con licencia A2
        public void UserWithLicenseA2()
        {
            Settings.Header("USUARIOS CON LICENCIA A2");
            foreach (Driver driver in Drivers.Where(x => x.LicenseCategory == "A2"))
            {
                driver.ShowDriver();
            }
        }

        //Ordenar conductores por su experiencia desendentemente
        public void SortDriversByDrivingExperience()
        {
            Settings.Header("CONDUCTORES ORDENADOS POR EXPERIENCIA DESENDENTEMENTE");
            Drivers.OrderByDescending(x => x.DrivingExperience);
            foreach (Driver driver in Drivers)
            {
                driver.ShowDriver();
            }
        }
    }
}
