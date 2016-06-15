﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Gwen;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using Gwen.Control;
using Gwen.Platform;
using Gwen.Renderer.OpenTK;
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



        private Area area;
        public bool fast = false;
        private bool altDown = false;

        public Window(): base(1248, 720)
        {
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
        protected override void OnLoad(EventArgs e)
        {

            GL.ClearColor(System.Drawing.Color.MidnightBlue);

            Platform.Init(new Windows());

            renderer = new OpenTKGL40(true);

            skin = new Gwen.Skin.TexturedBase(renderer, "Skin.png");

            skin.DefaultFont = new Font(renderer, "Arial", 11);
            canvas = new Canvas(skin);
            input = new Gwen.Renderer.OpenTK.Input.OpenTK(this);
            input.Initialize(canvas);

            canvas.SetSize(Width, Height);
            canvas.ShouldDrawBackground = true;
            canvas.BackgroundColor = skin.Colors.ModalBackground;
            //canvas.KeyboardInputEnabled = true;
            canvas.Scale = 1.0f;
            area = new Area(canvas);

            /*stopwatch.Restart();
            lastTime = 0;*/
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
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            
        }

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            canvas.RenderCanvas();


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
                example.VSync = VSyncMode.On;
                example.Run(); //0.0, 0.0);
                //example.TargetRenderFrequency = 60;
            }
    /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
    }
    }
}
