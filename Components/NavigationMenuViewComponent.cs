using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ViewComponents for the filters menu. Data used in Views/Shared/Components/Navigation/Default.cshtml
namespace Bookstore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBooksRepository repository;
        public NavigationMenuViewComponent (IBooksRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
