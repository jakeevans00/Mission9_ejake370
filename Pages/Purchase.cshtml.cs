using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_ejake370.Infrastructure;
using Mission9_ejake370.Models;

namespace Mission9_ejake370.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public PurchaseModel(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public Cart user_cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            user_cart = HttpContext.Session.GetJson<Cart>("user_cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            user_cart = HttpContext.Session.GetJson<Cart>("user_cart") ?? new Cart();
            user_cart.AddItem(b, 1);

            HttpContext.Session.SetJson("user_cart", user_cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

