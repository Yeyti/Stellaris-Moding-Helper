using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwen;
using Gwen;
using Gwen.Control;
using Gwen.Control.Layout;

namespace SMH
{
    class ToolBar:Unit
    {
        public ToolBar(ControlBase c):base(c){
            Gwen.Control.Layout.VerticalLayout layout = new Gwen.Control.Layout.VerticalLayout(this);
            layout.HorizontalAlignment = HorizontalAlignment.Left;

            Button button;

            button = new Button(layout);
            button.Margin = Margin.Five;
            button.Text = "Open a ToolBar";
            button.Clicked += OpenToolBar;

            button = new Button(layout);
            button.Margin = Margin.Five;
            button.Text = "Open a tool window";
            button.Clicked += OpenToolWindow;
        }

        void OpenToolBar(ControlBase control, EventArgs args)
        {
            ToolWindow window = new ToolWindow(this);
            window.Padding = Padding.Five;
            window.HorizontalAlignment = HorizontalAlignment.Left;
            window.VerticalAlignment = VerticalAlignment.Top;
            window.StartPosition = StartPosition.CenterCanvas;

            HorizontalLayout layout = new HorizontalLayout(window);

            for (int i = 0; i < 5; i++)
            {
                Button button = new Button(layout);
                button.Size = new Size(36, 36);
                button.UserData = window;
                button.Clicked += Close;
            }
        }

        void OpenToolWindow(ControlBase control, EventArgs args)
        {
            ToolWindow window = new ToolWindow(this);
            window.Padding = Padding.Five;
            window.HorizontalAlignment = HorizontalAlignment.Left;
            window.VerticalAlignment = VerticalAlignment.Top;
            window.StartPosition = StartPosition.CenterParent;
            window.Vertical = true;

            GridLayout layout = new GridLayout(window);
            layout.ColumnCount = 2;

            Button button = new Button(layout);
            button.Size = new Size(100, 40);
            button.UserData = window;
            button.Clicked += Close;

            button = new Button(layout);
            button.Size = new Size(100, 40);
            button.UserData = window;
            button.Clicked += Close;

            button = new Button(layout);
            button.Size = new Size(100, 40);
            button.UserData = window;
            button.Clicked += Close;

            button = new Button(layout);
            button.Size = new Size(100, 40);
            button.UserData = window;
            button.Clicked += Close;
        }

        void Close(ControlBase control, EventArgs args)
        {
            ToolWindow window = UserData as ToolWindow;
            window.Close();
            window.Parent.RemoveChild(window, true);
        }
    }
}
