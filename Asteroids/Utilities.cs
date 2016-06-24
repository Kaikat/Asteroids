using System;
using Microsoft.Xna.Framework;

namespace Asteroids
{
	public static class Utilities
	{
		public static Vector2 ApplyTorusMovement(Vector2 initialPosition)
		{
			Vector2 position = initialPosition;

			if (position.X > GameConstants.WINDOW_WIDTH) 
			{
				position.X = 0.0f;
			}

			if (position.X < 0.0f) 
			{
				position.X = GameConstants.WINDOW_WIDTH;
			}

			if (position.Y > GameConstants.WINDOW_HEIGHT) 
			{
				position.Y = 0.0f;
			}

			if (position.Y < 0.0f) 
			{
				position.Y = GameConstants.WINDOW_HEIGHT;
			}

			return position;
		}
	}
}

