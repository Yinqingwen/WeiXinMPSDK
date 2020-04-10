using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Senparc.Weixin.Sample.NetCore3.Controllers
{
    public class SettingController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Company()
        {
            return View();
        }
    }
}