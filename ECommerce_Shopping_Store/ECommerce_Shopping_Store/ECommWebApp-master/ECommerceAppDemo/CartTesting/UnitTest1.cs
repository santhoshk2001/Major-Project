using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ECommerceAppDemo.API.Controllers;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Services;
using Moq;
using Xunit;

namespace ECommerceAppDemo.Tests
{
    public class CartControllerTests
    {
        private readonly Mock<CartService> _mockCartService;
        private readonly CartController _controller;

        public CartControllerTests()
        {
            _mockCartService = new Mock<CartService>();
            _controller = new CartController();
        }

        [Fact]
        public void GetCartById_ReturnsOkResult_WithCart()
        {
            // Arrange
            var cartId = 1;
            var cart = new Cart { CartId = cartId };
            _mockCartService.Setup(service => service.GetCartById(cartId)).Returns(cart);

            // Act
            var result = _controller.GetCartById(cartId) as OkNegotiatedContentResult<Cart>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cartId, result.Content.CartId);
        }

        [Fact]
        public void GetCartById_ReturnsNotFound_WhenCartDoesNotExist()
        {
            // Arrange
            var cartId = 1;
            _mockCartService.Setup(service => service.GetCartById(cartId)).Returns((Cart)null);

            // Act
            var result = _controller.GetCartById(cartId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddToCart_ReturnsNoContent_WhenModelIsValid()
        {
            // Arrange
            var cart = new Cart { UserId = 1, PId = 1 };
            _mockCartService.Setup(service => service.AddToCartAsync(cart.UserId, cart.PId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddToCart(cart) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public async Task AddToCart_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var cart = new Cart { UserId = 1, PId = 1 };
            _controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await _controller.AddToCart(cart);

            // Assert
            Assert.IsType<InvalidModelStateResult>(result);
        }
    }
}
