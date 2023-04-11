using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/" + nameof(BackgroundSetting), fileName = nameof(BackgroundSetting))]
    public class BackgroundSetting : UISetting
    {
        public Sprite backgroundSprite;
        [Range(0f, 1f)] public float alpha;
    }
}