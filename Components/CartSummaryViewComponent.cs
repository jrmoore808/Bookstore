using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
namespace SportsStore.Components
//Class taken from chapter 9 of the Freeman textbook to display cart info on the _Layout.cshtml page. See Views/Shared/Components/CartSummaryViewComonent/Default.cshtml.
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}