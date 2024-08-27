using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAppDemo.API.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int UserId { get; set; }

        public int PId { get; set; }

        public string UName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Pincode { get; set; }

        public decimal Price { get; set; }

        public string BrandName { get; set; }

        public int Model_Year { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
