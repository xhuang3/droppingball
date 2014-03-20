using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameName3
{
    class BoxObject : SpriteObject
    {
        private GameHost _game;
        private float _moveSpeed;
        private float _rotateSpeed;
        internal BoxObject(GameHost game, Texture2D texture):base(game, Vector2.Zero, texture)
        {
            _game = game;

            PositionX = GameHelper.RandomNext(0, _game.GraphicsDevice.Viewport.Bounds.Width);
            PositionY = GameHelper.RandomNext(0, _game.GraphicsDevice.Viewport.Bounds.Height);

            Origin = new Vector2(texture.Width, texture.Height) / 2;
            SpriteColor = new Color(GameHelper.RandomNext(0, 256),
                                    GameHelper.RandomNext(0, 256),
                                    GameHelper.RandomNext(0, 256));

            _moveSpeed = GameHelper.RandomNext(2.0f) + 2;
            _rotateSpeed = GameHelper.RandomNext(-5.0f, 5.0f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            PositionY += _moveSpeed;
            if (BoundingBox.Top > _game.GraphicsDevice.Viewport.Bounds.Bottom)
            {
                PositionY = -SpriteTexture.Height;
            }

            Angle += MathHelper.ToRadians(_rotateSpeed);
        }
    }
}
