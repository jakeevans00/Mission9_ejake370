using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_ejake370.Models;

namespace Mission9_ejake370.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public CategoriesViewComponent (IBookstoreRepository tmp)
        {
            repo = tmp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];
            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
