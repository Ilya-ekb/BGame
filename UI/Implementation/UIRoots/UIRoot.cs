namespace Game.UI
{
    public class UIRoot : UiElement<UIRootView, UIRootSetting, UIRootComponent>
    {
        public UIRoot(UIRootSetting setting, UiContext context) : base(setting, context)
        {
        }
    }
}