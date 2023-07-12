using Core.ObjectsSystem;

namespace Game.UI
{
    public class UIRoot : UiElement<UIRootView, UIRootSetting, UIRootComponent>
    {
        public UIRoot(UIRootSetting setting, UiContext context, IDroppable parent) : base(setting, context, parent)
        {
        }
    }
}