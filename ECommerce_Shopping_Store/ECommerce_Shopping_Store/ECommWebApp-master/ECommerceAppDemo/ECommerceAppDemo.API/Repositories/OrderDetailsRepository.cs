// File: Repositories/OrderDetailsRepository.cs
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;

namespace ECommerceAppDemo.API.Repositories
{
    public class OrderDetailsRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderDetailsRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetails GetOrderDetailsById(int orderId)
        {
            return _context.OrderDetails.Find(orderId);
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            _context.SaveChanges();
        }
    }
}
