using System;
using Core.Locations.Model;
using Core.ObjectsSystem;
using Game.Contexts;
using Game.Locations;

namespace Game.Factories
{
    public class LocationFactory : IFactory
    {
        public Type SettingType => typeof(ViewSetting);
        public IDroppable CreateItem<TConfig>(TConfig config, IContext context)
        {
            return config switch
            {
                LocationSetting setting => new SceneLocation(setting, context),
                _ => null,
            };
        }
    }
}