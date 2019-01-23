using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyLand.Domain.Abstract;

namespace JoyLand.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ISweetRepository repository;

        public NavController(ISweetRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Sweets
                .Select(sweet => sweet.Category)
                .Distinct()
                .OrderBy(x => x);
            
            return PartialView("FlexMenu", categories);
        }
    }
}