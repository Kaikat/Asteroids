using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class Asteroid
	{
		private Vector2 asteroidPosition;
		private Rectangle asteroidTextureRectangle;
		private Vector2 origin;
		private float rotation;

		private int ASTEROID_WIDTH = 100;
		private float ROTATION_SPEED = 0.1f;
		private int ROTATE_DIRECTION;

		private Random RANDOM;

		//170-530
		public Asteroid ()
		{
			RANDOM = new Random ();

			rotation = 0.0f;

			asteroidTextureRectangle = new Rectangle (170, 170, 530 - 170, 530 - 170);
			asteroidPosition = Vector2.Zero;
			origin = new Vector2 (asteroidTextureRectangle.Width / 2.0f, asteroidTextureRectangle.Height / 2.0f);

			ROTATE_DIRECTION = RANDOM.Next () > 0 ? 1 : -1;
		}

		public Asteroid(Vector2 position, int rotateDirection, float rotateSpeed)
		{
			asteroidPosition = position;
			ROTATE_DIRECTION = rotateDirection;
			ROTATION_SPEED = rotateSpeed;

			rotation = 0.0f;
			asteroidTextureRectangle = new Rectangle (170, 170, 530 - 170, 530 - 170);
			origin = new Vector2 (asteroidTextureRectangle.Width / 2.0f, asteroidTextureRectangle.Height / 2.0f);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.asteroidTextures, 
				new Rectangle((int)asteroidPosition.X, (int)asteroidPosition.Y, ASTEROID_WIDTH, ASTEROID_WIDTH), 
				asteroidTextureRectangle, Color.White, rotation, origin, SpriteEffects.None, 0.0f);
		}

		public void Update(float deltaTime)
		{
			Rotate (deltaTime);
		}

		public void Rotate(float deltaTime)
		{
			rotation += (deltaTime * ROTATE_DIRECTION * ROTATION_SPEED);
		}
	}
}

