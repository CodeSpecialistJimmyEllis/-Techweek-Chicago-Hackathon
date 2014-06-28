using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace AngelHackVideoGame
{
    public class AngelHackTotalScore : GameScreen
    {

        enum ConstructorLevel
        {
            one, two, three
        }
        
        Texture2D wheresSymbol;
        ConstructorLevel constructorlevel;
        Texture2D background;
        Rectangle backgroundRect;
        Song backgroundSong;
        Texture2D angelHackSymbol;
        Rectangle angelHackSymbolRect;
        ScrollingBackground scrollingBackground;
        int levelCall;
        SpriteFont spriteFont;
        int points;
        public AngelHackTotalScore()
        {
            angelHackSymbolRect = new Rectangle(200, 150, 400, 300);
            backgroundRect = new Rectangle(0, 0, 800, 600);
            constructorlevel = ConstructorLevel.one;
           // this.points = newPoints;
            scrollingBackground = new ScrollingBackground();
        }
        public override void LoadContent(ContentManager Content)
        {
            
            scrollingBackground.LoadContent(Content);
            background = Content.Load<Texture2D>("backgrounds/background");
            angelHackSymbol = Content.Load<Texture2D>("words/angelhack");
            backgroundSong = Content.Load<Song>("sound/backgroundaudio.wav");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            wheresSymbol = Content.Load<Texture2D>("words/wheres");
            MediaPlayer.Play(backgroundSong);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            scrollingBackground.Update(gameTime);

            if ((MediaState.Stopped == MediaPlayer.State) || (MediaState.Paused == MediaPlayer.State))
            {
                MediaPlayer.Play(backgroundSong);

            }


            if ((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)))
            {




            }


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(background, backgroundRect, Color.White);
            spriteBatch.Draw(wheresSymbol, new Rectangle(100, 300, 200, 50), Color.White);
            spriteBatch.Draw(angelHackSymbol, angelHackSymbolRect, Color.White);
            scrollingBackground.Draw(spriteBatch);

            spriteBatch.DrawString(spriteFont, "TOTAL SCORE ", new Vector2(500, 200), Color.White);
           

            points = ScreenManager.randomappearleap.HitPoints + ScreenManager.randomappearleapleveltwo.HitPoints;
            spriteBatch.DrawString(spriteFont, points.ToString(), new Vector2(520, 230), Color.White);
            base.Draw(spriteBatch);
        }
    }
}
