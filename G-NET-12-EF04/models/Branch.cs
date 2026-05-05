using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace G_NET_12_EF04.models
{
          public class Branch
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string BranchCode { get; set; }

            public string Address { get; set; }

            public string PhoneNumber { get; set; }

            public int ManagerId { get; set; }

            public Manager Manager { get; set; }

            public ICollection<Account> Accounts { get; set; }
                = new HashSet<Account>();
        }
    }
