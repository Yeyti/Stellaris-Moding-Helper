using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwen;
using Gwen.Control;

namespace SMH.windows
{
    using Properties = Gwen.Control.Properties;
    public class Game:ControlBase
    {
        public Game(ControlBase b) : base(b){
            var vs = new Gwen.Control.CollapsibleList(b);
            vs.Add("Data").Add("s");
            vs.Add("Mod").Add("s");
            AllWindows.game = this;
        }
    }
}
