using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class SalesOrder
    {
        [Key]
        public long SO_ORDER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string ORDER_NO { get; set; }

        [Required]
        public DateTime ORDER_DATE { get; set; }

        [Required]
        public int COM_CUSTOMER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ADDRESS { get; set; }
    }
}