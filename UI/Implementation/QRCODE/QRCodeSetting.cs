using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/QRCodeSetting", fileName = nameof(QRCodeSetting))]
    public class QRCodeSetting : UISetting
    {
        public Vector2Int size;
        public Color foregroundColor = Color.black;
        public Color codeColor = Color.white;
    }
}