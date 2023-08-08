using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        private IAllRecords allRecord;
        private IAllUsers allUsers;

        public HistoryController(IAllRecords allRecord, IAllUsers allUsers)
        {
            this.allRecord = allRecord;
            this.allUsers = allUsers;
        }

        // Display the history of records for the authenticated user
        public IActionResult History()
        {
            // Retrieve records associated with the current user and populate the view model
            IQueryable<Domain.Entity.Record> userRecords = allRecord.GetRecordsByUserId(allUsers.GetUserByName(User.Identity.Name).id);
            HistoryViewModel model = new HistoryViewModel()
            {
                Record = userRecords
            };

            return View(model);
        }
    }
}
