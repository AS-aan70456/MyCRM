using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    [Authorize]
    public class ProfileController : Controller{

        public IActionResult Profile(){
            return View();
        }
    }
}
