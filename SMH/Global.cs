using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMH
{
    public static class Global{
        public static Dictionary<string, string> options;
        public static Dictionary<string, string> lang;

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
