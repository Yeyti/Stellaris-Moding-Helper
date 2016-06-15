using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwen.Control;

namespace SMH
{
    class Unit:ControlBase
    {
        public Unit(ControlBase c) : base(c){
            IsVirtualControl = true;
        }
    }
}
