using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class GameBackground
	{
		private int level;

		public GameBackground ()
		{
			level = 0;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (TextureManager.backgroundTexture[level], new Vector2(0,0), Color.White);
		}

		private void NextLevel()
		{
			level += 1;
		}
	}
}

