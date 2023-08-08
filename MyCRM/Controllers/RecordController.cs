using Microsoft.AspNetCore.Authorization;
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
    public class RecordController : Controller
    {
        private IAllRecords allRecords;
        private IAllCategories allCategories;
        private IAllUsers allUsers;

        public RecordController(IAllRecords allRecords, IAllCategories allCategories, IAllUsers allUsers)
        {
            this.allRecords = allRecords;
            this.allCategories = allCategories;
            this.allUsers = allUsers;
        }

        // Display the record page
        [HttpGet]
        public IActionResult Record() => View();

        // Create a new record based on the form input
        [HttpPost]
        public IActionResult Record(RecordViewModel model)
        {
            if (!ModelState.IsValid) return View();

            User currentUser = allUsers.GetUserByName(User.Identity.Name);

            IQueryable<Domain.Entity.Categori> userCategories = allCategories.GetCategoriesByUserId(currentUser.id);

            Categori selectedCategory = userCategories.FirstOrDefault(x => x.Name == model.NameCategory);

            if (selectedCategory == null)
            {
                ModelState.AddModelError("NameCategory", "Such category does not exist");
                return View();
            }

            Record newRecord = new Record()
            {
                UserId = currentUser.id,
                NameCategory = model.NameCategory,
                DataCreate = DateTime.Now.ToString(),
                Income = model.IsIncome,
                Name = model.Discription,
                Pirse = model.Sum
            };

            if (model.IsIncome)
                currentUser.bill += model.Sum;
            else
                currentUser.bill -= model.Sum;

            selectedCategory.bill += model.Sum;
            allUsers.SaveUser(currentUser);
            allRecords.SaveRecords(newRecord);

            return View();
        }
    }
}
