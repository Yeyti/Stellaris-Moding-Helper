using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gwen.CommonDialog;
using Gwen.Control;
using SMH.Atributes;
using SMH.CFG;
using SMH.windows;

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
                Console.WriteLine("Res/Cfg/" + file);
                for (int i = 0;i<buf.Length;i++){
                    Console.WriteLine(buf[i] + "=" + buf2[i]);
                    sw.WriteLine(buf[i]+"="+buf2[i]);
                }
                sw.Close();
            }
        }
        [FItem("File/SaveCfg")]
        public static void SaveAll(){
            SaveCfg(options,"main.cfg");
            SaveCfg(profiles,"profiles.cfg");
        }

        public static void SaveCfg(Dictionary<string, Profile> d, string file)
        {
            using (StreamWriter sw = new StreamWriter("Res/Cfg/" + file, false))
            {
                string[] buf = d.Keys.ToArray();
                
                for (int i = 0; i < buf.Length; i++)
                {
                    sw.WriteLine(buf[i] + " = {");
                    string[] buf2 = d[buf[i]].options.Keys.ToArray();
                    string[] buf3 = d[buf[i]].options.Values.ToArray();
                    for (int j = 0; j < buf2.Length; j++){
                        sw.WriteLine("\t" + buf2[j] + " = " + buf3[j] + ";");
                    }
                    sw.WriteLine("}");
                }
                sw.Close();
            }
        }
    }

}
