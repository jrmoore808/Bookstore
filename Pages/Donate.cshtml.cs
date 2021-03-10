using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Class for Donate.cshtml. Sets up adding and deleting items from the cart.
namespace Bookstore.Pages
{
    public class DonateModel : PageModel
    {
        private IBooksRepository repository;
        public DonateModel (IBooksRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookID);
            Cart.AddItem(book, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveItem(Cart.Lines.First(cl => cl.Book.BookId == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
