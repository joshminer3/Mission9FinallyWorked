﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9.Models;
using Mission9.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class HomeController : Controller
    {

        private BookstoreProjectRepository repo;


        public HomeController (BookstoreProjectRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksVM
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };


            return View(x);
        }
      
    }
}
