using System;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine.UI;

namespace Game.UI
{
    public class ButtonView : UiElementView<ButtonSetting, ButtonComponent>
    {
        public Action<IContext> OnClick { get; set; }

        public ButtonView(ButtonSetting setting, UiContext ctx, IDroppable parent) : base(setting, ctx, parent)
        {
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            Root.LegacyComponent.onClick.AddListener(Click);
            if (Root.LegacyComponent.GetComponentInChildren<Text>())
                Root.LegacyComponent.GetComponentInChildren<Text>().text = setting.ButtonName;
        }

        protected override void OnDrop()
        {
            if (Root)
                Root.LegacyComponent.onClick.RemoveAllListeners();
            base.OnDrop();
        }

        private void Click()
        {
            OnClick?.Invoke(context.GetContext<MainContext>());
        }
    }
}