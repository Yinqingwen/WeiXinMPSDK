using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Senparc.Weixin.Sample.NetCore3.Models;
using YDService;

namespace Senparc.Weixin.Sample.NetCore3.Controllers.Client
{
    [Area("Client")]
    [Route("Client/[controller]/[action]")]
    public class YdController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchYd(string id)
        {
            YdInfo ydInfo = new YdInfo();

            ydInfo = ydInfo.GetRemoteYdInfo("", "", id);

            return Json(ydInfo, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
        }
    }
}