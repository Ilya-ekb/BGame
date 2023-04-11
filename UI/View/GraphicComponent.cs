using UnityEngine;

namespace Game.UI
{
    public abstract class GraphicComponent<TComponent> : MonoBehComponent<TComponent>, IUIGraphicComponent where TComponent : Component
    {
        public Transform ContentHolder => contentHolder ? contentHolder : transform;
        public IGraphicMaskable GraphicMaskable => graphicMaskable;

        [SerializeField] protected GraphicMaskable graphicMaskable;
        [SerializeField] private Transform contentHolder;
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}