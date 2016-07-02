using System;

namespace Asteroids
{
	public enum AsteroidSize { SMALL, MEDIUM, LARGE };
	public enum BulletType { X, MISSILE, MINI, WIDE_ARROW, NORMAL, DIAMOND, LASER, 
		SHARP, UPDOWN, BOW, SHURIKEN, ZIGZAG, THIN_ARROW, ARROW, SPLIT_ARROW, KNIFE,
		SEPARATE_ARROW, BIG_ARROW };

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

		public const float SHIP_MAX_SPEED = 20.0f;
		public const float BULLET_MAX_SPEED = 250.0f;
	}
}

