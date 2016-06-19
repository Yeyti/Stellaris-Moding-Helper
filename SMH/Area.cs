using System;
using System.IO;
using Gwen;
using Gwen.CommonDialog;
using Gwen.Control;
using Gwen.Control.Internal;
using Gwen.Control.Layout;
using Gwen.RichText;
using SMH.windows;


namespace SMH{
    
    using OpenTK = Gwen.Renderer.OpenTK;
    public class Area : DockBase{
        
        private ImagePanel img;

        private Gwen.Control.CollapsibleList m_List;

        public Area(ControlBase parent) : base(parent){
            Dock = Dock.Fill;
            SetSize(parent.Width, parent.Height);
            Back();

            new SMHMenu(this);
            
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
            m_List.Add("Data").Add("s");
            m_List.Add("Mod").Add("s");
            m_List.Add("ED").Add("s");
            dock.LeftDock.TabControl.AddPage("Game", m_List);
            dock.RightDock.TabControl.AddPage("Elements");
            dock.RightDock.TopDock.TabControl.AddPage("Project");
            new Debug(dock.BottomDock.TabControl.AddPage("Debug").Page);
            
        }

        void Back(){
            if (Cfg.ActiveProfile.BackgrondImage != "null")
            {
                img = new ImagePanel(this);
                if (Cfg.ActiveProfile.BackgrondImage == "true")
                {
                    img.ImageName = Cfg.ActiveProfile.GamePath + @"\gfx\loadingscreens\load_" + new Random().Next(1, Directory.GetFiles(Cfg.ActiveProfile.GamePath + @"\gfx\loadingscreens").Length) + ".dds";
                }
                else
                {
                    img.ImageName = Cfg.ActiveProfile.BackgrondImage;
                }
            }
        }

    }
}
