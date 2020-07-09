using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Service
{
    class UncryptService
    {


        public string Uncrypt(string text, string key)
        {
            int dataLen = text.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(text[i] ^ key[i % keyLen]);
            }

            return new string(output);
        }
    }
}
