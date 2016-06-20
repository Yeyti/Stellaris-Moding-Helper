using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMH.Atributes
{
    [AttributeUsage(AttributeTargets.Method)]
    class FItem:Attribute{
        public string item { get; set;}
        public FItem(string name){
            item = name;
        }
    }
}
