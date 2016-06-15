using System;
using Gwen;
using Gwen.Control;




namespace SMH{
    
    using OpenTK = Gwen.Renderer.OpenTK;
    internal class Area : DockBase{
        private StatusBar status;
        private ImagePanel img;

        public Area(ControlBase parent) : base(parent){

            

            //Dock = this.Pos.Fill;
            SetSize(parent.Width, parent.Height);
            status = new StatusBar(parent);
            img = new ImagePanel(this);
            img.ImageName = @"D:\Games\Stellaris\gfx\loadingscreens\load_1.dds";




        }

        protected override void Render(Gwen.Skin.SkinBase skin){
             img.Width = Parent.Width;
             img.Height = Parent.Height;
             status.Text = String.Format("Stellaris Mod Helper - {0:F0} fps", 60);
            
            base.Render(skin);
        }
    }
}
