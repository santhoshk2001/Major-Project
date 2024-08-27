using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAppDemo.API.Repositories
{
    public class CartRepository
    {
        private readonly ECommerceDbContext _context;

        public CartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public Cart GetCartById(int cartId)
        {
            return _context.Carts.FirstOrDefault(c => c.CartId == cartId);
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _context.Carts.ToList();
        }

        public async Task AddToCartAsync(int userId, int pId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            var pIdParam = new SqlParameter("@PId", pId);

            await _context.Database.ExecuteSqlCommandAsync(
                "EXEC AddToCart @UserId, @PId",
                userIdParam,
                pIdParam);
        }

        public void UpdateCart(Cart cart)
        {
            var existingCart = _context.Carts.Find(cart.CartId);

            if (existingCart != null)
            {
                existingCart.Quantity = cart.Quantity;
                existingCart.Price = cart.Price;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Cart item not found.");
            }
        }

        public void ClearAllCarts()
        {
            _context.Database.ExecuteSqlCommand(
                "EXEC ClearAllCarts"
            );
        }

        public void CopyCartToOrderDetails()
        {
            _context.Database.ExecuteSqlCommand(
                "EXEC CopyCartToOrderDetails"
            );
        }

        public void UpdateCart(int cartId, int quantity)
        {
            var cartIdParam = new SqlParameter("@CartId", cartId);
            var quantityParam = new SqlParameter("@Quantity", quantity);

            _context.Database.ExecuteSqlCommand("UpdateCartQuantity @CartId, @Quantity", cartIdParam, quantityParam);
        }


    }
}
