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
    public class BankDbContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique BranchCode
            modelBuilder.Entity<Branch>()
                .HasIndex(b => b.BranchCode)
                .IsUnique();

            // One-to-One Branch - Manager
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Manager)
                .WithOne(m => m.Branch)
                .HasForeignKey<Branch>(b => b.ManagerId);

            // Many-to-Many CustomerAccount
            modelBuilder.Entity<CustomerAccount>()
                .HasKey(ca => new { ca.CustomerId, ca.AccountNumber });

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(ca => ca.CustomerId);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Account)
                .WithMany(a => a.CustomerAccounts)
                .HasForeignKey(ca => ca.AccountNumber);

            // Account -> Branch
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BranchId);

            // Transaction -> Account
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountNumber);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manager>().HasData(
                new Manager { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed@bank.com", PhoneNumber = "0100000000", HireDate = DateTime.Now }
            );

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, Name = "Cairo Main Branch", BranchCode = "CAI-01", Address = "Cairo", PhoneNumber = "02222222", ManagerId = 1 }
            );
        }
    }
}
