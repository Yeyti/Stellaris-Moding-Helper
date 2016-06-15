using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace SMH
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public float x, y;
        public float r, g, b;

        public Vertex(float x, float y, Color4 color)
        {
            this.x = x; this.y = y;
            r = color.R; g = color.G; b = color.B;
        }
    }
}
