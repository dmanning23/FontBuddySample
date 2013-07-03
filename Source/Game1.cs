using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using FontBuddyLib;

namespace FontBuddySample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		List<FontBuddy> buddies = new List<FontBuddy>();

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			graphics.IsFullScreen = true;

			buddies.Add(new FontBuddy());
			buddies.Add(new ShadowTextBuddy());
			buddies.Add(new PulsateBuddy());
			buddies.Add(new ShakyTextBuddy());
			buddies.Add(new OppositeTextBuddy());
			buddies.Add(new RainbowTextBuddy());
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

			// TODO: use this.Content to load your game content here
			foreach (FontBuddy myBuddy in buddies)
			{
				myBuddy.LoadContent(Content, "TestFont");
			}
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
				Exit ();
			}
			// TODO: Add your update logic here			
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin();
		
			//get the start point
			Rectangle screen = graphics.GraphicsDevice.Viewport.TitleSafeArea;
			Vector2 position = new Vector2(screen.Left, screen.Top);
			
			string test = "FontBuddy!";
			
			//draw all those fonts
			foreach (FontBuddy myBuddy in buddies)
			{
				//draw the left justified text
				myBuddy.Write(test, position, Justify.Left, 1.0f, Color.White, spriteBatch, gameTime.TotalGameTime.TotalSeconds);
				
				//draw the centered text
				position.X = screen.Center.X;
				myBuddy.Write(test, position, Justify.Center, 1.0f, Color.White, spriteBatch, gameTime.TotalGameTime.TotalSeconds);
				
				//draw the right justified text
				position.X = screen.Right;
				myBuddy.Write(test, position, Justify.Right, 1.0f, Color.White, spriteBatch, gameTime.TotalGameTime.TotalSeconds);
				
				//move to the start point for the next font
				position.X = 0.0f;
				position.Y += myBuddy.Font.MeasureString(test).Y;
			}
			
			spriteBatch.End();
            
			base.Draw (gameTime);
		}
	}
}

