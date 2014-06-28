#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


using LeapLibrary;
#endregion

namespace AngelHackVideoGame
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static LeapComponet leap;
        public static Rectangle leapCollision;
        Texture2D fingerTexture;
        Rectangle[] fingerLocations;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";   

            //sets widht and height of it all
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            // allows mouse to be seen
            IsMouseVisible = true;

            leap = new LeapComponet(this);
            this.Components.Add(leap);
        }

    
        protected override void Initialize()
        {

            ScreenManager.Instance.Initialize();
            ScreenManager.Instance.Dimensions = new Vector2(800, 600);
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;

            fingerLocations = new Rectangle[5];
            fingerLocations[0] = new Rectangle(800, 600, 128, 128);
            fingerLocations[1] = new Rectangle(0, 0, 128, 128);
            fingerLocations[2] = new Rectangle(0, 0, 128, 128);
            fingerLocations[3] = new Rectangle(0, 0, 128, 128);
            fingerLocations[4] = new Rectangle(0, 0, 128, 128);
            // leap collision
            leapCollision = new Rectangle(0, 0, 128, 128);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.LoadContent(Content);

            // leap component fingertips
            fingerTexture = Content.Load<Texture2D>("finger/fingers");
            
        }

      
        protected override void UnloadContent()
        {
           
        }
       
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

     
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);

            foreach (Vector2 fingerLoc in leap.FingerPoints)
            {
                float tempX = fingerLoc.X;
                float tempY = fingerLoc.Y;
                fingerLocations[0].X = (int)tempX;
                fingerLocations[0].Y = (int)tempY;
                spriteBatch.Draw(fingerTexture, fingerLocations[0], Color.White);
                leapCollision.X = fingerLocations[0].X;
                leapCollision.Y = fingerLocations[0].Y;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
