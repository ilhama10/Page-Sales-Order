using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class OrderItem
    {
        [Key]
        public long SO_ITEM_ID { get; set; }

        [Required]
        public long SO_ORDER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ITEM_NAME { get; set; }

        [Required]
        public int QUANTITY { get; set; }

        [Required]
        public double PRICE { get; set; }
    }
}