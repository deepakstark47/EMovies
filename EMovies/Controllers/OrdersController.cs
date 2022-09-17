using EMovies.Cart;
using EMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EMovies.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly MovieDbContext _context;


        public OrdersController(ShoppingCart shoppingCart, MovieDbContext context)
        {
            _shoppingCart = shoppingCart;
            _context = context;
        }



        public async Task<IActionResult> Index()
        {

            string userId = "";

            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.UserId == userId).ToListAsync();

            
            return View(orders);
            
        }





        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);


        }


        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _context.Movies.Include(m => m.Director).Include(m => m.Category).Include(m => m.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.MovieId == id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _context.Movies.Include(m => m.Director).Include(m => m.Category).Include(m => m.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.MovieId == id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.MovieId,
                    OrderId = order.Id,
                    Price = item.Movie.MoviePrice
                };
                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();





            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }





    }
}
