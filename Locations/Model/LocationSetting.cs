using System.Linq;
using Game.Locations.View;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game.Locations.Model
{
    public abstract class LocationSetting : BaseSetting
    {
        
        public BaseSetting[] childSettings;

        public T GetConfig<T>() where T: BaseSetting
        {
            return childSettings.FirstOrDefault(s => s is T) as T;
        }

        public override IDroppable GetInstance(IContext context, IDroppable parent)
        {
            return GetInstanceInner( context, parent);
        }

        protected abstract Location GetInstanceInner( IContext context, IDroppable parent);
    }
}