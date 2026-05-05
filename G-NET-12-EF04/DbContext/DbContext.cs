using G_NET_12_EF04.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using G_NET_12_EF04.DbContext;
using Microsoft.EntityFrameworkCore;


namespace G_NET_12_EF04.DbContext
{
    public class BankContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>()
                .HasKey(ca => new
                {
                    ca.CustomerId,
                    ca.AccountId
                });

            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Manager)
                .WithOne(m => m.Branch)
                .HasForeignKey<Branch>(b => b.ManagerId);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Accounts)
                .WithOne(a => a.Branch)
                .HasForeignKey(a => a.BranchId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(ca => ca.CustomerId);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Account)
                .WithMany(a => a.CustomerAccounts)
                .HasForeignKey(ca => ca.AccountId);

            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@gmail.com",
                    PhoneNumber = "01000000000",
                    HireDate = new DateTime(2020, 1, 1)
                });

            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Id = 1,
                    Name = "Cairo Branch",
                    BranchCode = "BR001",
                    Address = "Cairo",
                    PhoneNumber = "01111111111",
                    ManagerId = 1
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
