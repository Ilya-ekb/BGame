using Game;
using Game.UI;

namespace Game.UI
{
    public class Background : UiElement<BackgroundView, BackgroundSetting, BackgroundComponent>
    {
        public Background(BackgroundSetting setting, UiContext context) : base(setting, context)
        {
        }
    }
}