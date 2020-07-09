using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiddlewareCSharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IUncipher" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IUncipher
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        Message GetUncryptedInfo(Message msg);

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
