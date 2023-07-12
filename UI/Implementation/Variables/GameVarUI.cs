using Core.ObjectsSystem;

namespace Game.UI
{
    public class GameVarUI : UiElement<GameVarView, GameVarSetting, TextVarComponent>
    {
        public GameVarUI(GameVarSetting setting, UiContext context, IDroppable parent) : base(setting, context, parent)
        {
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            setting.OnUpdateSender += Update;
            setting.Subscribe(parent);
        }

        protected override void OnDrop()
        {
            setting.Unsubscribe(parent);
            setting.OnUpdateSender -= Update;
            setting.OnUpdateSender = null;
            base.OnDrop();
        }

        private void Update(object value) => view.SetValue(value);
    }
}