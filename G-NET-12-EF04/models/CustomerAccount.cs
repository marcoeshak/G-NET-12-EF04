using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF04.models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public DateTime OwnershipStartDate { get; set; }

        public string OwnershipType { get; set; }

        public bool AccountStatus { get; set; }
    }
}
