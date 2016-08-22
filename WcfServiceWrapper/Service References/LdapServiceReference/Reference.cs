﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceWrapper.LdapServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserObject", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class UserObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] MemberOfField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UniqueIdentifierField;
        
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
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mail {
            get {
                return this.MailField;
            }
            set {
                if ((object.ReferenceEquals(this.MailField, value) != true)) {
                    this.MailField = value;
                    this.RaisePropertyChanged("Mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] MemberOf {
            get {
                return this.MemberOfField;
            }
            set {
                if ((object.ReferenceEquals(this.MemberOfField, value) != true)) {
                    this.MemberOfField = value;
                    this.RaisePropertyChanged("MemberOf");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UniqueIdentifier {
            get {
                return this.UniqueIdentifierField;
            }
            set {
                if ((object.ReferenceEquals(this.UniqueIdentifierField, value) != true)) {
                    this.UniqueIdentifierField = value;
                    this.RaisePropertyChanged("UniqueIdentifier");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LdapServiceReference.ILdapConnectionService")]
    public interface ILdapConnectionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILdapConnectionService/ValidateUser", ReplyAction="http://tempuri.org/ILdapConnectionService/ValidateUserResponse")]
        bool ValidateUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILdapConnectionService/ValidateUser", ReplyAction="http://tempuri.org/ILdapConnectionService/ValidateUserResponse")]
        System.Threading.Tasks.Task<bool> ValidateUserAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILdapConnectionService/GetUser", ReplyAction="http://tempuri.org/ILdapConnectionService/GetUserResponse")]
        WcfServiceWrapper.LdapServiceReference.UserObject GetUser(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILdapConnectionService/GetUser", ReplyAction="http://tempuri.org/ILdapConnectionService/GetUserResponse")]
        System.Threading.Tasks.Task<WcfServiceWrapper.LdapServiceReference.UserObject> GetUserAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILdapConnectionService/IsMemberOf", ReplyAction="http://tempuri.org/ILdapConnectionService/IsMemberOfResponse")]
        bool IsMemberOf(string username, string cn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILdapConnectionService/IsMemberOf", ReplyAction="http://tempuri.org/ILdapConnectionService/IsMemberOfResponse")]
        System.Threading.Tasks.Task<bool> IsMemberOfAsync(string username, string cn);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILdapConnectionServiceChannel : WcfServiceWrapper.LdapServiceReference.ILdapConnectionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LdapConnectionServiceClient : System.ServiceModel.ClientBase<WcfServiceWrapper.LdapServiceReference.ILdapConnectionService>, WcfServiceWrapper.LdapServiceReference.ILdapConnectionService {
        
        public LdapConnectionServiceClient() {
        }
        
        public LdapConnectionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LdapConnectionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LdapConnectionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LdapConnectionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidateUser(string username, string password) {
            return base.Channel.ValidateUser(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> ValidateUserAsync(string username, string password) {
            return base.Channel.ValidateUserAsync(username, password);
        }
        
        public WcfServiceWrapper.LdapServiceReference.UserObject GetUser(string username) {
            return base.Channel.GetUser(username);
        }
        
        public System.Threading.Tasks.Task<WcfServiceWrapper.LdapServiceReference.UserObject> GetUserAsync(string username) {
            return base.Channel.GetUserAsync(username);
        }
        
        public bool IsMemberOf(string username, string cn) {
            return base.Channel.IsMemberOf(username, cn);
        }
        
        public System.Threading.Tasks.Task<bool> IsMemberOfAsync(string username, string cn) {
            return base.Channel.IsMemberOfAsync(username, cn);
        }
    }
}