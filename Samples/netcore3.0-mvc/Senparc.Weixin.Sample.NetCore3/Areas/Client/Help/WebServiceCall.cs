using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Senparc.Weixin.Sample.NetCore3.Areas.Client.Help
{
    public static class WebServiceCall
    {
        public static string Url = "http://123.56.190.161:40/service.asmx";

        /// <summary>
        /// 通过httpclient方式调用WebService
        /// </summary>
        /// <param name="param">调用参数字符串，格式请参见asmx页面函数的格式介绍</param>
        /// <param name="callmethod">要调用的远程函数</param>
        /// <param name="Url">WebService的URL地址</param>
        /// <returns>字符串类型的返回值，自行解析</returns>
        public static string CallPostMethod(string param,string callmethod, string url = "http://123.56.190.161:40/service.asmx")
        {
            //定义返回值
            string result = string.Empty;
            byte[] bytes = null;

            Stream writer = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            bytes = Encoding.UTF8.GetBytes(param);

            request = (HttpWebRequest)WebRequest.Create(url + "/" + callmethod);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            try
            {
                writer = request.GetRequestStream();        //获取用于写入请求数据的Stream对象
            }
            catch (Exception ex)
            {
                return "";
            }

            writer.Write(bytes, 0, bytes.Length);       //把参数数据写入请求数据流
            writer.Close();

            try
            {
                response = (HttpWebResponse)request.GetResponse();      //获得响应
            }
            catch (WebException ex)
            {
                return "";
            }

            #region 这种方式读取到的是一个返回的结果字符串
            Stream stream = response.GetResponseStream();        //获取响应流
            XmlTextReader Reader = new XmlTextReader(stream);
            Reader.MoveToContent();
            result = Reader.ReadInnerXml();
            #endregion

            #region 这种方式读取到的是一个Xml格式的字符串
            //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //result = reader.ReadToEnd();
            #endregion 

            response.Dispose();
            response.Close();

            Reader.Dispose();
            Reader.Close();

            stream.Dispose();
            stream.Close();

            return result;
        }
    }
}
