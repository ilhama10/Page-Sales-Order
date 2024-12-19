using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Customer
    {
        [Key]
        public int COM_CUSTOMER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string CUSTOMER_NAME { get; set; }
    }
}