using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMH{
    internal class ResourceLoader{
        private string maincfg = "Res/Cfg/main.cfg";

        public ResourceLoader(){
            Global.options = new Dictionary<string, string>();
            AddData(ref Global.options, maincfg);

            Global.lang=new Dictionary<string, string>();
            /*if (Global.options["Lang"] == ""){
                Global.options["Lang"] = "ru";
            }*/
            
            
            AddData(ref Global.lang, "Res/Lang/" + Global.options["Lang"] + ".lang");
        }

        public static string ReadAllLines(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            return Encoding.UTF32.GetString(data);
        }

        public string[] ReadFile(string File){
            string[] s;
            System.IO.StreamReader file = new System.IO.StreamReader(File,Encoding.Default);
            s = file.ReadToEndAsync().Result.Split('\n');
            file.Close();
            return s;
        }

        public void AddData(ref Dictionary<string,string> d ,string[] s){
            foreach (var v in s){
                string[] buf = (v.Trim(new []{';',' ','\r','\t'})).Split('=');
                if (buf.Length == 2)
                    d.Add(buf[0], buf[1]);
            }
        }
        public void AddData(ref Dictionary<string, string> d, string file){
            AddData(ref d, ReadFile(file));
        }

    }
}
