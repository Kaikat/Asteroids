using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class AsteroidManager
	{
		private List<Asteroid> asteroids;
		private Random RANDOM;

		public AsteroidManager (int level)
		{
			RANDOM = new Random ();
			asteroids = new List<Asteroid>();

			int maxAsteroids = GetMaxAsteroidsInLevel (level);
			GenerateAsteroids (maxAsteroids);
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
		}

		private void GenerateAsteroids(int numAsteroids)
		{
			for(int asteroid = 0; asteroid < numAsteroids; asteroid++) 
			{
				CreateAsteroid ();
			}
		}

		private void CreateAsteroid()
		{
			Vector2 position = new Vector2 (RANDOM.Next () % GameConstants.WINDOW_WIDTH, 
				RANDOM.Next () % GameConstants.WINDOW_HEIGHT - GameConstants.MAP_SAFEZONE);
			
			int rotateDirection = RANDOM.Next () > 0 ? 1 : -1;
			float rotateSpeed = RANDOM.Next (1, 11) / 30.0f;

			Asteroid asteroid = new Asteroid (position, rotateDirection, rotateSpeed, AsteroidSize.SMALL);
			asteroids.Add (asteroid);
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

