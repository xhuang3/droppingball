using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameName3
{
    class BallObject : SpriteObject
    {
        private GameHost _game;
        private float _xadd;
        private float _yadd;
        private float _wobble;
        internal BallObject(GameHost game, Texture2D texture) : base(game, Vector2.Zero, texture)
        {
            _game = game;

            PositionX = GameHelper.RandomNext(0, _game.GraphicsDevice.Viewport.Bounds.Width);
            PositionY = GameHelper.RandomNext(0, _game.GraphicsDevice.Viewport.Bounds.Height);

            Origin = new Vector2(texture.Width, texture.Height) / 2;

            SpriteColor = new Color(GameHelper.RandomNext(0, 256),
                                    GameHelper.RandomNext(0, 256),
                                    GameHelper.RandomNext(0, 256));

            _xadd = GameHelper.RandomNext(-0.5f, 0.5f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            PositionX += _xadd;
            PositionY += _yadd;

            if(PositionX < OriginX)
            {
                PositionX = OriginX;
                _xadd = -_xadd;
                _wobble += Math.Abs(_xadd);

            }
            if(PositionX > _game.GraphicsDevice.Viewport.Bounds.Width - OriginX)
            {
                PositionX = _game.GraphicsDevice.Viewport.Bounds.Width - OriginX;
                _xadd = -_xadd;
                _wobble += Math.Abs(_xadd);
            }

            if (PositionY >= _game.GraphicsDevice.Viewport.Bounds.Bottom - OriginY)
            {
                PositionY = _game.GraphicsDevice.Viewport.Bounds.Bottom - OriginY;
                _yadd = -_yadd;
                _wobble += Math.Abs(_yadd);
            }
            else
            {
                _yadd += 0.3f;
            }

            if(_wobble == 0)
            {
                Scale = Vector2.One;
            }
            else
            {
                const float WobbleSpeed = 20.0f;
                const float WobbleIntensity = 0.015f;
                ScaleX = (float)Math.Sin(MathHelper.ToRadians(UpdateCount * WobbleSpeed)) * _wobble * WobbleIntensity + 1;
                ScaleY = (float)Math.Sin(MathHelper.ToRadians(UpdateCount * WobbleSpeed + 180.0f)) * _wobble * WobbleIntensity + 1;

                _wobble -= 0.2f;
                if (_wobble < 0) _wobble = 0;
                if (_wobble > 50) _wobble = 50;
            }
        }
    }
}
