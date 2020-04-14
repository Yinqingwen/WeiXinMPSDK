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

        public IActionResult GetPhoneInfo(string id)
        {
            PhoneInfo phoneInfo = new PhoneInfo();

            phoneInfo = phoneInfo.GetPhoneInfo(id);

            return Json(phoneInfo, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
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

            //Webservice提供的提交字符串
            //Company=string&RecTel=string&Recer=string&Varo=string&Num=string&Ds=string&City=string&Sender=string&SendTel=string&Baojia=string&Style=string
            param = String.Format("Company={0}&RecTel={1}&Recer={2}&Varo={3}&Num={4}&Ds={5}&City={6}&Sender={7}&SendTel={8}&Baojia={9}&Style={10}", 
                                   "胜京物流",
                                   collection["rectel"],
                                   collection["recer"],
                                   collection["varo"],
                                   collection["num"],
                                   collection["ds"],
                                   collection["city"],
                                   collection["sender"],
                                   collection["sendtel"],
                                   collection["baojia"],
                                   collection["style"]);
            result = WebServiceCall.CallPostMethod(param, method);

            FydInfo fydInfo = new FydInfo();
            fydInfo = fydInfo.GetFydInfo(result);
            
            return Json(fydInfo, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
        }
    }
}