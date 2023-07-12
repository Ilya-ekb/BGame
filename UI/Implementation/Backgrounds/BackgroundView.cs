using Core.ObjectsSystem;

namespace Game.UI
{
    public class BackgroundView : UiElementView<BackgroundSetting, BackgroundComponent>
    {
        public BackgroundView(BackgroundSetting setting, UiContext ctx, IDroppable parent) : base(setting, ctx, parent)
        {
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            Root.Setup(setting);
        }
    }
}