using System;
using System.Diagnostics;
using System.Threading;

using Gwen;
using Gwen.CommonDialog;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using Gwen.Control;
using Gwen.Platform;
using Gwen.Renderer.OpenTK;
using Gwen.Xml;
using OpenTK.Graphics;
using Key = OpenTK.Input.Key;

namespace SMH
{
    using Color = Gwen.Color;
    sealed class Window:GameWindow
    {
        private Gwen.Renderer.OpenTK.Input.OpenTK input;
        private Gwen.Renderer.OpenTK.OpenTKBase renderer;
        private Gwen.Skin.SkinBase skin;
        private Canvas canvas;

        private StatusBar status;

        private Stopwatch sw;

        private Area area;
        public bool fast = false;
        private bool altDown = false;

        private ResourceLoader resourceLoader;

        public Window(): base(1248, 720)
        {
            resourceLoader = new ResourceLoader();

            Keyboard.KeyDown += Keyboard_KeyDown;
            Keyboard.KeyUp += Keyboard_KeyUp;

            Mouse.ButtonDown += Mouse_ButtonDown;
            Mouse.ButtonUp += Mouse_ButtonUp;
            Mouse.Move += Mouse_Move;
            Mouse.WheelChanged += Mouse_Wheel;
            

        }

 

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.AltLeft)
                altDown = true;
            else if (altDown && e.Key == global::OpenTK.Input.Key.Enter)
                if (WindowState == WindowState.Fullscreen)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Fullscreen;

            input.ProcessKeyDown(e);
        }

        void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            altDown = false;
            input.ProcessKeyUp(e);
        }

        void Mouse_ButtonDown(object sender, MouseButtonEventArgs args)
        {
            input.ProcessMouseMessage(args);
        }

        void Mouse_ButtonUp(object sender, MouseButtonEventArgs args)
        {

            input.ProcessMouseMessage(args);
        }

        void Mouse_Move(object sender, MouseMoveEventArgs args){
            fast = true;
            input.ProcessMouseMessage(args);
        }

        void Mouse_Wheel(object sender, MouseWheelEventArgs args)
        {
            input.ProcessMouseMessage(args);
        }

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e){

            sw = new Stopwatch();
            GL.ClearColor(System.Drawing.Color.MidnightBlue);

            Platform.Init(new Windows());

            renderer = new OpenTKGL40();

            skin = new Gwen.Skin.TexturedBase(renderer, "Res/Img/Skin.png");
            skin.DefaultFont = new Font(renderer, "Arial", 11);
            canvas = new Canvas(skin);
            input = new Gwen.Renderer.OpenTK.Input.OpenTK(this);
            input.Initialize(canvas);

            canvas.SetSize(Width, Height);
            canvas.ShouldDrawBackground = true;
            canvas.BackgroundColor = skin.Colors.ModalBackground;
            //canvas.KeyboardInputEnabled = true;
            canvas.Scale = 1.0f;
            Cfg.options.ToString();
            if (Cfg.ActiveProfile == null){
                Gwen.Control.Window w = new Gwen.Control.Window(canvas);
                w.Size = new Size(300,300);
                w.Title = Cfg.lang["ProffileExp.Win.Title"];
                w.Resizing = Resizing.None;
                

                /*var bas = new DockBase(w);
                bas.Dock = Dock.Fill;

                
                new Button(bas.TopDock.LeftDock);
                new Button(bas.TopDock.RightDock);
                ScrollControl ctrl = new ScrollControl(bas.BottomDock);
                bas.Dock=Dock.Bottom;
                new Label(ctrl).Text="ssdsd";*/
                Selecter s = new Selecter(w);

            }
            else{
                if (Cfg.ActiveProfile.GamePath == "null"){
                    var c = new MessageBox(canvas, Cfg.lang["SMH.GameFolder.err"]);
                    c.Dismissed += (sender, arguments) =>{
                        string Text = "";
                        FolderBrowserDialog dialog = Component.Create<FolderBrowserDialog>(canvas);
                        dialog.InitialFolder = "C:\\";
                        dialog.Filters = "*|*";
                        dialog.Callback = (path) =>{
                            Text = path != null ? path : "Cancelled";
                            Cfg.ActiveProfile.GamePath = Text;
                            Cfg.SaveCfg(Cfg.profiles, "profiles.cfg");
                            PostInit();
                        };
                    };
                }
                else{
                    PostInit();
                }
            }

            status = new StatusBar(canvas);

            /*stopwatch.Restart();
            lastTime = 0;*/
        }

        public void PostInit(){
            area = new Area(canvas);

        }

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            renderer.Resize(Width, Height);


            

            canvas.SetSize(Width, Height);
            OnRenderFrame(null);
        }

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e){
            status.Text = string.Format("Stellaris Mod Helper - {0:F0} fps", RenderFrequency);
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e){
            
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

            sw.Start(); 
            canvas.RenderCanvas();
            sw.Stop();
            int tts = 33 - (int)sw.ElapsedMilliseconds;
            if (tts > 0)
                Thread.Sleep(tts);
            sw.Reset();
            SwapBuffers();
        }

        public override void Dispose()
        {
            if (canvas != null)
            {
                canvas.Dispose();
                canvas = null;
            }
            if (skin != null)
            {
                skin.Dispose();
                skin = null;
            }
            if (renderer != null)
            {
                renderer.Dispose();
                renderer = null;
            }
            base.Dispose();
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>*/
        [STAThread]
        static void Main(){
            
            using (Window example = new Window())
            {
                example.Title = "Stellaris Mod Helper";
                example.VSync = VSyncMode.Off;
                example.Run();
            }
        }
    }
}
