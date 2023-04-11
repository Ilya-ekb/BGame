using UnityEngine;

namespace Game.UI
{
    public interface IUIGraphicComponent
    {
        Transform ContentHolder { get; }
        IGraphicMaskable GraphicMaskable { get; }
        void Show();
        void Hide();
    }

    public interface IGraphicMaskable
    {
        void Initiate();
        void SetColorA(float a);
        void AddMaskable(IGraphicMaskable maskable);
    }
}