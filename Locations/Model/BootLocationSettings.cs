using Core.Locations.View;
using Core.ObjectsSystem;
using Game.Contexts;
using Plugins.BGame.Locations.Model;
using UnityEngine;

namespace Core.Locations.Model
{
    [CreateAssetMenu(menuName = "Game/Settings/"+ nameof(BootLocationSetting))]
    public class BootLocationSetting : LocationSetting
    {
        protected override Location GetInstanceInner(IContext context, IDroppable parent)
        {
            return new BootLocation(this, context, parent);
        }

        protected override LocationView GetViewInstanceInner(IContext context, IDroppable parent)
        {
            return null;
        }
    }
}