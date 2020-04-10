using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace Senparc.Weixin.Sample.NetCore3.Areas.System.Controllers
{
    [Area("System")]
    [Route("System/[controller]/[action]")]
    public class UserController : Controller
    {
        //下面换成账号对应的信息，也可以放入web.config等地方方便配置和更换
        public readonly string appId = Config.SenparcWeixinSetting.WeixinAppId;//与微信公众账号后台的AppId设置保持一致，区分大小写。
        private readonly string appSecret = Config.SenparcWeixinSetting.WeixinAppSecret;//与微信公众账号后台的AppId设置保持一致，区分大小写。

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            string returnUrl = Url.Action();

            string austr = OAuthApi.GetAuthorizeUrl(appId,
                "http://sdk.weixin.senparc.com/oauth2/UserInfoCallback?returnUrl=" + returnUrl.UrlEncode(),
                "Yinqingwen19690219", OAuthScope.snsapi_userinfo);
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
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