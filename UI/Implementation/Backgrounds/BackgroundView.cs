namespace Game.UI
{
    public class BackgroundView : UiElementView<BackgroundSetting, BackgroundComponent>
    {
        public BackgroundView(BackgroundSetting setting, UiContext ctx) : base(setting, ctx)
        {
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            Root.Setup(setting);
        }
    }
}