using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static G_NET_12_EF04.models.Enums;
namespace G_NET_12_EF04.models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string AccountNumber { get; set; }
        public Account Account { get; set; }

        public DateTime OwnershipStartDate { get; set; }
        public OwnershipType OwnershipType { get; set; }
        public AccountStatus Status { get; set; }
    }
}
