﻿using System;
using Microsoft.Xna.Framework;

namespace Asteroids
{
	public class Transform
	{
		public Vector2 position { get; set; }
		public Vector2 rotationOrigin { get; set; }

		public float rotation { get; set; }
		public int scale { get; set; }

		public Transform()
		{
		}

		public Transform (Vector2 position, float rotation, int scale, Vector2 rotationOrigin)
		{
			this.position = position;
			this.rotation = rotation;
			this.scale = scale;
			this.rotationOrigin = rotationOrigin;
		}
	}
}

