using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyLand.Domain.Abstract;
using JoyLand.Domain.Entities;

namespace JoyLand.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ISweetRepository repository;
        public AdminController (ISweetRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index ()
        {
            return View(repository.Sweets);
        }

        public ViewResult Edit(int Id)
        {
            Sweet sweet = repository.Sweets
                .FirstOrDefault(g => g.Id == Id);
            return View(sweet);
        }

        [HttpPost]
        public ActionResult Edit(Sweet sweet, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    sweet.ImageMimeType = image.ContentType;
                    sweet.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(sweet.ImageData, 0, image.ContentLength);
                }
                repository.SaveSweet(sweet);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", sweet.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(sweet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Sweet deletedSweet = repository.DeleteSweet(Id);
            if (deletedSweet != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" была удалена",
                    deletedSweet.Name);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            return View("Edit", new Sweet());
        }
    }
}