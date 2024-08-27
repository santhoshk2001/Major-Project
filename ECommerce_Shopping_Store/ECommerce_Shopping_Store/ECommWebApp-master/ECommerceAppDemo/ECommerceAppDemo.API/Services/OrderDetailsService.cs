// File: Services/OrderDetailsService.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;

namespace ECommerceAppDemo.API.Services
{
    public class OrderDetailsService
    {
        private readonly OrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(OrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return _orderDetailsRepository.GetAllOrderDetails();
        }

        public OrderDetails GetOrderDetailsById(int orderId)
        {
            return _orderDetailsRepository.GetOrderDetailsById(orderId);
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            _orderDetailsRepository.AddOrderDetails(orderDetails);
        }
    }
}
