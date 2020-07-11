using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Model
{
    class DocumentSOAPModel
    {
        private String key;
        private String content;

        public DocumentSOAPModel(String key, String content)
        {
            this.key = key;
            this.content = content;
        }


        public String getKey()
        {
            return key;
        }
        public void setKey(String key)
        {
            this.key = key;
        }

        public String getContent()
        {
            return content;
        }
        public void setContent(String content)
        {
            this.content = content;
        }
    }
}
