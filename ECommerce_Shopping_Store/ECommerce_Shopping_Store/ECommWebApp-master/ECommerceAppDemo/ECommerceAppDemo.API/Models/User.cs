using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceAppDemo.API.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string UName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Pincode { get; set; }
    }
}