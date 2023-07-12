using Core.ObjectsSystem;

namespace Game.UI
{
    public class Canvas : UiElement<CanvasView, CanvasSetting, CanvasComponent>
    {
        public Canvas(CanvasSetting setting, UiContext context, IDroppable parent) : base(setting, context, parent)
        {
        }
    }
}