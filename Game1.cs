using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myGames;

public class Main : Game
{
    Texture2D ballTexture;
    Vector2 ballPosition;
    float ballSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 100f;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        ballTexture = Content.Load<Texture2D>("ball");
    }

    protected override void Update(GameTime gameTime)
    {
        var speed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState input = Keyboard.GetState();


        if (input.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= speed;
        }
        if (input.IsKeyDown(Keys.Down))
        {
            ballPosition.Y += speed;
        }
        if (input.IsKeyDown(Keys.Left))
        {
            ballPosition.X -= speed;
        }
        if (input.IsKeyDown(Keys.Right))
        {
            ballPosition.X += speed;
        }



        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        _spriteBatch.Draw(
     ballTexture,
     ballPosition,
     null,
     Color.White,
     0f,
     new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
     Vector2.One,
     SpriteEffects.None,
     0f
 );
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
