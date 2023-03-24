using Microsoft.AspNetCore.Mvc;
using MyCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    public class ServerController : Controller{
        [HttpGet]
        public IActionResult DataTime(){
            return View();
        }
    }
}
