using Game.Settings;
using Game.Contexts;
using Game.LocationObjects;

namespace Game.LocationObjects
{
    public class LocationObject : BaseLocationObject<LocationObjectView, LocationObjectSetting>
    {
        public LocationObject(LocationObjectSetting setting, IContext context) : base(setting, context)
        {
        }
    }
}