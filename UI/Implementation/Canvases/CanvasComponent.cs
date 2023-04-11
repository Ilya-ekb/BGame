namespace Game.UI
{
    public class CanvasComponent : GraphicComponent<CanvasComponent>
    {
#if UNITY_EDITOR
        private void OnValidate()  => graphicMaskable?.OnValidate();
#endif
    }
}