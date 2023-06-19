using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    [CreateAssetMenu(menuName = "Game/UI Settings/" + nameof(CanvasSetting))]
    public class CanvasSetting : UISetting
    {
        protected override IDroppable GetInstance(UiContext uiContext)
        {
            return new Canvas(this, uiContext);
        }

        protected override BaseDroppable GetViewInstance(UiContext uiContext)
        {
            return new CanvasView(this, uiContext);
        }
    }
}
