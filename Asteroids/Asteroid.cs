﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class Asteroid
	{
		public AsteroidSize asteroidSize { private set; get; }

		private Transform transform;
		private Rectangle asteroidTextureRectangle;
		private float rotationSpeed = 0.1f;
		private int rotationDirection;

		public Vector2 origin { private set; get; }
		public float radius { private set; get; } 


		public int health;
		public bool alive;


		public Asteroid(Vector2 position, int rotateDirection, float rotateSpeed, 
			AsteroidSize size, Rectangle textureRectangle, int drawSize)
		{
			asteroidTextureRectangle = textureRectangle;
			rotationDirection = rotateDirection;
			rotationSpeed = rotateSpeed;
			asteroidSize = size;
			transform = new Transform (position, 0.0f, drawSize, 
				new Vector2 (asteroidTextureRectangle.Width / 2.0f, asteroidTextureRectangle.Height / 2.0f));
			origin = new Vector2 (position.X + drawSize / 2.0f, 
								  position.Y + drawSize / 2.0f);
			radius = drawSize / 2.0f;

			alive = true;
			if (asteroidSize == AsteroidSize.LARGE) 
			{
				health = 3;
			}
			else if (asteroidSize == AsteroidSize.MEDIUM) 
			{
				health = 2;
			} 
			else if (asteroidSize == AsteroidSize.SMALL) 
			{
				health = 1;
			} 
			else 
			{
				health = 0;
			}
			GetSize (asteroidSize);
			Console.WriteLine ("MY HEALTH: " + health);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.asteroidTextures, 
				new Rectangle((int)transform.position.X, (int)transform.position.Y, 
				transform.scale, transform.scale), asteroidTextureRectangle, 
				Color.White, transform.rotation, transform.rotationOrigin, SpriteEffects.None, 0.0f);
		}

		public void Update(float deltaTime)
		{
			Rotate (deltaTime);
		}

		public void Rotate(float deltaTime)
		{
			transform.rotation += (deltaTime * rotationDirection * rotationSpeed);
		}

		public bool DecrementHealth()
		{
			health--;

			if (health <= 0) 
			{
				alive = false;
			}

			//returns whether the asteroid was destroid
			return !alive; 
		}


		//For debugging. Remove
		private void GetSize(AsteroidSize size)
		{
			switch (size) {
				case AsteroidSize.SMALL:
					Console.WriteLine ("SMALL");
					return;

				case AsteroidSize.MEDIUM:
					Console.WriteLine ("MEDIUM");
					return;

				case AsteroidSize.LARGE:
					Console.WriteLine ("LARGE");
					return;

				default:
					Console.WriteLine ("ERROR: Invalid Asteroid Size Passed to AsteroidManager.GetSize()");
					return;
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