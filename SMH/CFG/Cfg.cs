using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMH.CFG;

namespace SMH
{
    public static class Cfg{
        public static Dictionary<string, string> options;
        public static Dictionary<string, string> lang;

        public static Dictionary<string, Profile> profiles;

        public static Profile ActiveProfile{
            get { if(options["ActiveProfile"]!="null") return profiles[options["ActiveProfile"]];
            else return null;
            }
        }

        public static string Language{
            get { return options["Lang"]; }
            set { options["Lang"] = value; }
        }
        
        public static void SaveCfg(Dictionary<string, string> d, string file){
            using (StreamWriter sw = new StreamWriter("Res/Cfg/"+file, false)){
                string[] buf = d.Keys.ToArray();
                string[] buf2 = d.Values.ToArray();
                for (int i = 0;i<buf.Length;i++){
                    sw.WriteLine(buf[i]+"="+buf2[i]);
                }
                sw.Close();
            }
        }
    }

}
