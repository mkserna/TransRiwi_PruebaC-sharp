using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Administration administration = new();
            bool follow = true;
            while (follow)
            {
                Settings.Header("TRANSRIWI");
                Console.WriteLine("1. Conductores");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Vehiculos");
                Console.WriteLine("4. Estadisticas");
                Console.WriteLine("5. Salir");
                Console.Write("Ingresa la opción: ");

                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        bool followDriver = true;
                        while (followDriver)
                        {
                            Settings.Header("TRANSRIWI - CONDUCTORES");
                            Console.WriteLine("1. Registrar conductor");
                            Console.WriteLine("2. Actualizar conductor");
                            Console.WriteLine("3. Eliminar conductor");
                            Console.WriteLine("4. Ver conductores");
                            Console.WriteLine("5. Salir");
                            Console.Write("Ingresa la opción: ");

                            byte optionDriver = byte.Parse(Console.ReadLine());
                            switch (optionDriver)
                            {
                                case 1:
                                    administration.AddDriver();
                                    break;
                                case 2:
                                    administration.UpdateDriver();
                                    break;
                                case 3:
                                    administration.DeleteDriver();
                                    break;
                                case 4:
                                    administration.ShowAllDrivers();
                                    break;
                                case 5:
                                    followDriver = false;
                                    break;
                                default:
                                    Settings.Footer("OPCION NO VALIDA");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool followClient = true;
                        while (followClient)
                        {
                            Settings.Header("TRANSRIWI - CLIENTES");
                            Console.WriteLine("1. Registrar cliente");
                            Console.WriteLine("2. Actualizar cliente");
                            Console.WriteLine("3. Eliminar cliente");
                            Console.WriteLine("4. Ver clientes");
                            Console.WriteLine("5. Salir");
                            Console.Write("Ingresa la opción: ");

                            byte optionClient = byte.Parse(Console.ReadLine());
                            switch (optionClient)
                            {
                                case 1:
                                    administration.AddClient();
                                    break;
                                case 2:
                                    administration.UpdateCustomer();
                                    break;
                                case 3:
                                    administration.DeleteCustomer();
                                    break;
                                case 4:
                                    administration.ShowAllCustomers();
                                    break;
                                case 5:
                                    followClient = false;
                                    break;
                                default:
                                    Settings.Footer("OPCION NO VALIDA");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        bool followVehicle = true;
                        while (followVehicle)
                        {
                            Settings.Header("TRANSRIWI - VEHICULOS");
                            Console.WriteLine("1. Registrar vehiculo");
                            Console.WriteLine("2. Eliminar vehiculo");
                            Console.WriteLine("3. Ver vehiculos");
                            Console.WriteLine("4. Salir");
                            Console.Write("Ingresa la opción: ");

                            byte optionVehicle = byte.Parse(Console.ReadLine());
                            switch (optionVehicle)
                            {
                                case 1:
                                    administration.AddVehicle();
                                    break;
                                case 2:
                                    administration.DeleteVehicle();
                                    break;
                                case 3:
                                    administration.ShowAllVehicles();
                                    break;
                                case 4:
                                    followVehicle = false;
                                    break;
                                default:
                                    Settings.Footer("OPCION NO VALIDA");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        bool followStatistics = true;
                        while (followStatistics)
                        {
                            Settings.Header("TRANSRIWI - ESTADISTICAS");
                            Console.WriteLine("1. Ver todos los clientes");
                            Console.WriteLine("2. Ver todos los conductores");
                            Console.WriteLine("3. Ver todos los usuarios mayores de 30 años");
                            Console.WriteLine("4. Ver los conductores ordenados por años de experiencia");
                            Console.WriteLine("5. Ver todos los clientes que prefieren pagar por tarjeta");
                            Console.WriteLine("6. Ver todos los conductores con licencia 'A2'");
                            Console.WriteLine("7. Salir");
                            Console.Write("Ingresa la opción: ");

                            byte optionStatistics = byte.Parse(Console.ReadLine());
                            switch (optionStatistics)
                            {
                                case 1:
                                    administration.ShowAllCustomers();
                                    break;
                                case 2:
                                    administration.ShowAllDrivers();
                                    break;
                                case 3:
                                    administration.UserOverThirty();
                                    break;
                                case 4:
                                    administration.SortDriversByDrivingExperience();
                                    break;
                                case 5:
                                    administration.UserPayWithCard();
                                    break;
                                case 6:
                                    administration.UserWithLicenseA2();
                                    break;
                                case 7:
                                    followStatistics = false;
                                    break;
                                default:
                                    Settings.Footer("OPCION NO VALIDA");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        follow = false;
                        break;
                    default:
                        Settings.Footer("OPCION NO VALIDA");
                        break;
                }
            }
        }
    }
}
