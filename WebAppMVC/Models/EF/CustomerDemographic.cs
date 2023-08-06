using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models.EF
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            Customers = new HashSet<Customer>();
        }
        [Key]
        public string CustomerTypeId { get; set; } = null!;
        public string? CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
