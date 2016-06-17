using System;
using Gwen;
using Gwen.Control;
using Gwen.Control.Internal;
using Gwen.Control.Layout;
using Gwen.RichText;


namespace SMH{
    
    using OpenTK = Gwen.Renderer.OpenTK;
    public class Area : DockBase{
        
        private ImagePanel img;

        private Gwen.Control.CollapsibleList m_List;

        public Area(ControlBase parent) : base(parent){
            Dock = Dock.Fill;
            SetSize(parent.Width, parent.Height);

            if (Cfg.options["LoadBackground"] == "true"){
                img = new ImagePanel(this);
                img.ImageName = Cfg.options["GameFolder"] + @"\gfx\loadingscreens\load_6.dds";
            }

            MenuStrip menu = new MenuStrip(this);
            MenuItem mi = menu.AddItem("File").Menu.AddItem("ss");
            for (int i = 0; i < 10; i++)
                menu.AddItem("правка");

            MenuStrip menu2 = new MenuStrip(this);
            for (int i = 0; i < 10; i++){
                menu2.AddItem("", "Tex.dds");
            }
            menu2.Top = 25;

            /* ((MenuItem)(menu.Children[0])).Menu.AddItem("a").Menu.AddItem("b");
            new DockBase(this).Dock=Dock.Fill;
            Dragger dr = new Dragger(new ImagePanel(Children[2]));//.ImageName = @"D:\Games\Stellaris\gfx\loadingscreens\load_1.dds");
            dr.DragAndDrop_Draggable();
            Children[2].Size =new Size(100);
            Children[2].DragAndDrop_Draggable();*/

            DockBase dock = new DockBase(this);
            //new ToolWindow(dock.TopDock);
            dock.Margin = new Margin(0, 51, 0, 0);
            //dock.Dock = Dock.Fill;

            //mi.Dock = Dock.Top;
            m_List = new Gwen.Control.CollapsibleList(parent);
            var tc = dock.LeftDock.TabControl.AddPage("Unit tests", m_List);
            tc.IsTabable = true;
            tc.TextColor = new Color(0, 0, 0);
            tc.UpdateColors();
            dock.LeftDock.Width = 150;





            dock.RightDock.TabControl.AddPage("Elements");

            dock.RightDock.TopDock.TabControl.AddPage("Project");
            //dock.RightDock.BottomDock.Height = 500 ;
            //new MessageBox(this, "");
            //dock.RightDock.Width = 1;

            var vs = dock.BottomDock.TabControl.AddPage("Debug").Page;
            ScrollControl ctrl = new ScrollControl(vs);
            ctrl.AutoHideBars = true;
            vs=new DockBase(ctrl);
            foreach (var v in Cfg.options){
                var t =new Label(vs);
                t.Text=v.Key + "=" + v.Value;
                t.Dock=Dock.Top;
                t.DoubleClicked += (sender, arguments) => { t.DelayedDelete();
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
