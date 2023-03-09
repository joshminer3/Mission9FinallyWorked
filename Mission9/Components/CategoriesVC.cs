using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Components
{
    public class CategoriesVC :ViewComponent
    {
        private BookstoreProjectRepository repo { get; set; }

        public CategoriesVC (BookstoreProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
