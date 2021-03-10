using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        //Sets _logger and _repository for index paging method
        private readonly ILogger<HomeController> _logger;
        private IBooksRepository _repository;
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Builds and passes index view with paging ranges
        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.BookId)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize)
                ,
                PageInfo = new PageInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _repository.Books.Count() : _repository.Books.Where (x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
