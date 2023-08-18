using System.Linq;
using Core.Locations.View;
using Core.ObjectsSystem;
using Game;
using Game.Contexts;

namespace Core.Locations.Model
{
    public abstract class LocationSetting : ViewSetting
    {
        
        public BaseSetting[] childSettings;
        
        public T GetConfig<T>() where T: BaseSetting
        {
            return childSettings.FirstOrDefault(s => s is T) as T;
        }

        public override IDroppable GetInstance<TContext>(TContext context, IDroppable parent)
        {
            return GetInstanceInner( context, parent);
        }

        public override BaseDroppable GetViewInstance<TContext>(TContext context, IDroppable parent)
        {
            return GetViewInstanceInner(context, parent);
        }

        protected abstract Location GetInstanceInner( IContext context, IDroppable parent);
        protected abstract LocationView GetViewInstanceInner(IContext context, IDroppable parent);
    }
}