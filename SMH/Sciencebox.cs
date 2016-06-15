using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMH
{
    internal class Sciencebox {// : PictureBox{
       /* public PictureBox[] img;
        
        private int XMouseClick;
        private int YMouseClick;

        // смещение координат мышки относительно точки клика
        private int dX_Mouse;
        private int dY_Mouse;

        // текущие координаты  верхнего левого угла объекта в момент клика по нему мышкой
        private int X;
        private int Y;

        public Sciencebox(){
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.AutoSize = true;
            

            this.MouseDown += (Ctrl_MouseDown);
            this.MouseUp += (Ctrl_MouseUp);
            this.MouseMove += (Ctrl_MouseMove);
        }

        public Sciencebox(Bitmap pathImage){
            /*img = new PictureBox[i];
            for (int j = 0; j < i+1; j++){
                this.Controls.Add(new PictureBox() {SizeMode = PictureBoxSizeMode.AutoSize});
            }*/
            
            
          /*  this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.AutoSize = true;
            this.Image = pathImage;
            this.BackgroundImage = pathImage;
            

            this.MouseDown += (Ctrl_MouseDown);
            this.MouseUp += (Ctrl_MouseUp);
            this.MouseMove += (Ctrl_MouseMove);

            refresh();
        }

        private Sciencebox ctrl;
        private bool moving;

        private void Ctrl_MouseDown(object sender, EventArgs e){
            

            X = Location.X;
            Y = Location.Y;

            XMouseClick = Cursor.Position.X;
            YMouseClick = Cursor.Position.Y;

            moving = true;
        }

        private void Ctrl_MouseUp(object sender, EventArgs e){
            moving = false; // больше не перемещать при движении мышки
        }

        public void refresh(){
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Controls[i].MouseDown += (Ctrl_MouseDown);
                Controls[i].MouseUp += (Ctrl_MouseUp);
                Controls[i].MouseMove += (Ctrl_MouseMove);
            }
        }

        private void Ctrl_MouseMove(object sender, EventArgs e){
            dX_Mouse = Cursor.Position.X - XMouseClick;
            dY_Mouse = Cursor.Position.Y - YMouseClick;

            //Parent.Refresh();
            Refresh();
            /*
            int right = BackgroundImage.Width < b.Width ? b.Width : BackgroundImage.Width;
            int dwn = BackgroundImage.Height < b.Height? b.Height: BackgroundImage.Height;
            */
            /*
            for (int i = 0; i < right; i++){
                for (int j = 0; j < dwn; j++){
                    Color c = new Color();
                    b.GetPixel(i, j).A + ((Bitmap) BackgroundImage).GetPixel(i, j).A;
                    b.GetPixel(i, j).R + ((Bitmap) BackgroundImage).GetPixel(i, j).R;
                    b.GetPixel(i, j).G + ((Bitmap) BackgroundImage).GetPixel(i, j).G;
                    b.GetPixel(i, j).B + ((Bitmap) BackgroundImage).GetPixel(i, j).B;
                        
                    b.SetPixel(i, j, c);
                        
                }
            }
            */
                
            /*});*/
            
            
           /* if (moving)
                Location = new Point(X + dX_Mouse, Y + dY_Mouse);

        }*/
    }

    
}
