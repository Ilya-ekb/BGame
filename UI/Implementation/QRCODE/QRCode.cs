using Game.Contexts;
using Game.QR;

namespace Game.UI
{
    public class QRCode : UiElement<QRCodeView, QRCodeSetting, QRCodeComponent>
    {
        public QRCode(QRCodeSetting setting, UiContext context) : base(setting, context)
        {
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            var ipAddress = "http://" + uiContext.GetContext<MainContext>().GetContext<WebContext>().Address;
            view.SetTexture(QRGenerator.Create(ipAddress, setting.size.x, setting.size.y, setting.colorDark, setting.colorLight));
        }
    }
}