using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YDService;

namespace Senparc.Weixin.Sample.NetCore3.Models
{
    /// <summary>
    /// 运单信息类，运单查询用
    /// </summary>
    public class YdInfo
    {
        /// <summary>
        /// 查询结果状态，1成功，0错误
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 信息，查询正常为空，错误为错误消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 运单号码
        /// </summary>
        public string 运单号 { get; set; }

        /// <summary>
        /// 发货网点
        /// </summary>
        public string 发站网点 { get; set; }

        /// <summary>
        /// 到货网点
        /// </summary>
        public string 提货网点 { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        public string 目的地 { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string 付款方式 { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        public string 应收款 { get; set; }

        /// <summary>
        /// 托运日期
        /// </summary>
        public string 托运日期 { get; set; }

        /// <summary>
        /// 中转方式
        /// </summary>
        public string 中转方式 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string 状态 { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public string 合同 { get; set; }

        /// <summary>
        /// 持卡人
        /// </summary>
        public string 持卡人 { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string 卡号 { get; set; }

        /// <summary>
        /// 发站电话
        /// </summary>
        public string 发站电话 { get; set; }

        /// <summary>
        /// 到站电话
        /// </summary>
        public string 到站电话 { get; set; }

        /// <summary>
        /// 放代点
        /// </summary>
        public string 放代点 { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public YdInfo()
        { }

        /// <summary>
        /// 链接远程Webservice,获取运单信息，生成对象
        /// </summary>
        /// <param name="name">站点名称</param>
        /// <param name="company">公司名称</param>
        /// <param name="ordernumber">运单号码</param>
        public YdInfo GetRemoteYdInfo(string name, string company, string ordernumber)
        {
            //链接远程Webservice
            ServiceSoapClient.EndpointConfiguration endpoit = new YDService.ServiceSoapClient.EndpointConfiguration();
            ServiceSoapClient yDServiceClient = new YDService.ServiceSoapClient(endpoit);

            //获取远程数据
            name = string.IsNullOrWhiteSpace(name) ? "胜京物流" : name;
            company = string.IsNullOrWhiteSpace(company) ? "胜京物流" : company;
            string result = yDServiceClient.To_InfoAsync(name, company, ordernumber).Result.ToString();

            //调整返回字符串格式
            result = result.Replace('#', '&');
            result = result.Replace("err", "msg");

            //远程返回结果分割
            string[] sArray = result.Split('&');

            //新建运单信息
            YdInfo ydInfo = new YdInfo();
            
            //数据赋值
            foreach (string substr in sArray)
            {
                if (!string.IsNullOrWhiteSpace(substr))
                {
                    string[] ssArry = substr.Split('=');

                    ydInfo.GetType().GetProperty(ssArry[0]).SetValue(ydInfo, ssArry[1]);
                }
            }
            //返回运单信息
            return ydInfo;
        }
    }
}
