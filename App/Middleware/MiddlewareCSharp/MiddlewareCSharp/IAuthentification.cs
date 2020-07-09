using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiddlewareCSharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAuthentification" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAuthentification
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string CheckLogin(string login, string pwd, string appToken);
    }
}
