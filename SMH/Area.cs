using System;
using DDSSuply;
using Gwen;
using Gwen.Control;




namespace SMH{
    
    using OpenTK = Gwen.Renderer.OpenTK;
    internal class Area : DockBase{
        private StatusBar status;
        private ImagePanel img;

        public Area(Base parent) : base(parent){

            

            Dock = Pos.Fill;
            SetSize(parent.Width, parent.Height);
            status = new StatusBar(parent);
            img = new ImagePanel(this);
            //Bitmap b = ;
            img.m_Texture = new Texture(Skin.Renderer);
            img.m_Texture.Load("$ram\\load_1.dds", DDS.LoadImage(@"D:\Games\Stellaris\gfx\loadingscreens/load_1.dds"));
            
            Texture t = new Texture(new OpenTK());
            for (int i = 0;i<100;i++){
                g();
            }
            
            /*ImagePanel img2 = new ImagePanel(img);
            img2.ImageName = "gwen.png";
            img2.SetPosition(120, 10);
            img2.SetSize(100, 100);

            img.SetPosition(0, 0);
            img.SetSize(parent.Width, parent.Height-status.Height);

            status.SendToBack();*/



        }

        void g(){
            for (int i = 1; i < 10; i++){
                var  t = new ImagePanel(img);
                
                t.ImageName="gwen.png";/*, DDS.LoadImage(@"D:\Games\Stellaris\gfx\loadingscreens/load_"+i+".dds")*///);
                t.SetSize(300, 300);
                t.SetPosition(new Random().Next(0,Parent.Width), new Random().Next(0, Parent.Height));
            }
        }
       

        protected override void Render(Gwen.Skin.Base skin){
             img.Width = Parent.Width;
             img.Height = Parent.Height;
             status.Text = String.Format("Stellaris Mod Helper - {0:F0} fps", 60);
            
            base.Render(skin);
        }
    }
}
