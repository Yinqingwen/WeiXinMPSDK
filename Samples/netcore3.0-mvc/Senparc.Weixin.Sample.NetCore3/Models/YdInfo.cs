﻿using System;
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
        /*public string 付款方式 { get; set; }*/

        /// <summary>
        /// 应收款
        /// </summary>
        /*public string 应收款 { get; set; }*/

        /// <summary>
        /// 托运日期
        /// </summary>
        public string 托运日期 { get; set; }

        /// <summary>
        /// 配载日期
        /// </summary>
        public string 配载日期 { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        public string 结算日期 { get; set; }

        /// <summary>
        /// 提货人
        /// </summary>
        public string 提货人 { get; set; }

        /// <summary>
        /// 付款日期
        /// </summary>
        public string 付款日期 { get; set; }

        /// <summary>
        /// 汇款日期
        /// </summary>
        public string 汇款日期 { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        public string 收款人 { get; set; }

        /// <summary>
        /// 到站电话
        /// </summary>
        public string 到站电话 { get; set; }

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
            string result = yDServiceClient.To_InfoAsync(company, ordernumber).Result.ToString();

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

    /// <summary>
    /// 发货运单信息类
    /// </summary>
    public class FydInfo 
    {
        /// <summary>
        /// 发货单状态
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 发货单信息
        /// </summary>
        public string msg { get; set; } 
        
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string 收货人电话 { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string 收货人 { get; set; }
        
        /// <summary>
        /// 货名
        /// </summary>
        public string 货名 { get; set; }
        
        /// <summary>
        /// 件数
        /// </summary>
        public string 件数 { get; set; }
        
        /// <summary>
        /// 城市
        /// </summary>
        public string 城市 { get; set; }
        
        /// <summary>
        /// 托运人
        /// </summary>
        public string 托运人 { get; set; }

        /// <summary>
        /// 托运人电话
        /// </summary>
        public string 托运人电话 { get; set; }

        public FydInfo() 
        { 
        }

        public FydInfo GetFydInfo(string state)
        {
            FydInfo result = new FydInfo();

            state = state.Replace('#',',');
            string[] sArray = state.Split(',');

            //数据赋值
            foreach (string substr in sArray)
            {
                if (!string.IsNullOrWhiteSpace(substr))
                {
                    string[] ssArry = substr.Split('=');

                    result.GetType().GetProperty(ssArry[0]).SetValue(result, ssArry[1]);
                }
            }

            return result;
        }
    }

    /// <summary>
    /// 根据电话号码查询收货人信息
    /// </summary>
    public class PhoneInfo 
    { 
        /// <summary>
        /// 查询状态，1为正常，0为错误
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string 收货人 { get; set; }

        /// <summary>
        /// 到站城市
        /// </summary>
        public string 到站城市 { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PhoneInfo() 
        { }

        public PhoneInfo GetPhoneInfo(string state)
        {
            //链接远程Webservice
            ServiceSoapClient.EndpointConfiguration endpoit = new YDService.ServiceSoapClient.EndpointConfiguration();
            ServiceSoapClient yDServiceClient = new YDService.ServiceSoapClient(endpoit);

            //获取远程数据
            string result = yDServiceClient.WX_SY_RecerAsync("胜京物流", state).Result.ToString(); //.To_InfoAsync(company, ordernumber).Result.ToString();

            PhoneInfo phoneInfo = new PhoneInfo();

            result = result.Replace('#', '&');
            result = result.Replace("err", "msg");
            string[] sArray = result.Split('&');

            //数据赋值
            foreach (string substr in sArray)
            {
                if (!string.IsNullOrWhiteSpace(substr))
                {
                    string[] ssArry = substr.Split('=');

                    phoneInfo.GetType().GetProperty(ssArry[0]).SetValue(phoneInfo, ssArry[1]);
                }
            }

            return phoneInfo;
        }
    }

}
