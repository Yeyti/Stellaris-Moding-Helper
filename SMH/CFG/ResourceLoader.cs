using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMH.Atributes;
using SMH.CFG;

namespace SMH{
    internal class ResourceLoader{

        public ResourceLoader(){
            Cfg.options = new Dictionary<string, string>();
            Cfg.lang = new Dictionary<string, string>();
            Cfg.profiles = new Dictionary<string, Profile>();


            AddDataFromFile(ref Cfg.options, "Res/Cfg/main.cfg");
            if (Cfg.options["Lang"] == "")
                Cfg.options["Lang"] = "ru";
            AddDataFromFile(ref Cfg.lang, "Res/Lang/" + Cfg.Language + ".lang");
            AddDataFromFile(ref Cfg.profiles,"Res/Cfg/profiles.cfg");
        }
        
        public string ReadFile(string file){
            using (StreamReader sr = new StreamReader(file, true))
                return (sr.ReadToEndAsync().Result.Trim( ';', ' ', '\n', '\t' ));
        }



        public void AddData(ref Dictionary<string,string> d,string s){
            foreach (var v in s.Split('\r','\n'))
            {
                Console.WriteLine(v);
                string[] buf = (v).Split('=');
                
                if (buf.Length == 2)
                    d.Add(buf[0].Trim(';', ' ', '\n', '\t'), buf[1].Trim(';', ' ', '\n', '\t'));
            }
        }

        public void LoadProfiles(ref Dictionary<string,Profile> d,string profiles){
            string[] buf = profiles.Split('{', '}');
            for (int i = 0; i < buf.Length-1; i+=2){ 
                buf[i] = buf[i].Trim('=','\n','\r', ' ');
                Cfg.profiles.Add(buf[i],new Profile());
                Cfg.profiles[buf[i]].options=new Dictionary<string, string>();
                AddData(ref d[buf[i]].options,buf[i+1].Trim('\n', '\r'));
            }
        }

        public void AddDataFromFile(ref Dictionary<string, string> d, string file){
            AddData(ref d, ReadFile(file));
        }
        public void AddDataFromFile(ref Dictionary<string, Profile> d, string file)
        {
            LoadProfiles(ref d,ReadFile(file));
        }
    }
}
