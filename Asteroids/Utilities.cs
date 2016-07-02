using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
			
		public static bool Collided(float radius1, float radius2, Vector2 centerPosition1, Vector2 centerPosition2)
		{
			float distance = (float) Math.Sqrt (Math.Pow ((centerPosition2.X - centerPosition1.X), 2.0f) +
								     Math.Pow ((centerPosition2.Y - centerPosition1.Y), 2.0f)); 
			return distance < (radius1 + radius2);
		}
	}
}

