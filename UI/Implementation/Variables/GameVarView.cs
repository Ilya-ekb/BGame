namespace Game.UI
{
    public class GameVarView : UiElementView<GameVarSetting, TextVarComponent>
    {
        public GameVarView(GameVarSetting setting, UiContext ctx) : base(setting, ctx)
        {
        }

        public void SetValue(object sender)
        {
            Root.LegacyComponent.text = sender.ToString();
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            Root.icon.sprite = setting.gameVarIcon;
            Root.LegacyComponent.color = setting.color;
            Root.icon.color = setting.color;
        }

        protected override void OnDrop()
        {
            if (Root)
                Root.icon.sprite = null;
            base.OnDrop();
        }
    }
}