﻿using NHibernate.Linq.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MiddlewareApp.Coordination;

namespace MiddlewareCSharp
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Interuption" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Interuption.svc ou Interuption.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Interuption : IInteruption
    {
        public void DoWork()
        {
        }
    }
}
