using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace G_NET_12_EF04.models
{
    public class Enums
    {
        public enum CustomerType
        {
            Individual,
            Business
        }

        public enum AccountType
        {
            Savings,
            Current,
            Business
        }

        public enum OwnershipType
        {
            Primary,
            CoHolder
        }

        public enum AccountStatus
        {
            Active,
            Closed
        }

        public enum TransactionType
        {
            Deposit,
            Withdrawal,
            Transfer,
            Payment
        }
    }
}
