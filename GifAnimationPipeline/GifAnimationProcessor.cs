namespace GifAnimation.Pipeline
{
    using Microsoft.Xna.Framework.Content.Pipeline;

    [ContentProcessor(DisplayName="Gif Animation Processor")]
    internal class GifAnimationProcessor : ContentProcessor<GifAnimationContent, GifAnimationContent>
    {
        public override GifAnimationContent Process(GifAnimationContent input, ContentProcessorContext context)
        {
            return input;
        }
    }
}

