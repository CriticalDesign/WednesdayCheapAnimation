using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace WednesdayCheapAnimation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Texture2D> _runAnimation;
        private int _runIndex;
        private int _frameCount;
        private float _heroX, _heroY, _heroSpeed;
        private SpriteEffects _heroFacing;
        private Texture2D _heroIdle;
        private bool _isMoving;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _runAnimation = new List<Texture2D>();
            _runIndex = 0;
            _frameCount = 0;
            _heroX = 50;
            _heroY = 50;
            _isMoving = false;
            _heroSpeed = 3.5f;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            for(int i = 1; i <= 5; i++)
                _runAnimation.Add(Content.Load<Texture2D>("run-" + i));

            _heroIdle = Content.Load<Texture2D>("idle-1");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _isMoving = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _isMoving = true;
                _heroY += _heroSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _isMoving = true;
                _heroY -= _heroSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _heroX -= _heroSpeed;
                _isMoving = true;
                _heroFacing = SpriteEffects.FlipHorizontally;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _heroX += _heroSpeed;
                _isMoving = true;
                _heroFacing = SpriteEffects.None;
            }


            // TODO: Add your update logic here
            _frameCount++;

            if(_frameCount %  5 == 0)
                _runIndex++;
            
            if (_runIndex >= 4)
                _runIndex = 0;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if(_isMoving)
                _spriteBatch.Draw(_runAnimation[_runIndex], 
                    new Vector2(_heroX, _heroY), 
                    null,
                    Color.White,
                    0,
                    new Vector2(_runAnimation[_runIndex].Width/2, _runAnimation[_runIndex].Height/2),
                    0.5f,
                    _heroFacing,
                    0
                    );
            else
                _spriteBatch.Draw(_heroIdle,
                    new Vector2(_heroX, _heroY),
                    null,
                    Color.White,
                    0,
                    new Vector2(_heroIdle.Width / 2, _heroIdle.Height / 2),
                    0.5f,
                    _heroFacing,
                    0
                    );

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
