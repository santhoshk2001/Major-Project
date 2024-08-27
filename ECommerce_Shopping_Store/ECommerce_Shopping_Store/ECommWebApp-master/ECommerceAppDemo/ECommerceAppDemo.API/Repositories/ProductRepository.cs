using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.DTOs;



namespace ECommerceAppDemo.API.Repositories
{
    public class ProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository()
        {
            _context = new ECommerceDbContext();
        }

        public DataTable GetFilteredDataByCategory(string categoryName)
    {
        DataTable dataTable = new DataTable();

        using (SqlConnection conn = new SqlConnection(_context.Database.Connection.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetProductsByCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Fill the DataTable with data from the stored procedure
                adapter.Fill(dataTable);
        }

        return dataTable;
    }


        public IEnumerable<object> GetProductsByCategory(string categoryName)
        {
            DataTable dataTable = GetFilteredDataByCategory(categoryName);
            var products = new List<object>();

            foreach (DataRow row in dataTable.Rows)
            {
                switch (categoryName)
                {
                    case "Television":
                        products.Add(new TelevisionProduct
                        {
                            PID = row.Field<int>("PID"),
                            Category_Name = row.Field<string>("Category_Name"),
                            Category_Id = row.Field<int?>("Category_Id"),
                            Price = row.Field<decimal?>("Price"),
                            BrandName = row.Field<string>("BrandName"),
                            Model_Year = row.Field<int?>("Model_Year"),
                            Television_Size = row.Field<string>("Television_Size"),
                            Television_Type = row.Field<string>("Television_Type"),
                            path_to_image = row.Field<string>("path_to_image"),
                            Television_OS = row.Field<string>("Television_OS")
                        });
                        break;

                    case "Refrigerator":
                        products.Add(new RefrigeratorProduct
                        {
                            PID = row.Field<int>("PID"),
                            Category_Name = row.Field<string>("Category_Name"),
                            Category_Id = row.Field<int?>("Category_Id"),
                            Price = row.Field<decimal?>("Price"),
                            BrandName = row.Field<string>("BrandName"),
                            Model_Year = row.Field<int?>("Model_Year"),
                            Refrigerator_Capacity = row.Field<string>("Refrigerator_Capacity"),
                            Refrigerator_Type = row.Field<string>("Refrigerator_Type"),
                            Refrigerator_Star = row.Field<int?>("Refrigerator_Star"),
                            path_to_image = row.Field<string>("path_to_image"),
                            Refrigerator_Feature = row.Field<string>("Refrigerator_Feature")
                        });
                        break;

                    case "Smartwatch":
                        products.Add(new SmartwatchProduct
                        {
                            PID = row.Field<int>("PID"),
                            Category_Name = row.Field<string>("Category_Name"),
                            Category_Id = row.Field<int?>("Category_Id"),
                            Price = row.Field<decimal?>("Price"),
                            BrandName = row.Field<string>("BrandName"),
                            Model_Year = row.Field<int?>("Model_Year"),
                            Smartwatch_DisplaySize = row.Field<string>("Smartwatch_DisplaySize"),
                            Smartwatch_DisplayType = row.Field<string>("Smartwatch_DisplayType"),
                            Smartwatch_DialShape = row.Field<string>("Smartwatch_DialShape"),
                            path_to_image = row.Field<string>("path_to_image")
                        });
                        break;

                    case "Headset":
                        products.Add(new HeadsetProduct
                        {
                            PID = row.Field<int>("PID"),
                            Category_Name = row.Field<string>("Category_Name"),
                            Category_Id = row.Field<int?>("Category_Id"),
                            Price = row.Field<decimal?>("Price"),
                            BrandName = row.Field<string>("BrandName"),
                            Model_Year = row.Field<int?>("Model_Year"),
                            Headset_Type = row.Field<string>("Headset_Type"),
                            Headset_Connectivity = row.Field<string>("Headset_Connectivity"),
                            Headset_Battery = row.Field<string>("Headset_Battery"),
                            Headset_PowerOutput = row.Field<string>("Headset_PowerOutput"),
                            path_to_image = row.Field<string>("path_to_image")
                        });
                        break;

                    case "Mobile":
                        products.Add(new MobileProduct
                        {
                            PID = row.Field<int>("PID"),
                            Category_Name = row.Field<string>("Category_Name"),
                            Category_Id = row.Field<int?>("Category_Id"),
                            Price = row.Field<decimal?>("Price"),
                            BrandName = row.Field<string>("BrandName"),
                            Model_Year = row.Field<int?>("Model_Year"),
                            Mobile_ScreenSize = row.Field<string>("Mobile_ScreenSize"),
                            Mobile_Storage = row.Field<string>("Mobile_Storage"),
                            Mobile_Processor = row.Field<string>("Mobile_Processor"),
                            Mobile_Battery = row.Field<string>("Mobile_Battery"),
                            Mobile_ScreenType = row.Field<string>("Mobile_ScreenType"),
                            path_to_image = row.Field<string>("path_to_image")
                        });
                        break;

                    default:
                        throw new ArgumentException("Invalid category name.");
                }
            }

            return products;
        }

        // Your existing GetFilteredDataByCategory method...
    }
}