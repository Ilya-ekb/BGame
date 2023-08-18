using Core.Locations.Model;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Plugins.BGame.Locations.Model
{
    public class BootLocation : Location
    {
        public BootLocation(BootLocationSetting setting, IContext context, IDroppable parent) : base(setting, context, parent)
        {
            SetAlive();
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            SetAliveChildren();
        }
    }
}