using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMH.Parser
{
    class Tokien{
        public string data;
        public Tokien name;
        public Tokien value;

        public bool isInit
        {
            get
            {
                if (name != null && value != null)
                    return false;
                return true;
            }
        }

        public Tokien()
        {}
        public Tokien(string data){
            this.data = data;
        }
        public Tokien(ref string data)
        {
            this.data = data;
        }
        public Tokien(string data,Tokien name,Tokien value){
            this.data = data;
            this.name = name;
            this.value = value;
        }
        
        

    }
}
