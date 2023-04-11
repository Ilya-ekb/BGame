using UnityEngine.UI;

namespace Game.UI
{
    public class BackgroundComponent :  GraphicComponent<Image>
    {
        public void Setup(BackgroundSetting setting)
        {
            var color = LegacyComponent.color;
            color[3] = setting.alpha;
            LegacyComponent.color = color;
            LegacyComponent.sprite = setting.backgroundSprite;
        }
    }
    
}