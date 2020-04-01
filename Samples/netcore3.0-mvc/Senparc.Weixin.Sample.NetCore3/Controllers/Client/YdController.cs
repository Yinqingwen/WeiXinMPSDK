using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Senparc.Weixin.Sample.NetCore3.Controllers.Client
{
    [Area("Client")]
    public class YdController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}