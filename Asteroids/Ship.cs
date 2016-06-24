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

		private Vector2 shipPosition;
		private Vector2 shipVelocity;
		private Vector2 shipAcceleration;
		private Vector2 origin;
		private Rectangle shipTextureRectangle;
		private float rotation;
		private bool[] keyPressed;

		const int NUM_MOVEMENTS = 3;
		const int UP = 0;
		const int RIGHT = 1;
		const int LEFT = 2;
		const float ROTATION_SPEED = 5.0f;
		const float MAX_SPEED = 20.0f;

		//height 41 to 190
		//width 0 to 227

		public Ship ()
		{
			float x_pos = ((float)GameConstants.WINDOW_WIDTH / 2.0f) - (SHIP_WIDTH / 2.0f);
			float y_pos = (float)GameConstants.WINDOW_HEIGHT - SHIP_HEIGHT;

			rotation = 0.0f;
			shipPosition = new Vector2 (x_pos, y_pos);
			shipVelocity = new Vector2 (0.0f, 0.5f);
			shipAcceleration = Vector2.Zero;

			keyPressed = new bool[NUM_MOVEMENTS];
			for (int i = 0; i < NUM_MOVEMENTS; i++) 
			{
				keyPressed [i] = false;
			}

			shipTextureRectangle = new Rectangle (0, 41, 227, 149);
			origin = new Vector2 (shipTextureRectangle.Width / 2.0f, shipTextureRectangle.Height / 2.0f);

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(TextureManager.shipTexture, 
				new Rectangle((int)shipPosition.X, (int)shipPosition.Y, SHIP_WIDTH, SHIP_HEIGHT), 
				shipTextureRectangle, Color.White, rotation, origin, SpriteEffects.None, 0.0f);
		}

		public void Update(float deltaTime)
		{
			Vector2 direction = new Vector2((float)Math.Cos (rotation - Math.PI / 2.0f), 
				(float)Math.Sin (rotation - Math.PI/2.0f));
			
			shipAcceleration = keyPressed[UP] ? direction * MAX_SPEED : Vector2.Zero;
			MoveForward (deltaTime);

			if (keyPressed [RIGHT]) 
			{
				RotateShip (deltaTime, 1.0f);
			}
			if (keyPressed [LEFT]) 
			{
				RotateShip (deltaTime, -1.0f);
			}
		}

		public void MoveForward(float deltaTime)
		{			
			shipVelocity += shipAcceleration * deltaTime;
			shipPosition += shipVelocity * deltaTime;
			shipPosition = Utilities.ApplyTorusMovement(shipPosition);
		}

		public void RotateShip(float deltaTime, float angleDirection)
		{
			rotation += (deltaTime * angleDirection * ROTATION_SPEED);
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
	}
}