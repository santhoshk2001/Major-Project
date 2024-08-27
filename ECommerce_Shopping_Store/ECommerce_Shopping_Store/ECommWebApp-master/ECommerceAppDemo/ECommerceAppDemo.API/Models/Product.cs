using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceAppDemo.API.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }
        public string Category_Name { get; set; }
        public int? Category_Id { get; set; }
        public decimal? Price { get; set; }
        public string BrandName { get; set; }
        public int? Model_Year { get; set; }
        public string Television_Size { get; set; }
        public string Television_Type { get; set; }
        public string Television_OS { get; set; }
        public string Refrigerator_Capacity { get; set; }
        public string Refrigerator_Type { get; set; }
        public int? Refrigerator_Star { get; set; }
        public string Refrigerator_Feature { get; set; }
        public string Smartwatch_DisplaySize { get; set; }
        public string Smartwatch_DisplayType { get; set; }
        public string Smartwatch_DialShape { get; set; }
        public string Headset_Type { get; set; }
        public string Headset_Connectivity { get; set; }
        public string Headset_Battery { get; set; }
        public string Headset_PowerOutput { get; set; }
        public string Mobile_ScreenSize { get; set; }
        public string Mobile_Storage { get; set; }
        public string Mobile_Processor { get; set; }
        public string Mobile_Battery { get; set; }
        public string Mobile_ScreenType { get; set; }
        public string path_to_image { get; set; }
    }
}