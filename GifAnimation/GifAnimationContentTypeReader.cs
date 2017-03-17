namespace GifAnimation
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using Microsoft.Xna.Framework;

    public sealed class GifAnimationContentTypeReader : ContentTypeReader<GifAnimation>
    {
        protected override GifAnimation Read(ContentReader input, GifAnimation existingInstance)
        {
            int num = input.ReadInt32();
            Texture2D[] frames = new Texture2D[num];
            IGraphicsDeviceService service = (IGraphicsDeviceService) input.ContentManager.ServiceProvider.GetService(typeof(IGraphicsDeviceService));
            if (service == null)
            {
                throw new ContentLoadException();
            }
            GraphicsDevice graphicsDevice = service.GraphicsDevice;
            if (graphicsDevice == null)
            {
                throw new ContentLoadException();
            }
            for (int i = 0; i < num; i++)
            {
                SurfaceFormat format = (SurfaceFormat) input.ReadInt32();
                int width = input.ReadInt32();
                int height = input.ReadInt32();
                int numberLevels = input.ReadInt32();
                frames[i] = new Texture2D(graphicsDevice, width, height, false, format);
                for (int j = 0; j < numberLevels; j++)
                {
                    int count = input.ReadInt32();
                    byte[] data = input.ReadBytes(count);
                    Rectangle? rect = null;
                    frames[i].SetData<byte>(j, rect, data, 0, data.Length);
                }
            }
            input.Close();
            return GifAnimation.FromTextures(frames);
        }
    }
}

