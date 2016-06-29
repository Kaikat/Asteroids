using System;
using Microsoft.Xna.Framework;

namespace Asteroids
{
	public class PhysicalData
	{
		public Vector2 position { get; set; }
		public Vector2 velocity { get; set; }
		public Vector2 acceleration { get; set; }
		public Vector2 direction { get { return new Vector2 ((float)Math.Cos (rotation - Math.PI / 2.0f), 
															 (float)Math.Sin (rotation - Math.PI / 2.0f)); } 
								   set { ; } }
		public Vector2 rotationOrigin { get; set; }
		public float rotation;

		public PhysicalData (Vector2 position, Vector2 velocity, Vector2 acceleration, float rotation, Vector2 rotationOrigin)
		{
			this.position = position;
			this.velocity = velocity;
			this.acceleration = acceleration;
			this.rotation = rotation;
			this.rotationOrigin = rotationOrigin;
		}
	}
}

