using Gwen;
using Gwen.Control;

namespace SMH.windows
{
    class Debug:ControlBase
    {
        public Debug(ControlBase b) : base(b){
            ScrollControl ctrl = new ScrollControl(b);
            ctrl.AutoHideBars = true;
            var vs = new DockBase(ctrl);
            foreach (var v in Cfg.options)
            {
                var t = new Label(vs);
                t.Text = v.Key + "=" + v.Value;
                t.Dock=Dock.Top;
                t.DoubleClicked += (sender, arguments) => {
                    t.DelayedDelete();
                    t.Collapse();
                };
            }
            foreach (var v in Cfg.lang)
            {
                var t = new Label(vs);
                t.Text = v.Key + "=" + v.Value;
                t.Dock = Dock.Top;
                t.DoubleClicked += (sender, arguments) => {
                    t.DelayedDelete();
                    t.Collapse();
                };
            }
        }
    }
}
