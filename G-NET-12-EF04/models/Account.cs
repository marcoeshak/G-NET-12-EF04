using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static G_NET_12_EF04.models.Enums;
namespace G_NET_12_EF04.models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal Balance { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
