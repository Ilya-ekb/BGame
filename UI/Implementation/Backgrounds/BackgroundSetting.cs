using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/" + nameof(BackgroundSetting))]
    public class BackgroundSetting : UISetting
    {
        public Sprite backgroundSprite;
        [Range(0f, 1f)] public float alpha;

        protected override IDroppable GetInstance(UiContext uiContext, IDroppable parent)
        {
            return new Background(this, uiContext, parent);
        }

        protected override BaseDroppable GetViewInstance(UiContext uiContext, IDroppable parent)
        {
            return new BackgroundView(this, uiContext, parent);
        }
    }
}