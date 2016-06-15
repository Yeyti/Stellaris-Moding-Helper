using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwen;
using Gwen.Control;

namespace SMH
{
    class Science:ControlBase
    {
        
        public Science(ControlBase parent,String s) : base(parent){
            new ImagePanel(this).ImageName = s;
            this.IsVirtualControl = true;
            this.DragAndDrop_Draggable();
        }
        
    }
}
