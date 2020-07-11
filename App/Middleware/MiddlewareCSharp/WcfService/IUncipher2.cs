using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IUncipher2Callback))]
    interface IUncipher2
    {
        [OperationContract]
        void GetUncryptedInfo(Message msg);

    }

    public interface IUncipher2Callback
    {
        [OperationContract]
        void UncipherEnd(Message msg);
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
        public String[] Data { get => data; set => data = value; }
        [DataMember]
        public bool StatusOp { get => statusOp; set => statusOp = value; }
    }
}

