using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class Weapon
	{
		private BulletType bulletType;
		private List<Bullet> bullets;

		public Weapon (BulletType bullet)
		{
			bulletType = bullet;
			bullets = new List<Bullet> ();
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			foreach (Bullet bullet in bullets) 
			{
				bullet.Draw (spriteBatch);
			}
		}

		public void Update(float deltaTime)
		{
			foreach (Bullet bullet in bullets) 
			{
				bullet.Update (deltaTime);
			}
		}

		public void Fire (Vector2 position, Vector2 velocity, Vector2 acceleration, float rotation)
		{
			Bullet bullet = new Bullet (bulletType, position, velocity, acceleration, rotation);
			bullets.Add (bullet);
		}
	}
}

