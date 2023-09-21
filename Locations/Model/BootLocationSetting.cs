using Core.ObjectsSystem;
using Game.Contexts;
using Game.Utilities;
using UnityEngine;

namespace Game.Locations.Model
{
    [CreateAssetMenu(menuName = Paths.PersistentSettingPath + nameof(BootLocation))]
    public class BootLocationSetting : LocationSetting
    {
        protected override Location GetInstanceInner(IContext context, IDroppable parent)
        {
            return new BootLocation(this, context, parent);
        }
    }
}