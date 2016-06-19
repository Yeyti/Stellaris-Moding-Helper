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
            Info();
        }
        private void Info(){
            var s = Assembly.GetCallingAssembly().DefinedTypes;
            foreach (var d in s){
                foreach (var n in d.DeclaredMethods){
                    FItem a = (FItem) n.GetCustomAttribute(typeof(FItem));
                    if (a != null){
                        menu.AddItemPath(a.item).Clicked += delegate {
                            n.Invoke(d, null);
                        };
                    }
                }
            }   
        }
    }
}
