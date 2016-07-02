using System;
using Microsoft.Xna.Framework;

namespace Asteroids
{
	public class PhysicalData : Transform
	{
		public Vector2 velocity { get; set; }
		public Vector2 acceleration { get; set; }
		public Vector2 direction { get { return new Vector2 ((float)Math.Cos (rotation - Math.PI / 2.0f), 
															 (float)Math.Sin (rotation - Math.PI / 2.0f)); } 
								   set { ; } }
		private float maxSpeed;

		public PhysicalData (Vector2 position, Vector2 velocity, Vector2 acceleration, float rotation, Vector2 rotationOrigin, float maxSpeed)
		{
			this.position = position;
			this.velocity = velocity;
			this.acceleration = acceleration;
			this.rotation = rotation;
			this.rotationOrigin = rotationOrigin;
			this.maxSpeed = maxSpeed;
		}
			
		public void Update (float deltaTime, bool accelerate)
		{
			acceleration = accelerate ? direction * maxSpeed : Vector2.Zero;
			velocity += acceleration * deltaTime;
			position += velocity * deltaTime;

			//bulletData.acceleration += (bulletData.direction * 7.0f);
			//bulletData.velocity += bulletData.acceleration * deltaTime;
			// bulletData.position += bulletData.velocity * deltaTime;
		}

	}
}

