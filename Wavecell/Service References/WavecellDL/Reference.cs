﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wavecell.WavecellDL {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wavecell.com/", ConfigurationName="WavecellDL.GetDLRApiSoap")]
    public interface GetDLRApiSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wavecell.com/SMSDLR", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SMSDLR(string AccountId, string SubAccountId, string Password, string UMID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetDLRApiSoapChannel : Wavecell.WavecellDL.GetDLRApiSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDLRApiSoapClient : System.ServiceModel.ClientBase<Wavecell.WavecellDL.GetDLRApiSoap>, Wavecell.WavecellDL.GetDLRApiSoap {
        
        public GetDLRApiSoapClient() {
        }
        
        public GetDLRApiSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetDLRApiSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetDLRApiSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetDLRApiSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet SMSDLR(string AccountId, string SubAccountId, string Password, string UMID) {
            return base.Channel.SMSDLR(AccountId, SubAccountId, Password, UMID);
        }
    }
}