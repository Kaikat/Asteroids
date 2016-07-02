using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Asteroids
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		SpriteFont font;
		GameBackground background;
		AsteroidManager asteroidManager;
		string gameMessage;
		Ship ship;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			graphics.PreferredBackBufferWidth = GameConstants.WINDOW_WIDTH;
			graphics.PreferredBackBufferHeight = GameConstants.WINDOW_HEIGHT;
			graphics.ApplyChanges ();

			//TextureManager = new TextureManager ();
			gameMessage = "";
			background = new GameBackground ();
			ship = new Ship ();
			asteroidManager = new AsteroidManager (GameConstants.LEVEL_1);
			base.Initialize ();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
			//TODO: use this.Content to load your game content here
			font = Content.Load<SpriteFont>("ArialBold");
			TextureManager.LoadContent (Content);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
            
			// TODO: Add your update logic here
			KeyboardManager.HandleKeyboard(this);
			ship.Update ((float)gameTime.ElapsedGameTime.TotalSeconds);
			asteroidManager.Update ((float)gameTime.ElapsedGameTime.TotalSeconds);

			//foreach (Asteroid asteroid in asteroidManager.asteroids)
			for(int i = 0; i < asteroidManager.GetAsteroidCount (); i++)
			{
				if (Utilities.Collided (ship.radius, asteroidManager.GetAsteroidRadiusAt (i), ship.origin, asteroidManager.GetAsteroidOriginAt (i))) 
				{
					Console.WriteLine ("COLLIDED!");
					gameMessage = "You Lost!";
				} 
				else 
				{
					//Console.WriteLine ("NO");
				}
			}

			for(int bulletIndex = ship.weapon.bullets.Count - 1; bulletIndex >= 0; bulletIndex--)
			{
				for(int asteroidIndex = asteroidManager.GetAsteroidCount () - 1; asteroidIndex >= 0; asteroidIndex--) 
				{
					if (asteroidIndex > asteroidManager.GetAsteroidCount () - 1 || asteroidIndex <= -1 ||
						bulletIndex > ship.weapon.bullets.Count - 1 || bulletIndex <= -1) 
					{
						break;
					}

 					if (Utilities.Collided (ship.weapon.bullets[bulletIndex].radius, asteroidManager.GetAsteroidRadiusAt (asteroidIndex), 
						ship.weapon.bullets[bulletIndex].origin, asteroidManager.GetAsteroidOriginAt (asteroidIndex))) 
					{
						ship.weapon.bullets.RemoveAt (bulletIndex);
						asteroidManager.DecrementAsteroidHealthAt(asteroidIndex);
					}
				}
			}

			if (asteroidManager.GetAsteroidCount () == 0) 
			{
				gameMessage = "You Won!";
			}

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
			//TODO: Add your drawing code here
			spriteBatch.Begin ();
			background.Draw (spriteBatch);
			ship.Draw (spriteBatch);
			asteroidManager.Draw (spriteBatch);
			spriteBatch.DrawString (font, gameMessage,
				new Vector2 (GameConstants.WINDOW_WIDTH / 2 - font.MeasureString (gameMessage).X / 2,
					GameConstants.WINDOW_HEIGHT - font.MeasureString (gameMessage).Y - 10), Color.White);
			spriteBatch.End ();
            
			base.Draw (gameTime);
		}

		public void KeyPressed(Keys key)
		{
			switch (key) 
			{
				case Keys.Up:
				case Keys.Right:
				case Keys.Left:
					ship.MoveKeyPressed(key);
				break;
		
				case Keys.Space:
					ship.FireKeyPressed (key);
				break;

				case Keys.Q:
				case Keys.Escape:
					Exit ();
				break;

				default:
					break;
			}
		}

		public void KeyReleased(Keys key)
		{
			switch (key) 
			{
				case Keys.Up:
				case Keys.Right:
				case Keys.Left:
					ship.MoveKeyReleased (key);
				break;

				default:
					break;
			}
		}
	}
}

