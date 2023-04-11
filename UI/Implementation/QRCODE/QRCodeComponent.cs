using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class QRCodeComponent : GraphicComponent<Image>
    {
        private Material material;
        
        private void OnEnable()
        {
            material = new Material(LegacyComponent.material);
            LegacyComponent.material = material;
        }

        public void SetTexture(Texture2D texture2D)
        {
            material.mainTexture = texture2D;
        }
    }
}