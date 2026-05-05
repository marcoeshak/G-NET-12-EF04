using G_NET_12_EF04.models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using G_NET_12_EF04.DbContext;


namespace G_NET_12_EF04

{
    using G_NET_12_EF04.DbContext;
    using G_NET_12_EF04.models;
    using Microsoft.EntityFrameworkCore;

      internal class Program
      {

BankContext context = new BankContext();

    bool exit = false;

while (!exit)
{
    Console.Clear();

    Console.WriteLine("1- Add Customer");
    Console.WriteLine("2- Open Account");
    Console.WriteLine("3- Update Account Status");
    Console.WriteLine("4- Remove Account From Customer");
    Console.WriteLine("5- List Customers");
    Console.WriteLine("0- Exit");

    Console.Write("Choose: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid Input");
        Console.ReadKey();
        continue;
    }

switch (choice)
{
    case 1:
        {
            Customer customer = new Customer();

            Console.Write("Full Name: ");
            customer.FullName = Console.ReadLine();

            Console.Write("National ID: ");
            customer.NationalId = Console.ReadLine();

            Console.Write("DOB: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                Console.WriteLine("Invalid Date");
                Console.ReadKey();
                break;
            }
            customer.DOB = dob;

            Console.Write("Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Phone: ");
            customer.PhoneNumber = Console.ReadLine();

            Console.Write("Address: ");
            customer.Address = Console.ReadLine();

            Console.Write("Customer Type: ");
            customer.CustomerType = Console.ReadLine();

            context.Customers.Add(customer);
            context.SaveChanges();

            Console.WriteLine("Customer Added");
            Console.ReadKey();
            break;
        }

    case 2:
        {
            Console.Write("Account Number: ");
            string accNumber = Console.ReadLine();

            Console.Write("Account Type: ");
            string accType = Console.ReadLine();

            Console.Write("Branch Id: ");
            if (!int.TryParse(Console.ReadLine(), out int branchId))
            {
                Console.WriteLine("Invalid Branch Id");
                Console.ReadKey();
                break;
            }

            var branch = context.Branches.Find(branchId);
            if (branch == null)
            {
                Console.WriteLine("Branch Not Found");
                Console.ReadKey();
                break;
            }

            Console.Write("Customer Id: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer Id");
                Console.ReadKey();
                break;
            }

            var customerExist = context.Customers.Find(customerId);
            if (customerExist == null)
            {
                Console.WriteLine("Customer Not Found");
                Console.ReadKey();
                break;
            }

            Account account = new Account
            {
                AccountNumber = accNumber,
                AccountType = accType,
                OpeningDate = DateTime.Now,
                Balance = 0,
                BranchId = branchId
            };

            context.Accounts.Add(account);
            context.SaveChanges();

            CustomerAccount ca = new CustomerAccount
            {
                CustomerId = customerId,
                AccountId = account.Id,
                OwnershipStartDate = DateTime.Now,
                OwnershipType = "Primary",
                AccountStatus = true
            };

            context.CustomerAccounts.Add(ca);
            context.SaveChanges();

            Console.WriteLine("Account Opened");
            Console.ReadKey();
            break;
        }

    case 3:
        {
            Console.Write("Account Id: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId))
                break;

            Console.Write("Customer Id: ");
            if (!int.TryParse(Console.ReadLine(), out int custId))
                break;

            var customerAcc = context.CustomerAccounts
                .FirstOrDefault(c => c.AccountId == accountId && c.CustomerId == custId);

            if (customerAcc == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                customerAcc.AccountStatus = !customerAcc.AccountStatus;
                context.SaveChanges();
                Console.WriteLine("Status Updated");
            }

            Console.ReadKey();
            break;
        }

    case 4:
        {
            Console.Write("Account Id: ");
            int.TryParse(Console.ReadLine(), out int accId);

            Console.Write("Customer Id: ");
            int.TryParse(Console.ReadLine(), out int cId);

            var removeObj = context.CustomerAccounts
                .FirstOrDefault(c => c.AccountId == accId && c.CustomerId == cId);

            if (removeObj == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                context.CustomerAccounts.Remove(removeObj);
                context.SaveChanges();
                Console.WriteLine("Removed");
            }

            Console.ReadKey();
            break;
        }

    case 5:
        {
            var customers = context.Customers
                .Include(c => c.CustomerAccounts)
                .ThenInclude(ca => ca.Account)
                .ToList();

            foreach (var item in customers)
            {
                Console.WriteLine($"Customer: {item.FullName}");

                foreach (var acc in item.CustomerAccounts)
                {
                    Console.WriteLine($"Account Number: {acc.Account?.AccountNumber}");
                }

                Console.WriteLine("----------------");
            }

            Console.ReadKey();
            break;
        }

    case 0:
        exit = true;
        break;
}
}


      }
}

