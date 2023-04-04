using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Domain.Entity;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    [Authorize]
    public class RecordController : Controller{

        private IAllRecords allRecords;
        private IAllCategories allCategories;
        private IAllUsers allUsers;

        public RecordController(IAllRecords allRecords, IAllCategories allCategories, IAllUsers allUsers) {
            this.allRecords = allRecords;
            this.allCategories = allCategories;
            this.allUsers = allUsers;
        }


        [HttpGet]
        public IActionResult Record() => View();

        [HttpPost]
        public IActionResult Record(RecordViewModel model) {
            IQueryable<Domain.Entity.Categori> ArrCategories = allCategories.GetCategoriesByUserId(allUsers.GetUserByName(User.Identity.Name).id);
            if (!ModelState.IsValid) return View();
            if (model.IsIncome == null) model.IsIncome = false;
            if (ArrCategories.FirstOrDefault(x => x.Name == model.NameCategory) == null){
                ModelState.AddModelError("NameCategory", "Такой катигории нет");
                return View();
            }
            Record newRecord = new Record() {
                UserId = allUsers.GetUserByName(User.Identity.Name).id,
                NameCategory = model.NameCategory,
                DataCreate = DateTime.Now.ToString(),
                Income = model.IsIncome,
                Name = model.Discription,
                Pirse = model.Sum
            };

            allRecords.SaveRecords(newRecord);

            return View();
        }


    }
}
