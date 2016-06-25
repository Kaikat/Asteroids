using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class Asteroid
	{
		public const int ASTEROID_WIDTH_SMALL = 100;
		public const int SMALL_ASTEROID_X = 170;
		public const int SMALL_ASTEROID_WH = 360;

		private AsteroidSize asteroidSize;
		private Vector2 asteroidPosition;
		private Rectangle asteroidTextureRectangle;
		private Vector2 origin;
		private float rotation;

		private float ROTATION_SPEED = 0.1f;
		private int ROTATE_DIRECTION;

		private int[] X_COORDS = { 170, 830, 1530, 2230, 200, 900, 1560, 2310 }; 
		private int[] WIDTHS   = { 360, 420,  420,  420, 300, 300,  370,  280 };
		private int[] Y_COORDS = { 170, 110,  110,  110, 860, 860,  840,  910 };
		private int[] HEIGHTS =  { 360, 440,  450,  460, 350, 360,  380,  250 };

		public Asteroid(Vector2 position, int rotateDirection, float rotateSpeed, AsteroidSize size)
		{
			asteroidSize = size;
			asteroidPosition = position;
			ROTATE_DIRECTION = rotateDirection;
			ROTATION_SPEED = rotateSpeed;

			rotation = 0.0f;
			SetTextureRectangle ();
			origin = new Vector2 (asteroidTextureRectangle.Width / 2.0f, asteroidTextureRectangle.Height / 2.0f);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.asteroidTextures, 
				new Rectangle((int)asteroidPosition.X, (int)asteroidPosition.Y, 
				ASTEROID_WIDTH_SMALL, ASTEROID_WIDTH_SMALL), asteroidTextureRectangle, 
				Color.White, rotation, origin, SpriteEffects.None, 0.0f);
		}

		public void Update(float deltaTime)
		{
			Rotate (deltaTime);
		}

		public void Rotate(float deltaTime)
		{
			rotation += (deltaTime * ROTATE_DIRECTION * ROTATION_SPEED);
		}

		private void SetTextureRectangle()
		{
			//asteroidSize = AsteroidSize.MEDIUM;
			switch (asteroidSize) 
			{
				case AsteroidSize.SMALL:
					asteroidTextureRectangle = new Rectangle (SMALL_ASTEROID_X, SMALL_ASTEROID_X, 
						SMALL_ASTEROID_WH, SMALL_ASTEROID_WH);
					break;
				case AsteroidSize.MEDIUM:
					asteroidTextureRectangle = new Rectangle (X_COORDS[7], Y_COORDS[7], 
						WIDTHS[7], HEIGHTS[7]);
					break;
				case AsteroidSize.LARGE:
					break;
			}
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