﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Controllers{
    public class CategoriesController : Controller{
        
        public IActionResult Categories(){
            return View();
        }

       
    }
}