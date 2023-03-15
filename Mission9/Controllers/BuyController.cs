using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class BuyController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Cart cart { get; set; }

        public BuyController (IOrderRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Buy());
        }

        [HttpPost]
        public IActionResult Checkout(Buy order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();
                repo.Saveorder(order);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
