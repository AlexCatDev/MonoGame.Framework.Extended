using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace MonoGame.Framework.Extended
{
    public static class TextureHelper
    {
        public static Texture2D Texture2DFromPath(string path, GraphicsDevice device, SamplerState samplerState, bool mipMap = true) {
            using (FileStream fs = File.Open(path, FileMode.Open)) {
                Texture2D loadedTexture = Texture2D.FromStream(device, fs);

                Texture2D outputTexture = null;
                RenderTarget2D renderTarget = new RenderTarget2D(device, loadedTexture.Width, loadedTexture.Height, mipMap: mipMap, preferredFormat: SurfaceFormat.Color, preferredDepthFormat: DepthFormat.None);

                BlendState blendState = BlendState.Opaque;

                device.SetRenderTarget(renderTarget);
                using (SpriteBatch sprite = new SpriteBatch(device)) {
                    sprite.Begin(SpriteSortMode.Immediate, blendState, samplerState, DepthStencilState.None, RasterizerState.CullNone,
                    effect: null);
                    sprite.Draw(loadedTexture, new Vector2(0, 0), Color.White);
                    sprite.End();
                }

                outputTexture = (Texture2D)renderTarget;
                device.SetRenderTarget(null);
                loadedTexture.Dispose();
                return outputTexture;
            }
        }

        public static Texture2D Texture2DFromPath(string path, GraphicsDevice device, SamplerState samplerState, Effect effect, bool mipMap = true) {
            using (FileStream fs = File.Open(path, FileMode.Open)) {
                Texture2D loadedTexture = Texture2D.FromStream(device, fs);

                Texture2D outputTexture = null;
                RenderTarget2D renderTarget = new RenderTarget2D(device, loadedTexture.Width, loadedTexture.Height, mipMap: mipMap, preferredFormat: SurfaceFormat.Color, preferredDepthFormat: DepthFormat.None);

                BlendState blendState = BlendState.Opaque;

                device.SetRenderTarget(renderTarget);
                using (SpriteBatch sprite = new SpriteBatch(device)) {
                    sprite.Begin(SpriteSortMode.Immediate, blendState, samplerState, DepthStencilState.None, RasterizerState.CullNone,
                    effect: effect);
                    sprite.Draw(loadedTexture, new Vector2(0, 0), Color.White);
                    sprite.End();
                }

                outputTexture = (Texture2D)renderTarget;
                device.SetRenderTarget(null);
                loadedTexture.Dispose();
                return outputTexture;
            }
        }

        public static Texture2D Texture2DFromPath(string path, GraphicsDevice device, bool mipMap = true) {
            using (FileStream fs = File.Open(path, FileMode.Open)) {
                Texture2D loadedTexture = Texture2D.FromStream(device, fs);

                Texture2D outputTexture = null;
                RenderTarget2D renderTarget = new RenderTarget2D(device, loadedTexture.Width, loadedTexture.Height, mipMap: mipMap, preferredFormat: SurfaceFormat.Color, preferredDepthFormat: DepthFormat.None);

                BlendState blendState = BlendState.Opaque;

                device.SetRenderTarget(renderTarget);
                using (SpriteBatch sprite = new SpriteBatch(device)) {
                    sprite.Begin(SpriteSortMode.Immediate, blendState, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone,
                    effect: null);
                    sprite.Draw(loadedTexture, new Vector2(0, 0), Color.White);
                    sprite.End();
                }

                outputTexture = (Texture2D)renderTarget;
                device.SetRenderTarget(null);
                loadedTexture.Dispose();
                return outputTexture;
            }
        }

        public static Texture2D GetBlankTexture(GraphicsDevice device, int width = 2, int height = 2) {
            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; i++) {
                data[i] = Color.White;
            }
            Texture2D texture = new Texture2D(device, width, height);
            texture.SetData<Color>(data);

            return texture;
        }
    }
}