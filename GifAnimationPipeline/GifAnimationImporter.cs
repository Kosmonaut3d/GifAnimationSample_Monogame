using System.Drawing.Imaging;
using GifAnimationPipeline;

namespace GifAnimation.Pipeline
{
    using Microsoft.Xna.Framework.Content.Pipeline;
    using System;
    using System.Drawing;
    using Microsoft.Xna.Framework.Graphics;

    [ContentImporter(".gif", DisplayName="Gif Animation Importer", DefaultProcessor="Gif Animation Processor")]
    internal class GifAnimationImporter : ContentImporter<GifAnimationContent>
    {
        public override GifAnimationContent Import(string filename, ContentImporterContext context)
        {
            GifAnimationContent content = new GifAnimationContent();
            Image source = Image.FromFile(filename);
            FrameDimension dimension = new FrameDimension(source.FrameDimensionsList[0]);
            int frameCount = source.GetFrameCount(dimension);
            content.Frames = new TextureData[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                source.SelectActiveFrame(dimension, i);
                byte[] buffer = Quantizer.Quantize(source);
                content.Frames[i].__1__SurfaceFormat = SurfaceFormat.Color;
                content.Frames[i].__2__Width = source.Width;
                content.Frames[i].__3__Height = source.Height;
                content.Frames[i].__4__Levels = 1;
                content.Frames[i].Data = buffer;
            }
            source.Dispose();
            return content;
        }
    }
}

