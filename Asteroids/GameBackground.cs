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
			spriteBatch.Draw (TextureManager.backgroundTexture[level], 
				new Rectangle (0, 0, GameConstants.WINDOW_WIDTH, GameConstants.WINDOW_HEIGHT),
				new Rectangle(0, 0, 1024, 4024), Color.White);
		}

		private void NextLevel()
		{
			level += 1;
		}
	}
}

