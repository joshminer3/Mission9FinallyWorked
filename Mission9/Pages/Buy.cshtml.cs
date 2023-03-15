using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9.Infrastructure;
using Mission9.Models;

namespace Mission9.Pages
{

    public class BuyModel : PageModel
    {
        private BookstoreProjectRepository repo { get; set; }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public BuyModel(BookstoreProjectRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookid, string returnUrl)
        {
            cart.RemoveBook(cart.Items.First(x => x.Book.BookId == bookid).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
