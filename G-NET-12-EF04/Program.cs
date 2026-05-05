using G_NET_12_EF04.models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using G_NET_12_EF04.DbContext;

namespace G_NET_12_EF04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1) Add Customer");
                Console.WriteLine("2) Open Account");
                Console.WriteLine("3) Update Account Status");
                Console.WriteLine("4) Remove Account from Customer");
                Console.WriteLine("5) List Customers");
                Console.WriteLine("0) Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;

                    case "2":
                        OpenAccount();
                        break;

                    case "3":
                        UpdateStatus();
                        break;

                    case "4":
                        RemoveAccount();
                        break;

                    case "5":
                        ListCustomers();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

        static void AddCustomer()
        {

        }

        static void OpenAccount()
        {

        }

        static void UpdateStatus()
        {

        }

        static void RemoveAccount()
        {

        }

        static void ListCustomers()
        {

        }
    }
}
