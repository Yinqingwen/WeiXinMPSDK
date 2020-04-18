﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YDService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://sckp.com/", ConfigurationName="YDService.ServiceSoap")]
    public interface ServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/WX_SY_Recer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> WX_SY_RecerAsync(string comp, string CellPhone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/WX_SearchCust", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> WX_SearchCustAsync(string Company, string Wxid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/WX_EditCust", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> WX_EditCustAsync(string Company, string Wxid, string Name, string CellPhone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/Add_Info", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> Add_InfoAsync(string Company, string RecTel, string Recer, string Varo, string Num, string Ds, string City, string Sender, string SendTel, string Baojia, string Style);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/To_Info", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> To_InfoAsync(string comp, string Danhao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/SYS_CHECKIN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> SYS_CHECKINAsync(string comp, string mac);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/SYS_CHECKAD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> SYS_CHECKADAsync(string comp, string mac);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/loadp", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> loadpAsync(string kont, string pwd, string pv, string vs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/SJ_Info_Ret", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> SJ_Info_RetAsync(string name, string comp, string danhao, string style);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sckp.com/SJ_Info", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> SJ_InfoAsync(string name, string comp, string riqi, string style);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ServiceSoapChannel : YDService.ServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<YDService.ServiceSoap>, YDService.ServiceSoap
    {
        
        /// <summary>
        /// 实现此分部方法，配置服务终结点。
        /// </summary>
        /// <param name="serviceEndpoint">要配置的终结点</param>
        /// <param name="clientCredentials">客户端凭据</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), ServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> WX_SY_RecerAsync(string comp, string CellPhone)
        {
            return base.Channel.WX_SY_RecerAsync(comp, CellPhone);
        }
        
        public System.Threading.Tasks.Task<string> WX_SearchCustAsync(string Company, string Wxid)
        {
            return base.Channel.WX_SearchCustAsync(Company, Wxid);
        }
        
        public System.Threading.Tasks.Task<string> WX_EditCustAsync(string Company, string Wxid, string Name, string CellPhone)
        {
            return base.Channel.WX_EditCustAsync(Company, Wxid, Name, CellPhone);
        }
        
        public System.Threading.Tasks.Task<string> Add_InfoAsync(string Company, string RecTel, string Recer, string Varo, string Num, string Ds, string City, string Sender, string SendTel, string Baojia, string Style)
        {
            return base.Channel.Add_InfoAsync(Company, RecTel, Recer, Varo, Num, Ds, City, Sender, SendTel, Baojia, Style);
        }
        
        public System.Threading.Tasks.Task<string> To_InfoAsync(string comp, string Danhao)
        {
            return base.Channel.To_InfoAsync(comp, Danhao);
        }
        
        public System.Threading.Tasks.Task<string> SYS_CHECKINAsync(string comp, string mac)
        {
            return base.Channel.SYS_CHECKINAsync(comp, mac);
        }
        
        public System.Threading.Tasks.Task<string> SYS_CHECKADAsync(string comp, string mac)
        {
            return base.Channel.SYS_CHECKADAsync(comp, mac);
        }
        
        public System.Threading.Tasks.Task<string> loadpAsync(string kont, string pwd, string pv, string vs)
        {
            return base.Channel.loadpAsync(kont, pwd, pv, vs);
        }
        
        public System.Threading.Tasks.Task<string> SJ_Info_RetAsync(string name, string comp, string danhao, string style)
        {
            return base.Channel.SJ_Info_RetAsync(name, comp, danhao, style);
        }
        
        public System.Threading.Tasks.Task<string> SJ_InfoAsync(string name, string comp, string riqi, string style)
        {
            return base.Channel.SJ_InfoAsync(name, comp, riqi, style);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.ServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://123.56.190.161:40/service.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.ServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://123.56.190.161:40/service.asmx");
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            ServiceSoap,
            
            ServiceSoap12,
        }
    }
}
