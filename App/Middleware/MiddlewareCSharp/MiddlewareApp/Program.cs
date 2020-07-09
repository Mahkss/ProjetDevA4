using MiddlewareApp.Coordination;
using MiddlewareApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp
{
    class Program
    {
        static void Main(string[] args)
        {

            LaunchAuthentification LA = new LaunchAuthentification();
            string result = LA.StartAuthWork("0963845516", "Max", "1234");


            Console.WriteLine(result);

            /*UncryptService US = new UncryptService();
            string text = "text ého exemple";

            string cypher = US.Uncrypt(text, "ABDC");
            string plain = US.Uncrypt(cypher, "ABDC");
            Console.WriteLine(text);
            Console.WriteLine(cypher);

            Console.WriteLine(plain);*/
            Console.ReadLine();
        }
    }
}
