using System.Collections.Generic;
using System.Linq;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.Locations.Model
{
    public abstract class Location : BaseDroppable
    {
        protected readonly IContext context;
        protected readonly IList<IDroppable> droppables = new List<IDroppable>();
        protected readonly LocationSetting setting;

        protected Location(LocationSetting setting, IContext context, IDroppable parent) : base(parent)
        {
            this.context = context;
            this.setting = setting;

            foreach (var objectsSetting in setting.childSettings)
                droppables.Add(objectsSetting.GetInstance(context, this));
        }

        public IEnumerable<TDroppable> GetAllObjects<TDroppable>()
        {
            return droppables.Where(o => o.GetType() == typeof(TDroppable)).Cast<TDroppable>();
        }

        public override TDroppable GetObject<TDroppable>()
        {
            TDroppable result = default;
            foreach (var droppable in droppables)
            {
                result = droppable.GetObject<TDroppable>();
                if (result is { })
                    return result;
            }

            return result;
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            SetAliveChildren();
        }

        protected override void OnDrop()
        {
            DropChildren();
            base.OnDrop();
        }

        protected virtual void SetAliveChildren()
        {
            foreach (var droppable in droppables)
                droppable?.SetAlive();
        }

        protected void DropChildren()
        {
            foreach (var droppable in droppables)
                droppable?.Drop();
            droppables.Clear();
        }
    }
}