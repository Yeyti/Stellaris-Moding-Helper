using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwen;
using Gwen.Control;
using Gwen.Control.Layout;

namespace SMH
{
    class Selecter:ControlBase
    {

        public Selecter(ControlBase b):base(b){



            ControlBase hlayout = new HorizontalLayout(this);
            hlayout.Dock = Dock.Fill;

            hlayout = new VerticalLayout(this);
            hlayout.Dock = Dock.Top;

            Button a = new Button(hlayout);
            a.Text = "Создать";
            Button B = new Button(hlayout);
            B.Text = "Удалить";

            ScrollControl scroll = new ScrollControl(hlayout);
            scroll.AutoSizeToContent=true;
            scroll.AutoHideBars = true;

            ListBox ctrl = new ListBox(new GroupBox(scroll));
            ctrl.AllowMultiSelect = false;
            ctrl.AutoSizeToContent = true;
            foreach (var p in Cfg.profiles)
            {
                ctrl.AddRow("" + p.Key);
            }
            
            if (ctrl.SelectedRow==null){
                ctrl.SelectedRowIndex = 0;
            }
            hlayout = new HorizontalLayout(this);
            hlayout.Dock = Dock.Top;

            Button c = new Button(this);
            c.Text = "Ок";
            c.Dock = Dock.Bottom;
            c.Clicked += (sender, arguments) => {
                Cfg.options["ActiveProfile"] = ctrl.SelectedRow.Text;
                Cfg.SaveCfg(Cfg.options, "main.cfg");
                CloseMenus();
            };


        }
    }
}
