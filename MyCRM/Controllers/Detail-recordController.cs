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
    public class Detail_recordController : Controller
    {
        private IAllRecords allRecords;

        public Detail_recordController(IAllRecords allRecords)
        {
            this.allRecords = allRecords;
        }

        // Display details of a specific record by its ID
        [Route("Detail_record/Detail_record/{ID}")]
        public IActionResult Detail_record(int ID)
        {
            // Retrieve the record using its ID and populate the view model
            Record_deteilViewModel model = new Record_deteilViewModel()
            {
                Record = allRecords.GetRecordsById(ID)
            };

            return View(model);
        }
    }
}
