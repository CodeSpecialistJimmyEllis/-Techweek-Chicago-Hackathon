using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AngelHackVideoGame
{
    public class RandomAppearLeap : GameScreen
    {


        // choir soudn
        Song choirSound;
        bool isHitting;
        //
        enum Level
        {
            one, two, three
        }
        Level level;
        Texture2D[] switchingBackground;
        Rectangle switchingBackgroundRect;
        int gameEngineTime;
        SpriteFont spriteFont;
        Texture2D randomTexture;
        Rectangle randomTextureRect;
        Vector2 randomLocation;
        Color objectColor;
        int tempColor;
        Color[] colorChoices;
        Random createRandomLocation;
        Random createRandomColor;
        int timeInterval;
        int missPoints;
        int hitPoints;
        public int HitPoints { get { return hitPoints; } set { hitPoints = value; } }
        int controlBackgroundSwitch;
        Rectangle testRectangle;
        int backgroundDisplaying;
        float gameTimeSeconds;
        enum ChangedAnd
        {
            hit, miss, none
        }
        ChangedAnd changedand;
        bool isTimeInterval;

        bool timeBetweenPoints;


        public RandomAppearLeap(int newLevel)
        {

            if (newLevel == 1)
            {
                level = Level.one;
            }
            else if (newLevel == 2)
            {
                level = Level.two;
            }
            else if (newLevel == 3)
            {
                level = Level.three;
            }

            bool isHitting = false;
         
            randomTextureRect = new Rectangle(0, 0, 64, 64);
            timeInterval = 0;
            objectColor = Color.White;
            missPoints = 0;
            colorChoices = new Color[10];
            timeBetweenPoints = false;
            hitPoints = 0;
            isTimeInterval = false;
            backgroundDisplaying = 0;
            colorChoices[0] = Color.Magenta;
            colorChoices[1] = Color.Silver;
            colorChoices[2] = Color.Turquoise;
            colorChoices[3] = Color.Red;
            colorChoices[4] = Color.Green;
            colorChoices[5] = Color.Violet;
            colorChoices[6] = Color.ForestGreen;
            colorChoices[7] = Color.LightGoldenrodYellow;
            colorChoices[8] = Color.RoyalBlue;
            colorChoices[9] = Color.SandyBrown;



            gameEngineTime = 0;
            gameTimeSeconds = 0.0f;
            Rectangle testRectangle;
            tempColor = 0;
            timeInterval = 0;
            switchingBackgroundRect = new Rectangle(0, 0, 800, 600);
            testRectangle = new Rectangle(0, 0, 800, 600);
            createRandomColor = new Random();
            createRandomLocation = new Random();


            
        }

      

       
        public override void LoadContent(ContentManager Content)
        {
            randomTexture = Content.Load<Texture2D>("randomtexture");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

            //switching background
            switchingBackground = new Texture2D[10];
            switchingBackground[0] = Content.Load<Texture2D>("backgrounds/switching/background01");
            switchingBackground[1] = Content.Load<Texture2D>("backgrounds/switching/background02");
            switchingBackground[2] = Content.Load<Texture2D>("backgrounds/switching/background03");
            switchingBackground[3] = Content.Load<Texture2D>("backgrounds/switching/background04");
            switchingBackground[4] = Content.Load<Texture2D>("backgrounds/switching/background05");

            switchingBackground[5] = Content.Load<Texture2D>("backgrounds/switching/background06");
            switchingBackground[6] = Content.Load<Texture2D>("backgrounds/switching/background07");
            switchingBackground[7] = Content.Load<Texture2D>("backgrounds/switching/background08");
            switchingBackground[8] = Content.Load<Texture2D>("backgrounds/switching/background09");
            switchingBackground[9] = Content.Load<Texture2D>("backgrounds/switching/background10");

            // choir sound

            choirSound = Content.Load<Song>("sound/choir.wav");
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {

            #region random appearance generator

            // assign random color

           
           

            if (isTimeInterval == false)
            {
                isTimeInterval = true;

                timeInterval = gameTime.TotalGameTime.Seconds;
                controlBackgroundSwitch = gameTime.TotalGameTime.Seconds;
                gameEngineTime += 1;
            }

            if (gameTime.TotalGameTime.Seconds > (controlBackgroundSwitch+1))
            {
                backgroundDisplaying += 1;

                if (backgroundDisplaying >= 9)
                {
                    backgroundDisplaying = 0;
                }
            }

            if (Level.one == level)
            {

                gameTimeSeconds = gameTime.TotalGameTime.Seconds;
                if (gameTime.TotalGameTime.Seconds > (timeInterval + 1))
                {

                    isTimeInterval = false;
                    tempColor = createRandomColor.Next(0, 10);
                    objectColor = colorChoices[tempColor];

                    randomTextureRect.X = createRandomLocation.Next(0, (800 - randomTextureRect.Width));
                    randomTextureRect.Y = createRandomLocation.Next(0, (600 - randomTextureRect.Height));


                    isTimeInterval = false;

                    if (isTimeInterval == true)
                    {
                        isTimeInterval = false;
                    }


                }

                else if (gameTimeSeconds > (timeInterval+2))
                {


                    isTimeInterval = false;
                    tempColor = createRandomColor.Next(0, 10);
                    objectColor = colorChoices[tempColor];

                    randomTextureRect.X = createRandomLocation.Next(0, (800 - randomTextureRect.Width));
                    randomTextureRect.Y = createRandomLocation.Next(0, (600 - randomTextureRect.Height));


                    isTimeInterval = false;

                    if (isTimeInterval == true)
                    {
                        isTimeInterval = false;
                    }

                }
            }

            else if (Level.two == level)
            {
                gameTimeSeconds = gameTime.TotalGameTime.Seconds;
                if (gameTimeSeconds > (timeInterval + .5))
                {

                    isTimeInterval = false;
                    tempColor = createRandomColor.Next(0, 10);
                    objectColor = colorChoices[tempColor];

                    randomTextureRect.X = createRandomLocation.Next(0, (800 - randomTextureRect.Width));
                    randomTextureRect.Y = createRandomLocation.Next(0, (600 - randomTextureRect.Height));


                    isTimeInterval = false;

                    if (isTimeInterval == true)
                    {
                        isTimeInterval = false;
                    }


                }

                else if (gameTimeSeconds > (timeInterval+1))
                {


                    isTimeInterval = false;
                    tempColor = createRandomColor.Next(0, 10);
                    objectColor = colorChoices[tempColor];

                    randomTextureRect.X = createRandomLocation.Next(0, (800 - randomTextureRect.Width));
                    randomTextureRect.Y = createRandomLocation.Next(0, (600 - randomTextureRect.Height));


                    isTimeInterval = false;

                    if (isTimeInterval == true)
                    {
                        isTimeInterval = false;
                    }

                }

                if (gameTime.TotalGameTime.Seconds > (controlBackgroundSwitch + 1))
                {
                    backgroundDisplaying += 1;

                    if (backgroundDisplaying >= 9)
                    {
                        backgroundDisplaying = 0;
                    }
                }


            }

            else if (Level.three == level)
            {

                gameTimeSeconds = gameTime.TotalGameTime.Seconds;
                if (gameTimeSeconds > (timeInterval + .25))
                {

                    isTimeInterval = false;
                    tempColor = createRandomColor.Next(0, 10);
                    objectColor = colorChoices[tempColor];

                    randomTextureRect.X = createRandomLocation.Next(0, (800 - randomTextureRect.Width));
                    randomTextureRect.Y = createRandomLocation.Next(0, (600 - randomTextureRect.Height));


                    isTimeInterval = false;

                    if (isTimeInterval == true)
                    {
                        isTimeInterval = false;
                    }


                    else if (gameTimeSeconds > (timeInterval+1))
                    {


                        isTimeInterval = false;
                        tempColor = createRandomColor.Next(0, 10);
                        objectColor = colorChoices[tempColor];

                        randomTextureRect.X = createRandomLocation.Next(0, (800 - randomTextureRect.Width));
                        randomTextureRect.Y = createRandomLocation.Next(0, (600 - randomTextureRect.Height));


                        isTimeInterval = false;

                        if (isTimeInterval == true)
                        {
                            isTimeInterval = false;
                        }

                    }

                }


                if (gameTime.TotalGameTime.Seconds > (controlBackgroundSwitch + 1))
                {
                    backgroundDisplaying += 1;

                    if (backgroundDisplaying >= 9)
                    {
                        backgroundDisplaying = 0;
                    }
                }
              
            }





            #endregion
            //collision and soudn system
            if (Game1.leapCollision.Intersects(randomTextureRect))
            {
                hitPoints += 1;

                if (isHitting == false)
                {
                    isHitting = true;
                    MediaPlayer.Play(choirSound);
                }
            }

            if (!Game1.leapCollision.Intersects(randomTextureRect))
            {
                MediaPlayer.Stop();
                isHitting = false;
            }



            
            if (gameEngineTime == 10)
            {
                
                ScreenManager.Instance.AddScreen(new AngelHackScoreScreen(hitPoints));

            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(switchingBackground[backgroundDisplaying], switchingBackgroundRect, Color.White);
            spriteBatch.Draw(randomTexture, randomTextureRect, objectColor);
            spriteBatch.DrawString(spriteFont, "POINTS: " + hitPoints.ToString(), new Vector2(0, 0), Color.Black);
          //  spriteBatch.DrawString(spriteFont, "is time interval: " + isTimeInterval.ToString(), new Vector2(0, 20), Color.Black);
        }
    }
}
