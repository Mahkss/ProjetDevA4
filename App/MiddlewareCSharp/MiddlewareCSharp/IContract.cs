using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MiddlewareCSharp // namespace Contract
{
    [ServiceContract]
    public interface IContract
    {
        // If the asynchronous method pair
        // appears on the client channel, the client can call 
        // them asynchronously to prevent blocking.
        /*[OperationContract(AsyncPattern = true)]
        IAsyncResult beginService(MSG msg, AsyncCallback cb, object asyncState);

        MSG endService(IAsyncResult r);*/

        // This is a synchronous version of the beginService/endService pair.
        // It appears in the client channel code by default. 
        [OperationContract]
        MSG m_service(MSG msg);
    }

    [DataContract]
    public struct MSG
    {
        [DataMember]
        public bool op_statut;
        [DataMember]
        public string info;
        [DataMember]
        public object[] data;
        [DataMember]
        public string operationName;
        [DataMember]
        public string tokenApp;
        [DataMember]
        public string tokenUser;
        [DataMember]
        public string appVersion;
        [DataMember]
        public string operationVersion;
    }
}
