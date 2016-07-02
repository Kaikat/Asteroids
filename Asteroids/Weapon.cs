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
			for (int i = bullets.Count - 1; i >= 0; i--) 
			{
				if (bullets [i].IsOffScreen ()) 
				{
					bullets.RemoveAt (i);
				}
			}

			foreach (Bullet bullet in bullets) 
			{
				bullet.Update (deltaTime);
			}

			Console.WriteLine(bullets.Count);
		}

		public void Fire (Vector2 position, Vector2 velocity, float rotation)
		{
			Bullet bullet = new Bullet (bulletType, position, velocity, rotation);
			bullets.Add (bullet);
		}
	}
}

