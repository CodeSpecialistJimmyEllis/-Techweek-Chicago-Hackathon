


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AngelHackVideoGame
{
    public class ScreenManager
    {

        #region Variables
      
 
        ContentManager content;
       
        private static ScreenManager instance;
        GameScreen currentScreen;
        GameScreen newScreen;
      

        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        public static RandomAppearLeap randomappearleap;
       // public static RandomAppearLeapLevelTwo randomappearleapleveltwo;
        public static AngelHackScoreScreen angelhackscorescreen;
        //public static AngelScoreScreenLevelTwo angelhackscorescreenleveltwo;
        //public static AngelHackTotalScore angelhacktotalscore;
        
        public static AngelHackTitleScreen angelhacktitlescreen;
        
        Vector2 dimensions = Vector2.Zero;
        
        #endregion

        #region Properties
      
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }
      
        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Main Methods

        
        public void AddScreen(GameScreen screen)
        {
           
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content);
        }



        public void Initialize()
        {
            
            angelhacktitlescreen = new AngelHackTitleScreen();
            currentScreen = angelhacktitlescreen;
             
           // currentScreen = new RandomAppearLeapLevelTwo();
            
        }
        public void LoadContent(ContentManager Content)
        {

            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}


