using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/RootUI", fileName = nameof(UIRootSetting))]
    public class UIRootSetting : UISetting
    {
        protected override IDroppable GetInstance(UiContext uiContext, IDroppable parent)
        {
            return new UIRoot(this, uiContext, parent);
        }

        protected override BaseDroppable GetViewInstance(UiContext uiContext, IDroppable parent)
        {
            return new UIRootView(this, uiContext, parent);
        }
    }
}