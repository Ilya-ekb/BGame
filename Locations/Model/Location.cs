using System;
using System.Collections.Generic;
using System.Linq;
using Game.Locations.View;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game.Locations.Model
{
    public abstract class Location : BaseDroppable

    {
        public GameObject Root => view.Root;

        protected readonly LocationView view;
        protected readonly IContext context;
        protected readonly IList<IDroppable> droppables = new List<IDroppable>();
        protected readonly LocationSetting setting;

        protected Location(LocationSetting setting, IContext context, IDroppable parent) : base(parent)
        {
            this.context = context;
            this.setting = setting;
            view = (LocationView) setting.GetViewInstance(context, parent);
            
            foreach (var objectsSetting in setting.childSettings)
                droppables.Add(objectsSetting.GetInstance(context, this));
        }

        public IEnumerable<TDroppable> GetAllObjects<TDroppable>()
        {
            return droppables.Where(o => o.GetType() == typeof(TDroppable)).Cast<TDroppable>();
        }

        public TDroppable GetFirstOrDefaultObject<TDroppable>(Func<TDroppable, bool> predicate = null)
            where TDroppable : IDroppable
        {
            return droppables.Where(d => d is TDroppable).Cast<TDroppable>()
                .FirstOrDefault(d => predicate is null || predicate(d));
        }

        protected override void OnAlive()
        {
            if (view is null)
                return;
            view.SetAlive();
            SetAliveChildren();
        }
        
        protected virtual void SetAliveChildren()
        {
            foreach (var droppable in droppables)
                droppable?.SetAlive();
        }

        protected override void OnDrop()
        {
            view?.Drop();
            DropChildren();
        }

        private void DropChildren()
        {
            foreach (var droppable in droppables)
                droppable?.Drop();
            droppables.Clear();
        }
    }
}