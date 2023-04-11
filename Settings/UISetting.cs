using Game.Settings;

namespace Game.UI
{
    public abstract class UISetting : ViewSetting
    {
        public bool showOnAlive = true;
        public UISetting[] childUiElementSettings;
    }
}