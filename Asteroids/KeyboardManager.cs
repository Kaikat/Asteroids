using System;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
	public static class KeyboardManager
	{
		private static Keys[] lastPressedKeys;

		public static void HandleKeyboard (Game1 game)
		{
			if (lastPressedKeys != null) 
			{
				Keys[] currentPressedKeys = Keyboard.GetState ().GetPressedKeys ();

				foreach (Keys key in currentPressedKeys) 
				{
					if(!Array.Exists<Keys>(lastPressedKeys, element => element == key))
					{
						game.KeyPressed (key);
					}
				}

				foreach (Keys key in lastPressedKeys)
				{
					if (!Array.Exists<Keys>(currentPressedKeys, element => element == key))
					{
						game.KeyReleased(key);
					}
				}
			}

			lastPressedKeys = Keyboard.GetState ().GetPressedKeys ();
		}
	}
}

