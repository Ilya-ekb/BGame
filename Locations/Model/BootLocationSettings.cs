using Core.ObjectsSystem;
using Game.Locations.View;
using Game.Contexts;
using UnityEngine;

namespace Game.Locations.Model
{
    [CreateAssetMenu(menuName = "Game/Settings/"+ nameof(BootLocationSetting))]
    public class BootLocationSetting : LocationSetting
    {
        protected override Location GetInstanceInner(IContext context, IDroppable parent)
        {
            return new BootLocation(this, context, parent);
        }
    }
}