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

		GameBackground background;
		AsteroidManager asteroidManager;

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

