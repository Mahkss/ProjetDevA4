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
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IUncipher2", CallbackContract=typeof(ProjetDevA4.ServiceReference2.IUncipher2Callback))]
    public interface IUncipher2 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher2/GetUncryptedInfo", ReplyAction="http://tempuri.org/IUncipher2/GetUncryptedInfoResponse")]
        void GetUncryptedInfo(ProjetDevA4.ServiceReference2.Message msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher2/GetUncryptedInfo", ReplyAction="http://tempuri.org/IUncipher2/GetUncryptedInfoResponse")]
        System.Threading.Tasks.Task GetUncryptedInfoAsync(ProjetDevA4.ServiceReference2.Message msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUncipher2Callback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUncipher2/UncipherEnd", ReplyAction="http://tempuri.org/IUncipher2/UncipherEndResponse")]
        void UncipherEnd(ProjetDevA4.ServiceReference2.Message msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUncipher2Channel : ProjetDevA4.ServiceReference2.IUncipher2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Uncipher2Client : System.ServiceModel.DuplexClientBase<ProjetDevA4.ServiceReference2.IUncipher2>, ProjetDevA4.ServiceReference2.IUncipher2 {
        
        public Uncipher2Client(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public Uncipher2Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public Uncipher2Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Uncipher2Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Uncipher2Client(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void GetUncryptedInfo(ProjetDevA4.ServiceReference2.Message msg) {
            base.Channel.GetUncryptedInfo(msg);
        }
        
        public System.Threading.Tasks.Task GetUncryptedInfoAsync(ProjetDevA4.ServiceReference2.Message msg) {
            return base.Channel.GetUncryptedInfoAsync(msg);
        }
    }
}
