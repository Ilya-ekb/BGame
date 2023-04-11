using System;
using Game.Factories;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.UI
{
    public class UIFactory : IFactory
    {
        public Type SettingType => typeof(UISetting);

        public IDroppable CreateItem<TConfig>(TConfig config, IContext context)
        {
            var uiContext = context.GetContext<UiContext>();
            if (uiContext is null)
            {
                uiContext = new UiContext();
                uiContext.AddContext(context.GetContext<MainContext>());
            }
            return config switch
            {
                BackgroundSetting setting => new Background(setting, uiContext),
                ButtonSetting setting => new Button(setting, uiContext),
                CanvasSetting setting => new Canvas(setting, uiContext),
                GameVarSetting setting => new GameVarUI(setting, uiContext),
                QRCodeSetting setting => new QRCode(setting, uiContext),
                UIRootSetting setting => new UIRoot(setting, uiContext),
                _ => null,
            };
        }
    }
}