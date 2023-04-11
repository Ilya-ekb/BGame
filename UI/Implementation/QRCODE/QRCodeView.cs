using UnityEngine;

namespace Game.UI
{
    public class QRCodeView : UiElementView<QRCodeSetting, QRCodeComponent>
    {
        public QRCodeView(QRCodeSetting setting, UiContext ctx) : base(setting, ctx)
        {
        }

        public void SetTexture(Texture2D qrCodeTexture)
        {
            Root.SetTexture(qrCodeTexture);
        }
    }
}