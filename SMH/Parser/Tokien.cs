using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMH.Parser
{
    class Tokien{
        public string value; //maybe of file with element & elements param
        public Dictionary<string, Tokien> data;

        public bool isInit
        {
            get
            {
                if (data != null)
                    return false;
                return true;
            }
        }

        public Tokien()
        {}

        public Tokien(string data){
            this.value = data;
        }
        public Tokien(ref string data){
            this.value = data;
        }
        public Tokien(string value,Dictionary<string,Tokien> data){
            this.value = value;
            this.data = data;
        }



    }
}
