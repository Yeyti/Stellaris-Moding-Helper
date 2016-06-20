using System;
using System.CodeDom;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Gwen.Control;
using SMH.Atributes;

namespace SMH.windows
{
    class SMHMenu:ControlBase{
        private MenuStrip menu;
        public SMHMenu(ControlBase b) : base(b){
            menu = new MenuStrip(this);
            init();
            Info();
        }

        private void init(){
            menu.AddItem(Cfg.lang["FMenu.File"]);
            menu.AddItem(Cfg.lang["FMenu.Edit"]);
            menu.AddItem(Cfg.lang["FMenu.Project"]);
            menu.AddItem(Cfg.lang["FMenu.Analys"]);
            menu.AddItem(Cfg.lang["FMenu.window"]);
            menu.AddItem(Cfg.lang["FMenu.Options"]);
            menu.AddItem(Cfg.lang["FMenu.About"]);
        }

        [FItem("Options/Redraw")]
        private void redraw(){
            menu.DelayedDelete();
            menu=new MenuStrip(this);
            init();
            Info();
        }
        
        private void Info(){
            
            var s = Assembly.GetCallingAssembly().DefinedTypes;
            foreach (var d in s){
                foreach (var n in d.DeclaredMethods){
                    FItem a = (FItem) n.GetCustomAttribute(typeof(FItem));
                    if (a != null){
                        menu.AddItemPath(PickLanguage(a.item)).Clicked += delegate {
                            n.Invoke(this,null);
                        };
                    }
                }
            }   
        }

        public string PickLanguage(string name){
            string ret = "";
            string[] buf = name.Split('\\', '/');
            for (int j = 0; j < buf.Length; j++){
                string s = "FMenu.";
                for (int i = 0; i <= j; i++){
                    s += buf[i]+".";
                }
                if (Cfg.lang.ContainsKey(s.Substring(0, s.Length - 1))){
                    ret += Cfg.lang[s.Substring(0, s.Length - 1)] + '\\';
                }
                else{
                    Cfg.lang.Add(s.Substring(0, s.Length - 1), buf[j]);
                    Debug.WriteLine(Cfg.lang["Err.Localization.MI"] +" "+ s.Substring(0, s.Length - 1));
                    ret += Cfg.lang[s.Substring(0, s.Length - 1)] + '\\';
                }
                
            }
            return ret.Substring(0, ret.Length - 1);
        }
    }
}
