using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/" + nameof(CanvasSetting))]
    public class CanvasSetting : UISetting
    {
        protected override IDroppable GetInstance(UiContext uiContext, IDroppable parent)
        {
            return new Canvas(this, uiContext, parent);
        }

        protected override BaseDroppable GetViewInstance(UiContext uiContext, IDroppable parent)
        {
            return new CanvasView(this, uiContext, parent);
        }
    }
}
