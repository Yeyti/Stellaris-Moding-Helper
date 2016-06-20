using Gwen;
using Gwen.Control;

namespace SMH.windows
{
    public class Debug:ControlBase{
        private ScrollControl ctrl;
        DockBase vs;

        public void Writeline(string s){
            var t = new Label(vs);
            t.Text = s;
            t.Dock = Dock.Top;
            t.DoubleClicked += (sender, arguments) => destroy(t);
        }

        public Debug(ControlBase b) : base(b){
            ctrl = new ScrollControl(b);
            ctrl.AutoHideBars = true;
            vs = new DockBase(ctrl);
            AllWindows.debug = this;
            /*foreach (var v in Cfg.options)
            {
                var t = new Label(vs);
                t.Text = v.Key + "=" + v.Value;
                t.Dock=Dock.Top;
                t.DoubleClicked += (sender, arguments) => destroy(t);
            }
            foreach (var v in Cfg.lang)
            {
                var t = new Label(vs);
                t.Text = v.Key + "=" + v.Value;
                t.Dock = Dock.Top;
                t.DoubleClicked += (sender, arguments) => destroy(t);
            }*/
        }

        public void destroy(Label t){
            t.DelayedDelete();
            t.Collapse();
        }
    }
}
