using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids
{
	public class Bullet
	{
		private int[] x_coords = { 40, 134, 242, 344, 439, 533, 630, 733, 840, 940,  37, 125, 242, 332, 432, 535, 635, 729 };
		private int[] y_coords = { 40,  40,  40,  35,  40,  40,  40,  40,  40,  40, 140, 140, 134, 143, 137, 144, 132, 129 };
		private int[] widths =   { 20,  34,  18,  13,  24,  34,  43,  34,  23,  24,  29,  55,  18,  37,  35,  50,  30,  45 };
		private int[] heights =  { 15,  17,  17,  32,  16,  22,  15,  23,  22,  18,  23,  20,  34,  15,  28,  14,  38,  42 };

		private int bulletID;
		private Rectangle bulletTextureRectangle;
		private int bulletDrawSize;

		private PhysicalData bulletData;

		public Bullet (BulletType bulletType, Vector2 position, Vector2 velocity, float rotation)
		{
			bulletID = (int) bulletType;
			bulletDrawSize = 20;

			bulletTextureRectangle = new Rectangle (x_coords [bulletID], y_coords [bulletID], 
				widths [bulletID], heights [bulletID]);
			
			bulletData = new PhysicalData (position, velocity, rotation,
				new Vector2 (bulletTextureRectangle.Width / 2.0f, bulletTextureRectangle.Height / 2.0f));
		}

		public Bullet(BulletType bulletType, PhysicalData data)
		{
			bulletData = data;
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.bulletTexture, 
				new Rectangle((int)bulletData.position.X, (int)bulletData.position.Y, 
				bulletDrawSize, bulletDrawSize), bulletTextureRectangle, 
				Color.White, -(float)Math.PI/2.0f + bulletData.rotation, bulletData.rotationOrigin, SpriteEffects.None, 0.0f);
		}

		public void Update (float deltaTime)
		{
			bulletData.acceleration = (bulletData.direction * GameConstants.BULLET_MAX_SPEED);
			bulletData.Update (deltaTime);
		}

		public bool IsOffScreen()
		{
			return bulletData.position.X > GameConstants.WINDOW_WIDTH  || bulletData.position.X < 0 ||
				   bulletData.position.Y > GameConstants.WINDOW_HEIGHT || bulletData.position.Y < 0;
		}
	}
}

