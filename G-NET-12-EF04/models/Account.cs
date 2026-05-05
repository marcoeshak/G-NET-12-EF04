using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
namespace G_NET_12_EF04.models
{
    public class Account
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public string AccountType { get; set; }

        public DateTime OpeningDate { get; set; }

        public decimal Balance { get; set; }

        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
            = new HashSet<CustomerAccount>();

        public ICollection<Transaction> Transactions { get; set; }
            = new HashSet<Transaction>();
    }
}
