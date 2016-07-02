using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class AsteroidManager
	{
		private const int SMALL_ASTEROID_SIZE = 50;
		private const int MEDIUM_ASTEROID_SIZE = 100;
		private const int LARGE_ASTEROID_SIZE = 150;

		private int[] x_coords = { 170, 830, 1530, 2230, 200, 900, 1560, 2310 }; 
		private int[] widths   = { 360, 420,  420,  420, 300, 300,  370,  280 };
		private int[] y_coords = { 170, 110,  110,  110, 860, 860,  840,  910 };
		private int[] heights =  { 360, 440,  450,  460, 350, 360,  380,  250 };

		private List<Asteroid> asteroids;
		private Random RANDOM;

		public AsteroidManager (int level)
		{
			RANDOM = new Random ();
			asteroids = new List<Asteroid>();

			int maxAsteroids = GetMaxAsteroidsInLevel (level);
			GenerateAsteroids (maxAsteroids, AsteroidSize.LARGE);
		}

		public void Initialize()
		{
			RANDOM = new Random ();
			asteroids = new List<Asteroid>();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Asteroid asteroid in asteroids) 
			{
				asteroid.Draw (spriteBatch);
			}
		}

		public void Update(float deltaTime)
		{
			foreach (Asteroid asteroid in asteroids) 
			{
				asteroid.Update (deltaTime);
			}
			//for (int i = asteroids.Count - 1; i >= 0; i--) 
			//{
				/*if (!asteroids [i].alive) 
				{
					asteroids.RemoveAt (i);
					continue;
				}*/
			//	asteroids [i].Update (deltaTime);
			//}
		}

		public int GetAsteroidCount()
		{
			return asteroids.Count;
		}

		public float GetAsteroidRadiusAt(int index)
		{
			return asteroids [index].radius;
		}

		public Vector2 GetAsteroidOriginAt(int index)
		{
			return asteroids [index].origin;
		}

		public bool DecrementAsteroidHealthAt(int index)
		{
			bool alive = asteroids [index].DecrementHealth ();

			if (!alive) 
			{
				BreakAsteroidAt (index);
				asteroids.RemoveAt (index);
			}

			//return if asteroid was destroyed
			return !alive;
		}

		private void BreakAsteroidAt(int index)
		{
			switch(asteroids [index].asteroidSize)
			{
				case AsteroidSize.LARGE:
					CreateAsteroid (7, AsteroidSize.MEDIUM, asteroids [index].GetPositionToRight ());
					CreateAsteroid (7, AsteroidSize.MEDIUM, asteroids [index].GetPositionToLeft ());
					break;

				case AsteroidSize.MEDIUM:
					CreateAsteroid (7, AsteroidSize.SMALL, asteroids [index].GetPositionToRight ());
					CreateAsteroid (7, AsteroidSize.SMALL, asteroids [index].GetPositionToLeft ());
					CreateAsteroid (7, AsteroidSize.SMALL, asteroids [index].GetPositionBelow ());
					break;

				//Small Ones Just Disappear
				default:
					break;
			}
		}

		private void RemoveAsteroidAt(int index)
		{
			asteroids.RemoveAt (index);
		}
			
		private void GenerateAsteroids(int numAsteroids, AsteroidSize asteroidSize)
		{
			
			for(int asteroid = 0; asteroid < numAsteroids; asteroid++) 
			{
				CreateAsteroid (7, asteroidSize);
			}
		}

		private void CreateAsteroid(int asteroidIndex, AsteroidSize asteroidSize)
		{
			float rotateSpeed = RANDOM.Next (1, 11) / 30.0f;
			int rotateDirection = RANDOM.Next () > 0 ? 1 : -1;

			Vector2 position = new Vector2(RANDOM.Next (GetSize (asteroidSize) / 2, GameConstants.WINDOW_WIDTH - GetSize (asteroidSize) / 2),
				RANDOM.Next(70, GameConstants.WINDOW_HEIGHT - GameConstants.MAP_SAFEZONE));

			Rectangle textureRectangle = 
				new Rectangle (x_coords[asteroidIndex], y_coords[asteroidIndex], 
				widths[asteroidIndex], heights[asteroidIndex]);

			Asteroid asteroid = new Asteroid (position, rotateDirection, rotateSpeed, 
				asteroidSize, textureRectangle, GetSize(asteroidSize));
			
			asteroids.Add (asteroid);
		}

		private void CreateAsteroid(int asteroidIndex, AsteroidSize asteroidSize, Vector2 position)
		{
			float rotateSpeed = RANDOM.Next (1, 11) / 30.0f;
			int rotateDirection = RANDOM.Next () > 0 ? 1 : -1;

			position = Utilities.ApplyTorusMovement (position);
			position = MoveInView (position, GetSize (asteroidSize));

			Rectangle textureRectangle = 
				new Rectangle (x_coords[asteroidIndex], y_coords[asteroidIndex], 
					widths[asteroidIndex], heights[asteroidIndex]);

			Asteroid asteroid = new Asteroid (position, rotateDirection, rotateSpeed, 
				asteroidSize, textureRectangle, GetSize(asteroidSize));

			asteroids.Add (asteroid);
		}

		private Vector2 MoveInView(Vector2 position, float size)
		{
			if (position.X == 0) 
			{
				position.X = size / 2.0f;
			}
			if (position.X == GameConstants.WINDOW_WIDTH) 
			{
				position.X -= size / 2.0f;
			}
			if (position.Y == 0) 
			{
				position.Y = size / 2.0f;
			}
			if (position.Y == GameConstants.WINDOW_HEIGHT) 
			{
				position.Y -= size / 2.0f;
			}

			return position;
		}

		private int GetSize(AsteroidSize size)
		{
			switch (size) 
			{
				case AsteroidSize.SMALL:
					Console.WriteLine ("SMALL");
					return SMALL_ASTEROID_SIZE;

				case AsteroidSize.MEDIUM:
					Console.WriteLine ("MEDIUM");
					return MEDIUM_ASTEROID_SIZE;

				case AsteroidSize.LARGE:
					Console.WriteLine ("LARGE");
					return LARGE_ASTEROID_SIZE;

				default:
					Console.WriteLine ("ERROR: Invalid Asteroid Size Passed to AsteroidManager.GetSize()");
					return 0;
			}
		}
		
		private int GetMaxAsteroidsInLevel(int level)
		{
			switch (level) 
			{
				case GameConstants.LEVEL_1:
					return GameConstants.MAX_ASTEROIDS_IN_LEVEL_1;
				case GameConstants.LEVEL_2:
					return GameConstants.MAX_ASTEROIDS_IN_LEVEL_2;
				case GameConstants.LEVEL_3:
					return GameConstants.MAX_ASTEROIDS_IN_LEVEL_3;
				default:
					Console.WriteLine ("ERROR: Invalid Level Passed to AsteroidManager");
					return 0;
			}
		}
	}
}

