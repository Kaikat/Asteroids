using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Asteroids
{
	public class AsteroidManager
	{
		private List<Asteroid> asteroids;
		private Random RANDOM;

		public AsteroidManager ()
		{
			RANDOM = new Random ();
		}

		private void CreateAsteroid()
		{
			Vector2 position = new Vector2 (RANDOM.Next () % GameConstants.WINDOW_WIDTH, RANDOM.Next () % GameConstants.WINDOW_HEIGHT);
			int rotateDirection = RANDOM.Next () > 0 ? 1 : -1;
			float rotateSpeed = RANDOM.Next (1, 11) / 1000.0f;

			Asteroid asteroid = new Asteroid (position, rotateDirection, rotateSpeed);
			asteroids.Add (asteroid);
		}
	}
}

