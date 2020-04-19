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
using Microsoft.AspNetCore.Http.Extensions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Exceptions;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
#if RELEASE
            string returnUrl = "Create";
            string state = "Yinqingwen19690219";

            string Oauthurl = OAuthApi.GetAuthorizeUrl(AppId,
                                                       Url.Action("UserInfoCallBack", "Yd", new { @returnUrl = returnUrl.UrlEncode() }, protocol: Request.Scheme),
                                                       state,
                                                       OAuthScope.snsapi_userinfo);
            return Redirect(Oauthurl);
#endif
#if DEBUG
            return View();
#endif
        }

        public IActionResult Test()
        {
            string returnUrl = "~" + Url.Action().ToString(); //Url.Action(); //Request.GetDisplayUrl();
            string state = "Yinqingwen19690219";
            string Oauthurl = OAuthApi.GetAuthorizeUrl(AppId,
                                                       Url.Action("UserInfoCallBack", "yd", new { @returnUrl = returnUrl.UrlEncode() }, protocol: Request.Scheme),
                                                       state,
                                                       OAuthScope.snsapi_userinfo);
            return Redirect(Oauthurl);
        }

        public IActionResult UserInfoCallBack(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != "Yinqingwen19690219")
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                //建议用完之后就清空，将其一次性使用
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            OAuthAccessTokenResult result = null;

            //通过，用code换取access_token
            try
            {
                result = OAuthApi.GetAccessToken(AppId, AppSecret, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
            try
            {
                OAuthUserInfo userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                return View(returnUrl.UrlDecode(), userInfo);
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
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