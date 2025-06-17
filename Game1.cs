using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_project
{
    public class Game1 : Game
    {
        enum Screen
        {
            intro,
            screen1,
            gameover,
            End
        }    
                
       private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Screen screen;
        Texture2D startscreenTexture;
        Rectangle buttonRect;
        Texture2D dayTexture;
        Texture2D nightTexture;
        Texture2D toppipeTexture;
        Texture2D bottompipeTexture;
        Rectangle greenpipeRect;
        Texture2D currentbackgroundTexture;
        Rectangle backgroundRect;
        Texture2D greybirdTexture;
        Vector2 greySpeed;
        Vector2 birdLocation;
        Rectangle birdRect;


        Texture2D gameoverTexture;
        Rectangle gameoverRect;

        
       //Texture2D greybird2Texture;
        //Vector2 grey1Speed;
        //Rectangle grey1Rect;

        //Texture2D greenbirdTexture;
        //Vector2 greenSpeed;
        //Rectangle greenRect;

        //Texture2D greenbird2Teture;
       // Vector2 green1Speed;
        //Rectangle green1Rect;

        //Texture2D pinkbirdTexture;
        //Vector2 pinkSpeed;
        //Rectangle pinkRect;

        //Texture2D pinkbird2Texture;
        //Vector2 pink1Speed;
        //Rectangle pink1Rect;

        Texture2D goldTexture;
        //Vector2 goldSpeed;
        Rectangle goldRect;

        SoundEffect swooshEffect;
        SoundEffect dieEffect;
        // SoundEffect collectEffect;
        //SoundEffect currentaudioEffect;

        SpriteFont scoreFont;

        float gravity = 0.5f;
        float birdVelocity = -3;
      
       
        //List<Rectangle> pipes;
        List<Rectangle> topPipes;
        List<Rectangle> bottomPipes;
        List<Rectangle> goldFeather;


        float pipeSpeed = 3;
        int extralives = 0;
        float feathertimer;
        Random rand = new Random();
        int score = 0;
        float pipetimer; // -> counting real time to spawn the pipes
        //float pipeinterval = 2f;
        bool gameover = false;  
        

        MouseState mouseState;
        KeyboardState keyboardState, prevKeyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 700, 450);
            // TODO: Add your initialization logic here
            screen = Screen.intro;
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            backgroundRect = new Rectangle(0, 0, 700, 450);
            //greenRect = new Rectangle(120, 0, 100, 100);
            //green1Rect = new Rectangle(500, 150, 150, 150);
            birdLocation = new Vector2(100, 200);
            birdRect = new Rectangle(100, 200, 40, 40);
            greySpeed = new Vector2(100, GraphicsDevice.Viewport.Height/2);
            //grey1Rect = new Rectangle(500, 150, 150, 150);
            //pinkRect = new Rectangle(500, 150, 150, 150);
            //pink1Rect = new Rectangle(500, 150, 150, 150);
            greenpipeRect = new Rectangle(350,150,10,10);
            buttonRect = new Rectangle(229,295,210,65);

            

            topPipes = new List<Rectangle>();
            bottomPipes = new List<Rectangle>();
            goldFeather = new List<Rectangle>();

            base.Initialize();
            currentbackgroundTexture = dayTexture;



        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            dayTexture = Content.Load<Texture2D>("day");
            nightTexture = Content.Load<Texture2D>("night");
            greybirdTexture = Content.Load<Texture2D>("greybird");
            //greybird2Texture = Content.Load<Texture2D>("greybird2");
            //greenbirdTexture = Content.Load<Texture2D>("greenbird");
            //greenbird2Teture = Content.Load<Texture2D>("greenbird2");
            //pinkbirdTexture = Content.Load<Texture2D>("pinkbird");
            //pinkbird2Texture = Content.Load<Texture2D>("pinkbird2");
            toppipeTexture = Content.Load<Texture2D>("top");       
            bottompipeTexture = Content.Load<Texture2D>("bottom");
            startscreenTexture = Content.Load<Texture2D>("startscreen");
            gameoverTexture = Content.Load<Texture2D>("crashed image");

            swooshEffect = Content.Load<SoundEffect>("swoosh");
           // dieEffect = Content.Load<SoundEffect>("die");
            //collectEffect = Content.Load<SoundEffect>("goldcollect");
            goldTexture = Content.Load<Texture2D>("gold");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

           
            this.Window.Title ="x = " + mouseState.X + ", y = " + Mouse.GetState().Y;
            //this.Window.Title = birdVelocity.ToString();
            mouseState = Mouse.GetState();
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (screen == Screen.intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                        buttonRect.Contains(mouseState.Position))
                {
                    screen = Screen.screen1;
                    currentbackgroundTexture = dayTexture;
                }
            }


            else if (screen == Screen.screen1)
            {

                if (keyboardState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
                {
                    birdVelocity = -8f;
                    swooshEffect.Play();
                }
                birdVelocity += gravity;
                birdLocation.Y += birdVelocity;

                if (birdLocation.Y < 0)
                    birdLocation.Y = 0;
                if (birdLocation.Y + birdRect.Height > window.Height)
                    birdLocation.Y = window.Height - birdRect.Height;

                birdRect.Location = birdLocation.ToPoint();
                pipetimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (pipetimer >= 3f)
                {

                    int pipeWidth = 40;
                    int gap = 150; // space between top and bottom pipe
                    int pipeStartY = 100;
                    int pipeEndY = 250;
                    int topPipeHeight = rand.Next(pipeStartY, pipeEndY);

                    Rectangle topPipe = new Rectangle(700, 0, pipeWidth, topPipeHeight);
                    Rectangle bottomPipe = new Rectangle(700, topPipeHeight + gap, pipeWidth, 450 - (topPipeHeight + gap));

                    topPipes.Add(topPipe);
                    bottomPipes.Add(bottomPipe);
                    pipetimer = 0f;
                }

                if (feathertimer >= 10f)
                {

                    Rectangle goldFeather = new Rectangle(565, 0, 25, 25);
                    //goldFeather.Add(goldFeather);
                    feathertimer = 0f;

                }


                for (int i = topPipes.Count - 1; i >= 0; i--)
                {
                    Rectangle top = topPipes[i];
                    Rectangle bottom = bottomPipes[i];
                    top.X -= (int)pipeSpeed;
                    bottom.X -= (int)pipeSpeed;


                    if (top.Right < 0)
                    {
                        topPipes.RemoveAt(i);
                        bottomPipes.RemoveAt(i);
                    }
                    else
                    {
                        topPipes[i] = top;
                        bottomPipes[i] = bottom;
                    }
                }

                foreach (var top in topPipes)
                {
                    if (birdRect.Intersects(top))
                    {

                        screen = Screen.gameover;
                        dieEffect.Play();

                    }
                }

                // Collision with bottom pipes
                foreach (var bottom in bottomPipes)
                {
                    if (birdRect.Intersects(bottom))
                    {
                        screen = Screen.gameover;
                       // dieEffect.Play();
                    }
                }
            }
            else if (screen == Screen.gameover)
            {

            }
                




            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.intro)
                _spriteBatch.Draw(startscreenTexture, backgroundRect, Color.White);
            else if (screen == Screen.screen1)
            {

               
             
                    _spriteBatch.Draw(dayTexture, backgroundRect, Color.White);

               
                _spriteBatch.Draw(greybirdTexture, birdRect, Color.White);
                foreach (var top in topPipes)
                    _spriteBatch.Draw(toppipeTexture, top, Color.White);
                foreach (var bottom in bottomPipes)
                    _spriteBatch.Draw(bottompipeTexture, bottom, Color.White);

            }
            else if (screen == Screen.gameover)          
                    _spriteBatch.Draw(gameoverTexture, backgroundRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
