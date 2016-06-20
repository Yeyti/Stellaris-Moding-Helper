using Gwen;
using Gwen.Control;
using Gwen.Control.Layout;

namespace SMH.windows
{
    public class Debug:ControlBase{
        public static void WriteLine(string s,string img)
        {
            AllWindows.debug.Writeline(s,img);
        }
        public static void WriteLine(string s){
            AllWindows.debug.Writeline(s);
        }

        public void Writeline(string s){
            var t = new Label(this);
            t.Text = s;
            t.Dock = Dock.Top;
            t.DoubleClicked += (sender, arguments) => destroy(t);
        }
        public void Writeline(string s,string img)
        {
            var a = new HorizontalLayout(this);
            var i = new ImagePanel(a);
            i.ImageName = img;
            i.Dock = Dock.Left;
            i.Size=new Size(16,16);
            var t = new Label(a);
            t.Text = s;
            t.Dock = Dock.Left;
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
