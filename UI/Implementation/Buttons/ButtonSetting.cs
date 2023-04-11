using Game.Contexts;

namespace Game.UI
{
    public abstract class ButtonSetting : UISetting
    {
        public string ButtonName;
        public abstract void OnClickAction(IContext context);
    }
}