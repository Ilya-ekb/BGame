namespace Game.UI
{
    public class Canvas : UiElement<CanvasView, CanvasSetting, CanvasComponent>
    {
        public Canvas(CanvasSetting setting, UiContext context) : base(setting, context)
        {
        }
    }
}