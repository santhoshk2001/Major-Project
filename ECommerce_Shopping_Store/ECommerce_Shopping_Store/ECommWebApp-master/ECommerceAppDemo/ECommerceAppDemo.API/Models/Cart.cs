using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceAppDemo.API.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int UserId { get; set; }

        public int PId { get; set; }

        public string UName { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public string Pincode { get; set; }

        public decimal Price { get; set; }

        public string BrandName { get; set; }

        public int Model_Year { get; set; }

        public int Quantity { get; set; }

        // Navigation properties
        //public virtual Users User { get; set; }
        //public virtual Product Product { get; set; }
    }
}