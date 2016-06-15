using System.Runtime.InteropServices;

namespace DDSSuply
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DDSStruct
    {
        public uint size;       // equals size of struct (which is part of the data file!)
        public uint flags;
        public uint height;
        public uint width;
        public uint sizeorpitch;
        public uint depth;
        public uint mipmapcount;
        public uint alphabitdepth;

        //[MarshalAs(UnmanagedType.U4, SizeConst = 11)]
        public uint[] reserved;//[11];

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct pixelformatstruct
        {
            public uint size;   // equals size of struct (which is part of the data file!)
            public uint flags;
            public uint fourcc;
            public uint rgbbitcount;
            public uint rbitmask;
            public uint gbitmask;
            public uint bbitmask;
            public uint alphabitmask;
        }

        public pixelformatstruct pixelformat;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ddscapsstruct
        {
            public uint caps1;
            public uint caps2;
            public uint caps3;
            public uint caps4;
        }

        public ddscapsstruct ddscaps;
        public uint texturestage;
    }
}
