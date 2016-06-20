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
            DockBase dock = new DockBase(this);

            dock.Margin = new Margin(0, 26, 0, 0);

            

            new Game(dock.LeftDock.TabControl.AddPage("Game").Page);
            new Elements(dock.RightDock.TabControl.AddPage("Elements").Page);
            dock.RightDock.Width = 300;
            new Project(dock.RightDock.TopDock.TabControl.AddPage("Project").Page);
            new Debug(dock.BottomDock.TabControl.AddPage("Debug").Page);

            new SMHMenu(this);


            Debug.WriteLine("sd", @"D:\Games\Stellaris\gfx\interface\main\time_bg.dds");
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
