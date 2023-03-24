using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    public class RecordController : Controller{

        public IActionResult Record(){
            return View();
        }
    }
}
