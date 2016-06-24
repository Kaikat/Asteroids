using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public static class TextureManager
	{
		public static Texture2D[] backgroundTexture { private set; get; }
		public static Texture2D shipTexture { private set; get; }
		public static Texture2D asteroidTextures { private set; get; }

		public static void LoadContent(ContentManager content)
		{
			backgroundTexture = new Texture2D[3];
			backgroundTexture [0] = content.Load<Texture2D>("Level1BG");
			backgroundTexture [1] = content.Load<Texture2D>("Level2BG");
			backgroundTexture [2] = content.Load<Texture2D>("Level3BG");

			shipTexture = content.Load<Texture2D> ("DisplayShips");
			asteroidTextures = content.Load<Texture2D> ("PlanetSprites");
		}

	}
}