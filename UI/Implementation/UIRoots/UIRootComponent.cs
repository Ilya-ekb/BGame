namespace Game.UI
{
    public class UIRootComponent : GraphicComponent<UIRootComponent>
    {
#if UNITY_EDITOR
        private void OnValidate()  => graphicMaskable?.OnValidate();
#endif
    }
}