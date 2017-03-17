namespace GifAnimation
{
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class GifAnimation
    {
        private int m_CurrentFrame;
        private long m_CurrentTick;
        private bool m_IsPaused;
        private bool m_IsStopped;
        private Texture2D[] m_Textures;

        private GifAnimation()
        {
        }

        public static GifAnimation FromTextures(Texture2D[] frames)
        {
            return new GifAnimation { m_Textures = frames };
        }

        public Texture2D GetTexture()
        {
            return this.m_Textures[this.m_CurrentFrame];
        }

        public Texture2D GetTexture(int frameIndex)
        {
            return this.m_Textures[frameIndex];
        }

        public void Pause()
        {
            this.m_IsPaused = true;
        }

        public void Play()
        {
            this.m_CurrentFrame = 0;
            this.m_IsPaused = false;
            this.m_IsStopped = false;
        }

        public void Resume()
        {
            this.m_IsPaused = false;
        }

        public void Stop()
        {
            this.m_CurrentFrame = 0;
            this.m_IsPaused = false;
            this.m_IsStopped = true;
        }

        public override string ToString()
        {
            return string.Format("Playing frame {0} of {1} -- {2:F}%", this.m_CurrentFrame, this.FrameCount, (100f * this.m_CurrentFrame) / ((float) this.FrameCount));
        }

        public void Update(long elapsedTicks)
        {
            if (!this.m_IsPaused && !this.m_IsStopped)
            {
                this.m_CurrentTick += elapsedTicks;
                if (this.m_CurrentTick >= 0xf4240L)
                {
                    this.m_CurrentTick = 0L;
                    this.m_CurrentFrame++;
                    if (this.m_CurrentFrame >= this.m_Textures.Length)
                    {
                        this.m_CurrentFrame = 0;
                    }
                }
            }
        }

        public int CurrentFrame
        {
            get
            {
                return this.m_CurrentFrame;
            }
        }

        public int FrameCount
        {
            get
            {
                return this.m_Textures.Length;
            }
        }

        public int Height
        {
            get
            {
                return this.m_Textures[0].Height;
            }
        }

        public int Width
        {
            get
            {
                return this.m_Textures[0].Width;
            }
        }
    }
}

