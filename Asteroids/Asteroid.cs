using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class Asteroid
	{
		public AsteroidSize asteroidSize { private set; get; }

		private Rectangle asteroidTextureRectangle;
		private Vector2 asteroidPosition;
		private int asteroidDrawSize;
		private Vector2 origin;
		private float rotation;

		private float rotationSpeed = 0.1f;
		private int rotationDirection;

		public Asteroid(Vector2 position, int rotateDirection, float rotateSpeed, 
			AsteroidSize size, Rectangle textureRectangle, int drawSize)
		{
			asteroidTextureRectangle = textureRectangle;
			rotationDirection = rotateDirection;
			asteroidPosition = position;
			asteroidDrawSize = drawSize;
			rotationSpeed = rotateSpeed;
			asteroidSize = size;

			rotation = 0.0f;
			origin = new Vector2 (asteroidTextureRectangle.Width / 2.0f, asteroidTextureRectangle.Height / 2.0f);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.asteroidTextures, 
				new Rectangle((int)asteroidPosition.X, (int)asteroidPosition.Y, 
				asteroidDrawSize, asteroidDrawSize), asteroidTextureRectangle, 
				Color.White, rotation, origin, SpriteEffects.None, 0.0f);
		}

		public void Update(float deltaTime)
		{
			Rotate (deltaTime);
		}

		public void Rotate(float deltaTime)
		{
			rotation += (deltaTime * rotationDirection * rotationSpeed);
		}
	}
}

//y = 170 - 530
//y = 110 - 550
//y = 110 - 560
//y = 110 - 570

//y = 860- 1210 = 350
//y = 860- 1220
//y = 840- 1210
//y = 910 - 1160



//x = 830-1250
//x = 1530-1950
//x = 2230-2650

//x = 200-500
//x = 900-1200
//x = 1560-1930
//x = 2310-2590