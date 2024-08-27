using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceAppDemo.API.DTOs
{
    public class MobileProduct
    {
        public int PID { get; set; }
        public string Category_Name { get; set; }
        public int? Category_Id { get; set; }
        public decimal? Price { get; set; }
        public string BrandName { get; set; }
        public int? Model_Year { get; set; }
        public string Mobile_ScreenSize { get; set; }
        public string Mobile_Storage { get; set; }
        public string Mobile_Processor { get; set; }
        public string Mobile_Battery { get; set; }
        public string Mobile_ScreenType { get; set; }
        public string path_to_image { get; set; }
    }

}