using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/RootUI", fileName = nameof(UIRootSetting))]
    public class UIRootSetting : UISetting
    {
        protected override IDroppable GetInstance(UiContext uiContext)
        {
            return new UIRoot(this, uiContext);
        }

        protected override BaseDroppable GetViewInstance(UiContext uiContext)
        {
            return new UIRootView(this, uiContext);
        }
    }
}