namespace GifAnimation.Pipeline
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
    using System;
    using Microsoft.Xna.Framework.Content.Pipeline;

    [ContentTypeWriter]
    internal class GifAnimationContentTypeWriter : ContentTypeWriter<GifAnimationContent>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(GifAnimationContentTypeReader).AssemblyQualifiedName;
        }

        protected override void Write(ContentWriter output, GifAnimationContent value)
        {
            output.Write(value.Frames.Length);
            for (int i = 0; i < value.Frames.Length; i++)
            {
                output.Write((int)value.Frames[i].__1__SurfaceFormat);
                output.Write(value.Frames[i].__2__Width);
                output.Write(value.Frames[i].__3__Height);
                output.Write(value.Frames[i].__4__Levels);
                output.Write(value.Frames[i].Data.Length);
                output.Write(value.Frames[i].Data);
                output.Flush();
            }
        }
    }
}

