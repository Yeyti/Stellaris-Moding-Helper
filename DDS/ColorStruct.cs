using System.Runtime.InteropServices;

namespace DDSSuply
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Colour8888
    {
        public byte red;
        public byte green;
        public byte blue;
        public byte alpha;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Colour565
    {
        public ushort blue; //: 5;
        public ushort green; //: 6;
        public ushort red; //: 5;
    }
}
