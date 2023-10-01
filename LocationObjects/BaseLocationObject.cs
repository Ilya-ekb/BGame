using System;
using System.Collections.Generic;
using Core;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game.LocationObjects
{
    public abstract class BaseLocationObject<TView, TSetting> : BaseDroppable, ILocationObject
        where TView : BaseDroppable, ILocationObject
        where TSetting : ViewSetting
    {
        public Guid Id { get; }
        public Transform Transform => view.Transform;

        protected readonly TView view;
        protected readonly List<IDroppable> children;
        protected readonly IContext context;
        protected readonly TSetting setting;

        protected BaseLocationObject(TSetting setting, IContext context, IDroppable parent) : base(parent)
        {
            Id = Guid.NewGuid();
            this.context = context.GetContext<MainContext>();
            this.setting = setting;
            view = (TView) setting.GetViewInstance(context, parent);
            children = new List<IDroppable>();
            foreach (var childSetting in setting.childrenSettings)
                children.Add(childSetting.GetInstance(context, this));
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            view?.SetAlive();
            InitiateChildren();
            context?.GetContext<LocationContext>()?.AddObject(this);
        }

        protected virtual void InitiateChildren()
        {
            foreach (var child in children)
                child.SetAlive();
        }

        protected virtual void DropChildren()
        {
            foreach (var child in children)
                child.Drop();
        }

        protected override void OnDrop()
        {
            context?.GetContext<LocationContext>()?.RemoveObject(Id);
            DropChildren();
            view?.Drop();
            base.OnDrop();
        }
    }
}