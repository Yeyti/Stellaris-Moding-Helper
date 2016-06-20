using Gwen;
using Gwen.Control;

namespace SMH.windows
{
    using Properties = Gwen.Control.Properties;
    public class Elements:ControlBase
    {
        public Elements(ControlBase b) : base(b){
            PropertyTree s = new PropertyTree(this);
            s.AutoSizeToContent = true;
            s.Dock = Dock.Top;
            s.Width = 300;
            s.Add("Middle Name");
            s.Add("Last Name");
            s.Add("Four");
            Properties props = s.Add("Item One");

            props.Add("Middle Name");
            props.Add("Last Name");
            props.Add("Four");

        }
    }
}
