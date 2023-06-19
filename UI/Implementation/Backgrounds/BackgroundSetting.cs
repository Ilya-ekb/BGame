using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/" + nameof(BackgroundSetting))]
    public class BackgroundSetting : UISetting
    {
        public Sprite backgroundSprite;
        [Range(0f, 1f)] public float alpha;

        protected override IDroppable GetInstance(UiContext uiContext)
        {
            return new Background(this, uiContext);
        }

        protected override BaseDroppable GetViewInstance(UiContext uiContext)
        {
            return new BackgroundView(this, uiContext);
        }
    }
}