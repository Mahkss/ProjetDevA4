﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetDevA4.MiddlewareWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MiddlewareWCF.IAuthentification")]
    public interface IAuthentification {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentification/DoWork", ReplyAction="http://tempuri.org/IAuthentification/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentification/DoWork", ReplyAction="http://tempuri.org/IAuthentification/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentification/CheckLogin", ReplyAction="http://tempuri.org/IAuthentification/CheckLoginResponse")]
        string CheckLogin(string login, string pwd, string appToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentification/CheckLogin", ReplyAction="http://tempuri.org/IAuthentification/CheckLoginResponse")]
        System.Threading.Tasks.Task<string> CheckLoginAsync(string login, string pwd, string appToken);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthentificationChannel : ProjetDevA4.MiddlewareWCF.IAuthentification, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthentificationClient : System.ServiceModel.ClientBase<ProjetDevA4.MiddlewareWCF.IAuthentification>, ProjetDevA4.MiddlewareWCF.IAuthentification {
        
        public AuthentificationClient() {
        }
        
        public AuthentificationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthentificationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthentificationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthentificationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public string CheckLogin(string login, string pwd, string appToken) {
            return base.Channel.CheckLogin(login, pwd, appToken);
        }
        
        public System.Threading.Tasks.Task<string> CheckLoginAsync(string login, string pwd, string appToken) {
            return base.Channel.CheckLoginAsync(login, pwd, appToken);
        }
    }
}