using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMH.CFG
{
    public class Profile{
        public Dictionary<string, string> options;

        public string GamePath{
            get { return options["GamePath"]; }
            set { options["GamePath"] = value; }  
        }

        public string BackgrondImage{
            get { return options["BackgrondImage"]; }
            set { options["BackgrondImage"] = value; }
        }

        public Profile(){
        }
    }
}
