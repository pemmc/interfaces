using System;
using System.Globalization;

using Interface.Entities;
using Interface.Services;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("194. Interfaces");
            Console.WriteLine("===============");
            Console.WriteLine();

            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");

            string model = Console.ReadLine();

            Console.WriteLine("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start  = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR").DateTimeFormat);

            Console.WriteLine("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR").DateTimeFormat);

            Console.WriteLine("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), new CultureInfo("pt-BR").NumberFormat);

            Console.WriteLine("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), new CultureInfo("pt-BR").NumberFormat);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("Invoice: ");
            Console.WriteLine(carRental.Invoice);

        }
    }
}
