using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwen.Control;

namespace SMH.windows
{
    public class Project : ControlBase
    {
        public Project(ControlBase b) : base(b){
            var vs = new ListBox(this);
            vs.AlternateColor = false;
            AllWindows.project = this;
        }

        public void destroy(ControlBase t)
        {
            t.DelayedDelete();
            t.Collapse();
        }
    }
}
