using Gwen;
using Gwen.Control;

namespace SMH.windows
{
    public class Debug:ControlBase{
        public static void WriteLine(string s){
            AllWindows.debug.Writeline(s);
        }

        public void Writeline(string s){
            var t = new Label(this);
            t.Text = s;
            t.Dock = Dock.Top;
            t.DoubleClicked += (sender, arguments) => destroy(t);
        }

        public Debug(ControlBase b) : base(b){
            var vs = new ListBox(this);
            vs.AlternateColor = false;
            AllWindows.debug = this;
        }

        public void destroy(Label t){
            t.DelayedDelete();
            t.Collapse();
        }
    }
}
