using System;
using System.Collections.Generic;
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
            //screen1,
            //screen2,
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
        Texture2D greenpipeTexture;
        Rectangle greenpipeRect;
        Texture2D currentbackgroundTexture;
        Rectangle backgroundRect;
        Texture2D greybirdTexture;
        Vector2 greySpeed;
        Rectangle greyRect;
        
       Texture2D greybird2Texture;
        Vector2 grey1Speed;
        Rectangle grey1Rect;

        Texture2D greenbirdTexture;
        Vector2 greenSpeed;
        Rectangle greenRect;

        Texture2D greenbird2Teture;
        Vector2 green1Speed;
        Rectangle green1Rect;

        Texture2D pinkbirdTexture;
        Vector2 pinkSpeed;
        Rectangle pinkRect;

        Texture2D pinkbird2Texture;
        Vector2 pink1Speed;
        Rectangle pink1Rect;

        Texture2D goldTexture;
        Vector2 goldSpeed;
        Rectangle goldRect;

        SoundEffect swooshEffect;
        SoundEffect dieEffect;
        SoundEffect collectEffect;
        SoundEffect currentaudioEffect;
        SpriteFont SpriteFont;

        float gravity ;
        float yVelocity = 0f;
        float birdSpeed;
        float birdVelocity;
        //float birdVelocityY = 0;
        List<Vector2> pipes = new List<Vector2>();
        float pipeSpeed = 3f;
        Random rand = new Random();
        int score = 0;
        
        float VelocityY = 2f;
        MouseState mouseState;
        KeyboardState keyboardState;

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

            backgroundRect = new Rectangle(0, 0, 700, 500);
            //greenRect = new Rectangle(120, 0, 100, 100);
            //green1Rect = new Rectangle(500, 150, 150, 150);
            
            greyRect = new Rectangle(100, 200, 50, 50);
            greySpeed = new Vector2(100, GraphicsDevice.Viewport.Height/2);
            //grey1Rect = new Rectangle(500, 150, 150, 150);
            //pinkRect = new Rectangle(500, 150, 150, 150);
            //pink1Rect = new Rectangle(500, 150, 150, 150);
            greenpipeRect = new Rectangle();



            base.Initialize();
            //currentbackgroundTexture = startscreenTexture;

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
            greenpipeTexture = Content.Load<Texture2D>("greenpipe");
            startscreenTexture = Content.Load<Texture2D>("startscreen");

            //swooshEffect = Content.Load<SoundEffect>("swoosh");
            //dieEffect = Content.Load<SoundEffect>("die");
            //collectEffect = Content.Load<SoundEffect>("goldcollect");
            goldTexture = Content.Load<Texture2D>("gold");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();
            this.Window.Title = "x = " + mouseState.X + ", y = " + Mouse.GetState().Y;
            KeyboardState state = Keyboard.GetState();

            //if (keyboardState.IsKeyDown(Keys.Space))
            //{
            //    birdSpeed = -6f;
            //}
            //birdVelocity += 0.4f;
            //greyRect.Y += (int)greySpeed.Y;

            //for (int i = 0; ; i < pipes.Count; int++)
            //{
            //    pipes[i] = new Vector2(pipes[i].X - pipeSpeed, pipes[i].Y);
            //    Rectangle pipeRect = new Rectangle
            //})
            //VelocityY += gravity;
            //greybirdTexture.Y += VelocityY;
            //float dt  = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ////birdSpeed = new Vector2(
            //if (keyboardState.IsKeyDown(Keys.Space))
            //{

            //}

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
              
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                VelocityY = -10;
            }
            yVelocity += gravity;
            greyRect.Y += (int)VelocityY;

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.intro)
              
            _spriteBatch.Draw(greybirdTexture, greyRect, Color.White);
            _spriteBatch.Draw(greenpipeTexture, greenpipeRect, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
