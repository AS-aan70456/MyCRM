using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Domain.Entity;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        // Interface for categories repository
        public IAllCategories allCategories;
        // Interface for users repository
        public IAllUsers allUsers;

        // Constructor to inject categories and users repositories
        public CategoriesController(IAllCategories allCategories, IAllUsers allUsers)
        {
            this.allCategories = allCategories;
            this.allUsers = allUsers;
        }

        // Display the categories view
        [HttpGet]
        public IActionResult Categories() => View(new CategoryViewModel());

        // Handle creation of a new category
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel model)
        {
            if (model.CreateCategoryName == null || model.CreateCategoryName == "")
                return Redirect("/Categories");
            if (model.CreateCategoryLimit < 0)
                return Redirect("/Categories");
            if (allCategories.GetCategoriesByName(model.CreateCategoryName) != null)
            {
                ModelState.AddModelError("NameCategory", "Category already exists");
                return Redirect("/Categories");
            }

            // Create a new category entity and save it
            Categori newCategori = new Categori()
            {
                UserId = allUsers.GetUserByName(User.Identity.Name).id,
                Limit = model.CreateCategoryLimit,
                Name = model.CreateCategoryName,
                bill = 0
            };
            allCategories.SaveCategories(newCategori);
            return Redirect("/Categories");
        }

        // Handle editing of an existing category
        [HttpPost]
        public IActionResult EditCategory(CategoryViewModel model)
        {
            if (model.EditCategoryName == null || model.EditCategoryName == "")
                return Redirect("/Categories");
            if (model.EditCategoryLimit < 0)
                return Redirect("/Categories");
            if (allCategories.GetCategoriesByName(model.EditCategoryName) == null)
                return Redirect("/Categories");

            // Update the category's limit and save changes
            Categori editCategori = allCategories.GetCategoriesByName(model.EditCategoryName);
            editCategori.Limit = model.EditCategoryLimit;
            allCategories.SaveCategories(editCategori);

            return Redirect("/Categories");
        }
    }
}
