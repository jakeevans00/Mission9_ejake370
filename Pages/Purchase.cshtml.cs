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
        public PurchaseModel(IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            user_cart = c;
        }
        public Cart user_cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            user_cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            user_cart.RemoveItem(user_cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage (  new {ReturnUrl = returnUrl});
        }
    }
}

