using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Graphics;

namespace GifAnimationPipeline
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TextureData
    {
        public SurfaceFormat __1__SurfaceFormat;
        public int __2__Width;
        public int __3__Height;
        public int __4__Levels;
        public byte[] Data;
    }
}

