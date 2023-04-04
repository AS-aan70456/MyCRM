using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    [Authorize]
    public class HistoryController : Controller{

        private IAllRecords allRecord;
        private IAllUsers allUsers;
        public HistoryController(IAllRecords allRecord, IAllUsers allUsers) {
            this.allRecord = allRecord;
            this.allUsers = allUsers;
        }

        public IActionResult History(){
            IQueryable<Domain.Entity.Record> ArrCategories = allRecord.GetRecordsByUserId(allUsers.GetUserByName(User.Identity.Name).id);
            HistoryViewModel model = new HistoryViewModel() {
                Record = ArrCategories
            };

            return View(model);
        }
    }
}
