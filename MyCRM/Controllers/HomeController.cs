﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    public class HomeController : Controller{

        public IActionResult Home() {
            return View();
        }

    }
}
