using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers
{
    [Authorize]
    public class PlanningController : Controller
    {
        private IAllCategories allCategories;
        private IAllUsers allUsers;

        public PlanningController(IAllCategories allCategories, IAllUsers allUsers)
        {
            this.allCategories = allCategories;
            this.allUsers = allUsers;
        }

        // Display the planning page with user's categories and total planned money
        public IActionResult Planning()
        {
            IQueryable<Domain.Entity.Categori> ArrCategories = allCategories.GetCategoriesByUserId(allUsers.GetUserByName(User.Identity.Name).id);
            PlanningViewModel model = new PlanningViewModel()
            {
                allCategory = ArrCategories
            };
            foreach (var el in ArrCategories)
                model.planmoney += el.bill;
            return View(model);
        }
    }
}
