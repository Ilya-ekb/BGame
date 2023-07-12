using Core.ObjectsSystem;

namespace Game.UI
{
    public class UIRootView : UiElementView<UIRootSetting, UIRootComponent>
    {
        public UIRootView(UIRootSetting uiElementParent, UiContext ctx, IDroppable parent) : base(uiElementParent, ctx, parent)
        {
        }
    }
}