using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Sample.NetCore3.Areas.Client.Help;
using Senparc.Weixin.Sample.NetCore3.Areas.Client.Models;
using Senparc.Weixin.Sample.NetCore3.Controllers;
using System;

namespace Senparc.Weixin.Sample.NetCore3.Areas.Client.Controllers
{
    [Area("Client")]
    [Route("Client/[controller]/[action]/{id?}")]
    public class UserController : BaseController
    {
        public ActionResult GetUser(string id)
        {
            UserInfo result = new UserInfo();
            result = result.GetUserInfo(id);

            return Json(result, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
        }

        /// <summary>
        ///  根据用户微信OpenID注册
        /// </summary>
        /// <returns></returns>
        // GET: User/Create
        public ActionResult Create()
        {
            string returnUrl = "Create";
            string state = "Yinqingwen19690219";

            string Oauthurl = OAuthApi.GetAuthorizeUrl(AppId,
                                                       Url.Action("UserInfoCallBack", "User", new { @returnUrl = returnUrl.UrlEncode() }, protocol: Request.Scheme),
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

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //链接远程Webservice
            //string url = "http://123.56.190.161:40/service.asmx";
            string method = "WX_EditCust";

            string result = string.Empty;
            string param = string.Empty;

            string openid = (collection["openid"].ToString().IsNullOrWhiteSpace()) ? "om1eLs8Xfp3ELJIwsFYb6NRNF9U8" : collection["openid"].ToString(); //om1eLs8Xfp3ELJIwsFYb6NRNF9U8
            //Webservice提供的提交字符串
            //Company=string&Wxid=string&Name=string&CellPhone=string&Address=string
            param = String.Format("Company={0}&Wxid={1}&Name={2}&CellPhone={3}&Address={4}",
                                   collection["company"],
                                   openid,
                                   collection["name"],
                                   collection["phone"],
                                   collection["address"]);
            result = WebServiceCall.CallPostMethod(param, method);

            ResultMessage resultMessage = new ResultMessage();

            if (!result.IsNullOrWhiteSpace())
            {
                string[] sArray = result.Split('#');
                sArray[1] = "message=" + sArray[1];

                foreach (string substr in sArray)
                {
                    if (!string.IsNullOrWhiteSpace(substr))
                    {
                        string[] ssArry = substr.Split('=');
                        resultMessage.GetType().GetProperty(ssArry[0]).SetValue(resultMessage, ssArry[1]);
                    }
                }
            }
            else
            {
                resultMessage = new ResultMessage()
                {
                    state = "0",
                    message = "服务器端发生故障！！！"
                };
            }
            return Json(resultMessage, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
        }

        // GET: User/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}