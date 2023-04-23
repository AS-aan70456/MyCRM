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
    public class RecordController : Controller {

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
            if (!ModelState.IsValid) return View();

            User MeUser = allUsers.GetUserByName(User.Identity.Name);

            IQueryable<Domain.Entity.Categori> ArrCategories = allCategories.GetCategoriesByUserId(MeUser.id);

            Categori Categoy = ArrCategories.FirstOrDefault(x => x.Name == model.NameCategory);

            if (Categoy == null){
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

            if (model.IsIncome)
                MeUser.bill += model.Sum;
            else
                MeUser.bill -= model.Sum;

            Categoy.bill += model.Sum;
            allUsers.SaveUser(MeUser);
            allRecords.SaveRecords(newRecord);

            return View();
        }


    }
}
