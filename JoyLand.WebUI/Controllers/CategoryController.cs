using JoyLand.Domain.Abstract;
using JoyLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyLand.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;
        public CategoryController(ICategoryRepository repo)
        {
            repository = repo;
        }
        // GET: Category
        public ViewResult Index()
        {
            return View(repository.Categorys);
        }
        public ViewResult Edit(int Id)
        {
            Category category = repository.Categorys
                .FirstOrDefault(g => g.Id == Id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", category.CategoryName);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Category deletedCategory = repository.DeleteCategory(Id);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" была удалена",
                    deletedCategory.CategoryName);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            return View("Edit", new Category());
        }
    }
}