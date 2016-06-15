using System;
using Gwen;
using Gwen.Control;
using Gwen.Control.Internal;


namespace SMH{
    
    using OpenTK = Gwen.Renderer.OpenTK;
    internal class Area : DockBase{
        private StatusBar status;
        private ImagePanel img;
        private Dragger dragger;

        private Gwen.Control.CollapsibleList m_List;

        public Area(ControlBase parent) : base(parent){
            Dock = Dock.Fill;
            SetSize(parent.Width, parent.Height);

            

            status = new StatusBar(parent);

            
            

            img = new ImagePanel(this);
            img.ImageName = @"D:\Games\Stellaris\gfx\loadingscreens\load_1.dds";

            MenuStrip menu = new MenuStrip(this);
            MenuItem mi = menu.AddItem("File").Menu.AddItem("ss");
            for (int i = 0; i < 10; i++)
                menu.AddItem("правка");
            

            new MessageBox(this, "" + menu.BaseUnit).Width=700;
            /* ((MenuItem)(menu.Children[0])).Menu.AddItem("a").Menu.AddItem("b");
            new DockBase(this).Dock=Dock.Fill;
            Dragger dr = new Dragger(new ImagePanel(Children[2]));//.ImageName = @"D:\Games\Stellaris\gfx\loadingscreens\load_1.dds");
            dr.DragAndDrop_Draggable();
            Children[2].Size =new Size(100);
            Children[2].DragAndDrop_Draggable();*/

            DockBase dock = new DockBase(this);
            dock.Margin = new Margin(0, 24, 0, 0);
            //dock.Dock = Dock.Fill;
           
            
            
            //mi.Dock = Dock.Top;
            m_List = new Gwen.Control.CollapsibleList(parent);
            dock.LeftDock.TabControl.AddPage("Unit tests", m_List).IsTabable = true;
            dock.LeftDock.SetPosition(0,img.Height-menu.Height);
            dock.LeftDock.Width = 150;

            
            for(int i = 0;i<5;i++)
            dock.RightDock.TabControl.AddPage("Output");
            dock.RightDock.Width = 200;


            
        }

        protected override void Render(Gwen.Skin.SkinBase skin){
            
            img.Width = Parent.Width;
             img.Height = Parent.Height;
             status.Text = String.Format("Stellaris Mod Helper - {0:F0} fps", 60);
            
            base.Render(skin);
        }
    }
}
