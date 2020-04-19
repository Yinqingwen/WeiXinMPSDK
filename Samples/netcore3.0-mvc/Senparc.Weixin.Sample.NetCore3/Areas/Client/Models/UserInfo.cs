///<summary>
/// 版 本：v1.0.0
/// 创建人：尹庆文-Yinqingwen@gmail.com
/// 日 期：2020/4/19 14:48:33
/// 描 述：
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YDService;

namespace Senparc.Weixin.Sample.NetCore3.Areas.Client.Models
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 信息状态，1成功，0失败
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户手机
        /// </summary>
        public string phone { get; set; }


        /// <summary>
        /// 用户地址
        /// </summary>
        public string Address { get; set; }

        public UserInfo()
        { }

        public UserInfo GetUserInfo(string openid) 
        {
            UserInfo result = new UserInfo();

            //链接远程Webservice
            ServiceSoapClient.EndpointConfiguration endpoit = new YDService.ServiceSoapClient.EndpointConfiguration();
            ServiceSoapClient yDServiceClient = new YDService.ServiceSoapClient(endpoit);

            //获取远程数据
            string resultstr = yDServiceClient.WX_SearchCustAsync("胜京物流", openid).Result.ToString();

            resultstr = resultstr.Replace('#', '&');
            string[] sArray = resultstr.Split('&');

            //数据赋值
            foreach (string substr in sArray)
            {
                if (!string.IsNullOrWhiteSpace(substr))
                {
                    string[] ssArry = substr.Split('=');

                    result.GetType().GetProperty(ssArry[0].ToString().Trim()).SetValue(result, ssArry[1].ToString().Trim());
                }
            }

            return result;
        }
    }
}
