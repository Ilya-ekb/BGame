namespace Game.UI
{
    public class Button : UiElement<ButtonView, ButtonSetting, ButtonComponent>
    {
        public Button(ButtonSetting setting, UiContext context) : base(setting, context)
        {
            Name = setting.ButtonName;
            view.OnClick += setting.OnClickAction;
        }

        protected override void SetContentHolder()
        {
            ContentHolder = view?.Root.transform;
        }
    }
}
