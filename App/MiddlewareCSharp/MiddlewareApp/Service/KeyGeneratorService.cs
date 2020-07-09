using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Service
{
    class KeyGeneratorService
    {

        public string GenerateKey()
        {
            return "AAAA";
        }

        public string GenerateKey(string prevKey)
        {
            List<char> newKey = prevKey.ToList<char>();

            if ((int)prevKey[3] == 90)
            {
                if ((int)prevKey[2] == 90)
                {
                    if ((int)prevKey[1] == 90)
                    {
                        if ((int)prevKey[0] == 90)
                        {
                            return "";
                        }
                        else
                        {
                            newKey[0] = (char)((int)newKey[0] + 1);
                        }
                        newKey[1] = (char)((int)newKey[1] - 25);
                    }
                    else
                    {
                        newKey[1] = (char)((int)newKey[1] + 1);
                    }
                    newKey[2] = (char)((int)newKey[2] - 25);
                }
                else
                {
                    newKey[2] = (char)((int)newKey[2] + 1);
                }

                newKey[3] = (char)((int)newKey[3] - 25);
            }
            else
            {
                newKey[3] = (char)((int)newKey[3] + 1);
            }

            string resultKey = new string(newKey.ToArray<char>());
            return resultKey;
        }

    }
}
