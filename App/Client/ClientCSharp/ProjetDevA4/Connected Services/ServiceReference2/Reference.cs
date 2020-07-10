﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetDevA4.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/MiddlewareCSharp")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperationNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool StatusOpField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenAppField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenUSerField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationName {
            get {
                return this.OperationNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OperationNameField, value) != true)) {
                    this.OperationNameField = value;
                    this.RaisePropertyChanged("OperationName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool StatusOp {
            get {
                return this.StatusOpField;
            }
            set {
                if ((this.StatusOpField.Equals(value) != true)) {
                    this.StatusOpField = value;
                    this.RaisePropertyChanged("StatusOp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TokenApp {
            get {
                return this.TokenAppField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenAppField, value) != true)) {
                    this.TokenAppField = value;
                    this.RaisePropertyChanged("TokenApp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TokenUSer {
            get {
                return this.TokenUSerField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenUSerField, value) != true)) {
                    this.TokenUSerField = value;
                    this.RaisePropertyChanged("TokenUSer");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IUncipher")]
    public interface IUncipher {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher/DoWork", ReplyAction="http://tempuri.org/IUncipher/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher/DoWork", ReplyAction="http://tempuri.org/IUncipher/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher/GetUncryptedInfo", ReplyAction="http://tempuri.org/IUncipher/GetUncryptedInfoResponse")]
        ProjetDevA4.ServiceReference2.Message GetUncryptedInfo(ProjetDevA4.ServiceReference2.Message msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher/GetUncryptedInfo", ReplyAction="http://tempuri.org/IUncipher/GetUncryptedInfoResponse")]
        System.Threading.Tasks.Task<ProjetDevA4.ServiceReference2.Message> GetUncryptedInfoAsync(ProjetDevA4.ServiceReference2.Message msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUncipherChannel : ProjetDevA4.ServiceReference2.IUncipher, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UncipherClient : System.ServiceModel.ClientBase<ProjetDevA4.ServiceReference2.IUncipher>, ProjetDevA4.ServiceReference2.IUncipher {
        
        public UncipherClient() {
        }
        
        public UncipherClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UncipherClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UncipherClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UncipherClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public ProjetDevA4.ServiceReference2.Message GetUncryptedInfo(ProjetDevA4.ServiceReference2.Message msg) {
            return base.Channel.GetUncryptedInfo(msg);
        }
        
        public System.Threading.Tasks.Task<ProjetDevA4.ServiceReference2.Message> GetUncryptedInfoAsync(ProjetDevA4.ServiceReference2.Message msg) {
            return base.Channel.GetUncryptedInfoAsync(msg);
        }
    }
}
