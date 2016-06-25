using System;

namespace Asteroids
{
	public enum AsteroidSize { SMALL, MEDIUM, LARGE };

	public static class GameConstants
	{
		public const int WINDOW_WIDTH = 800;
		public const int WINDOW_HEIGHT = 800;

		public const int MAP_SAFEZONE = 230;

		public const int LEVEL_1 = 0;
		public const int LEVEL_2 = 1;
		public const int LEVEL_3 = 2;

		public const int MAX_ASTEROIDS_IN_LEVEL_1 = 10;
		public const int MAX_ASTEROIDS_IN_LEVEL_2 = 20;
		public const int MAX_ASTEROIDS_IN_LEVEL_3 = 30;
	}
}

