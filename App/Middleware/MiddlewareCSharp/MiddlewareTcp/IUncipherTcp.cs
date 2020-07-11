using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiddlewareCSharp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUncipherTcp" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IUncipherTcpCallback))]
    public interface IUncipherTcp
    {
        [OperationContract]
        void GetUncryptedInfo(Message msg);
    }

    public interface IUncipherTcpCallback
    {
        [OperationContract]
        void ReturnMessage(Message msg);
    }

     [DataContract]
    public class Message
    {
        private Boolean statusOp = true;
        private String[] data;
        private String operationName;
        private String tokenApp;
        private String tokenUSer;

        [DataMember]
        public string TokenApp { get => tokenApp; set => tokenApp = value; }
        [DataMember]
        public string TokenUSer { get => tokenUSer; set => tokenUSer = value; }
        [DataMember]
        public string OperationName { get => operationName; set => operationName = value; }
        [DataMember]
        public string[] Data { get => data; set => data = value; }
        [DataMember]
        public bool StatusOp { get => statusOp; set => statusOp = value; }
    }
}
