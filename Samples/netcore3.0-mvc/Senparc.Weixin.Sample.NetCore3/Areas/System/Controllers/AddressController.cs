﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Senparc.Weixin.Sample.NetCore3.Areas.System.Controllers
{
    [Area("System")]
    [Route("System/[controller]/[action]")]
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
