﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Domasno_2.Controllers
{
    public class WebConfigController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}