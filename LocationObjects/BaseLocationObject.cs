using System;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game.LocationObjects
{
    public abstract class BaseLocationObject<TView, TSetting> : BaseDroppable, ILocationObject
        where TView : BaseDroppable, ILocationObject
        where TSetting : ViewSetting
    {
        public Guid Id { get; protected set; }
        public Transform Transform => view.Transform;
        protected readonly TView view;
        protected readonly IContext context;

        protected BaseLocationObject(TSetting setting, IContext context, IDroppable parent) : base(parent)
        {
            Id = Guid.NewGuid();
            this.context = context.GetContext<MainContext>();
            view = (TView) setting.GetViewInstance(context, parent);
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            view?.SetAlive();
            context?.GetContext<LocationContext>()?.AddObject(this);
        }

        protected override void OnDrop()
        {
            context?.GetContext<LocationContext>()?.RemoveObject(Id);
            base.OnDrop();
            view?.Drop();
        }
    }
}