using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMH{
    internal class ResourceLoader{
        private string maincfg = "Res/Cfg/main.cfg";

        public ResourceLoader(){
            Global.options = new Dictionary<string, string>();
            foreach (var v in ReadFile(maincfg)){
                string[] buf = v.Trim(new[]{';',' '}).Split('=');
                Global.options.Add(buf[0],buf[1]);
            }
        }

        public string[] ReadFile(string File){
            string[] s;
            System.IO.StreamReader file = new System.IO.StreamReader(File);
            s=file.ReadToEnd().Split('\n');
            file.Close();
            return s;
        }
    }
}
