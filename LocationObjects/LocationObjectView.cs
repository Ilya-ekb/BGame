using Game.Settings;
using Game.Contexts;
using Game.LocationObjects;
using Game.Views;
using UnityEngine;

namespace Game.LocationObjects
{
    public class LocationObjectView : BaseLocationObjectView<LocationObjectSetting, Transform>, ILocationObject
    {
        public LocationObjectView(LocationObjectSetting setting, IContext context) : base(setting, context)
        {
        }
    }
}