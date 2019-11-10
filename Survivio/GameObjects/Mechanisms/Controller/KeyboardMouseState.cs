using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Survivio.GameObjects.Mechanisms.Controller
{
    public class KeyboardMouseState : IState
    {
        public GameTime GameTime { get; private set; }

        public KeyboardState KeyboardState { get; set; }

        public MouseState MouseState { get; set; }

        public KeyboardMouseState(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {
            this.GameTime = gameTime;
            this.KeyboardState = keyboardState;
            this.MouseState = mouseState;
        }
    }
}
