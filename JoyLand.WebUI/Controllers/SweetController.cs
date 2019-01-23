using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyLand.Domain.Abstract;
using JoyLand.Domain.Entities;
using JoyLand.WebUI.Models;

namespace JoyLand.WebUI.Controllers
{
    public class SweetController : Controller
    {
        private ISweetRepository repository;
        public int pageSize = 4;
        public SweetController(ISweetRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, string brand, string countryOfOrigin, string searchString, int page = 1)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                SweetsListViewModel model = new SweetsListViewModel
                {
                    Sweets = repository.Sweets
                .Where(p => category == null || p.Category == category)
                .Where(sweet => sweet.Name.Contains(searchString))
                .OrderBy(sweet => sweet.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItens = category == null ?
                repository.Sweets.Count() :
                repository.Sweets.Where(sweet => sweet.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
            }
            else
            {
                SweetsListViewModel model = new SweetsListViewModel
                {
                    Sweets = repository.Sweets
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(sweet => sweet.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItens = category == null ?
                    repository.Sweets.Count() :
                    repository.Sweets.Where(sweet => sweet.Category == category).Count()
                    },
                    CurrentCategory = category
                };
                return View(model);
            }
        }

        public FileContentResult GetImage(int Id)
        {
            Sweet sweet = repository.Sweets
                .FirstOrDefault(g => g.Id == Id);

            if (sweet != null)
            {
                return File(sweet.ImageData, sweet.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}