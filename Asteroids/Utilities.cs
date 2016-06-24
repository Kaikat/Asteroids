using System;
using Microsoft.Xna.Framework;

namespace Asteroids
{
	public static class Utilities
	{
		public static Vector2 ApplyTorusMovement(Vector2 initialPosition, int windowWidth, int windowHeight)
		{
			Vector2 position = initialPosition;

			if (position.X > windowWidth) 
			{
				position.X = 0.0f;
			}

			if (position.X < 0.0f) 
			{
				position.X = windowWidth;
			}

			if (position.Y > windowHeight) 
			{
				position.Y = 0.0f;
			}

			if (position.Y < 0.0f) 
			{
				position.Y = windowHeight;
			}

			return position;
		}
	}
}

