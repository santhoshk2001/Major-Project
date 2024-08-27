using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceAppDemo.API.DTOs
{
    public class HeadsetProduct
    {
        public int PID { get; set; }
        public string Category_Name { get; set; }
        public int? Category_Id { get; set; }
        public decimal? Price { get; set; }
        public string BrandName { get; set; }
        public int? Model_Year { get; set; }
        public string Headset_Type { get; set; }
        public string Headset_Connectivity { get; set; }
        public string Headset_Battery { get; set; }
        public string Headset_PowerOutput { get; set; }
        public string path_to_image { get; set; }
    }
}