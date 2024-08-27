using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ECommerceAppDemo.API.Data;

namespace ECommerceAppDemo.API.Repositories
{
    public class OrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(int productId, int quantity)
        {
            try
            {
                var connectionString = _context.Database.Connection.ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateOrder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    conn.Open();
                    Console.WriteLine("Executing Store Procedure.....");
                    cmd.ExecuteNonQuery();
                    // Log success
                    Console.WriteLine("Store Procedure executed successfully.");
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error while creating order: {ex.Message}");
                throw;
            }
        }
    }
}