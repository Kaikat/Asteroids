using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Asteroids
{
	public class GameBackground
	{
		private Texture2D[] backgroundTexture;
		private int level;

		public GameBackground ()
		{
			backgroundTexture = new Texture2D[3];
			level = 0;
		}

		public void LoadContent(ContentManager content)
		{
			backgroundTexture [0] = content.Load<Texture2D>("Level1BG");
			backgroundTexture [1] = content.Load<Texture2D>("Level2BG");
			backgroundTexture [2] = content.Load<Texture2D>("Level3BG");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (backgroundTexture[level], new Vector2(0,0), Color.White);
		}

		private void NextLevel()
		{
			level += 1;
		}
	}
}

