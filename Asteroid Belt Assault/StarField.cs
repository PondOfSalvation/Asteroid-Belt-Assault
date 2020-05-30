using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid_Belt_Assault
{
    class StarField
    {
        List<Sprite> stars = new List<Sprite>();
        int screenWidth = 800;
        int screenHeight = 600;
        Random rand = new Random();
        Color[] colors = { Color.White, Color.Yellow, Color.Wheat, Color.WhiteSmoke, Color.SlateGray };

        public StarField(int screenWidth, int screenHeight, int starCount, Vector2 starVelocity, Texture2D texture, Rectangle frameRectangle)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            for (int x=0;x<starCount;++x)
            {
                stars.Add(new Sprite(new Vector2(rand.Next(screenWidth), rand.Next(screenHeight)),
                    texture, frameRectangle, starVelocity));
                Color starColor = colors[rand.Next(colors.Count())];
                starColor *= (rand.Next(30, 80) / 100f);
                stars[stars.Count() - 1].TintColor = starColor;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite star in stars)
            {
                star.Update(gameTime);
                if (star.Location.Y > screenHeight)
                {
                    star.Location = new Vector2(rand.Next(screenWidth), 0);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite star in stars)
            {
                star.Draw(spriteBatch);
            }
        }
    }
}
