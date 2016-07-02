using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
	public class Ship
	{
		private const int SHIP_WIDTH = 100;
		private const int SHIP_HEIGHT = 67;

		private PhysicalData shipData;
		private Rectangle shipTextureRectangle;
		private bool[] keyPressed;

		private Weapon weapon;

		const int NUM_MOVEMENTS = 3;
		const int UP = 0;
		const int RIGHT = 1;
		const int LEFT = 2;
		const float ROTATION_SPEED = 5.0f;

		//height 41 to 190
		//width 0 to 227

		public Ship ()
		{
			float x_pos = ((float)GameConstants.WINDOW_WIDTH / 2.0f) - (SHIP_WIDTH / 2.0f);
			float y_pos = (float)GameConstants.WINDOW_HEIGHT - SHIP_HEIGHT;

			keyPressed = new bool[NUM_MOVEMENTS];
			for (int i = 0; i < NUM_MOVEMENTS; i++) 
			{
				keyPressed [i] = false;
			}

			shipTextureRectangle = new Rectangle (0, 41, 227, 149);

			shipData = new PhysicalData (new Vector2 (x_pos, y_pos), new Vector2 (0.0f, 0.5f), Vector2.Zero, 0.0f,
				new Vector2 (shipTextureRectangle.Width / 2.0f, shipTextureRectangle.Height / 2.0f), GameConstants.SHIP_MAX_SPEED);
			
			weapon = new Weapon (BulletType.MINI);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.shipTexture, 
				new Rectangle((int)shipData.position.X, (int)shipData.position.Y, SHIP_WIDTH, SHIP_HEIGHT), 
				shipTextureRectangle, Color.White, shipData.rotation, shipData.rotationOrigin, SpriteEffects.None, 0.0f);
			
			weapon.Draw (spriteBatch);
		}

		public void Update(float deltaTime)
		{			
			shipData.Update (deltaTime, keyPressed [UP]);
			shipData.position = Utilities.ApplyTorusMovement(shipData.position);

			if (keyPressed [RIGHT]) 
			{
				RotateShip (deltaTime, 1.0f);
			}
			if (keyPressed [LEFT]) 
			{
				RotateShip (deltaTime, -1.0f);
			}

			weapon.Update (deltaTime);
		}

		public void RotateShip(float deltaTime, float angleDirection)
		{
			shipData.rotation += (deltaTime * angleDirection * ROTATION_SPEED);
		}

		public void MoveKeyPressed(Keys key)
		{
			switch (key) 
			{
				case Keys.Up:
					keyPressed [UP] = true;
					break;

				case Keys.Right:
					keyPressed [RIGHT] = true;
					break;

				case Keys.Left:
					keyPressed [LEFT] = true;
					break;
			}
		}

		public void MoveKeyReleased(Keys key)
		{
			switch (key) 
			{
				case Keys.Up:
					keyPressed [UP] = false;
				break;

				case Keys.Right:
					keyPressed [RIGHT] = false;
				break;

				case Keys.Left:
					keyPressed [LEFT] = false;
				break;

				default:
					break;
			}
		}

		public void FireKeyPressed(Keys key)
		{
			weapon.Fire (shipData.position + (shipData.direction * new Vector2(SHIP_HEIGHT/2.0f, SHIP_HEIGHT/2.0f)), 
				shipData.velocity, shipData.acceleration, shipData.rotation);
		}
	}
}