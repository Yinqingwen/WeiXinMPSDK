using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Senparc.Weixin.Sample.NetCore3.Models;
using System.Web;
using YDService;
using System.Text;
using System.Xml;
using Senparc.Weixin.Sample.NetCore3.Areas.Client.Help;

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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //链接远程Webservice
            //string url = "http://123.56.190.161:40/service.asmx";
            string method = "Add_Info";

            string result = string.Empty;
            string param = string.Empty;

            param = String.Format("RecTel={0}&Recer={1}&Varo={2}&Num={3}&Ds={4}&City={5}&Sender={6}&SendTel={7}", collection["rectel"],
                                                                                                                        collection["recer"],
                                                                                                                        collection["varo"],
                                                                                                                        collection["num"],
                                                                                                                        collection["ds"],
                                                                                                                        collection["city"],
                                                                                                                        collection["sender"],
                                                                                                                        collection["sendtel"]);
            result = WebServiceCall.CallPostMethod(param, method);

            FydInfo fydInfo = new FydInfo();
            fydInfo = fydInfo.GetFydInfo(result);
                        
            return View("CreateMsg",fydInfo);
        }
    }
}