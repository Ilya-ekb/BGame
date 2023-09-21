using System;
using Game.Contexts;
using Core.ObjectsSystem;
using Game.LocationObjects;
using Game.Locations.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Views
{
    public abstract class BaseLocationObjectView<TSetting, TObject> : BaseDroppable, ILocationObject
        where TSetting : ViewSetting
        where TObject : Component
    {
        public Guid Id { get; }
        public Transform Transform => Root.transform;

        protected virtual Vector3 Position
        {
            get => Transform.position;
            set => Transform.position = value;
        }

        protected virtual Quaternion Rotation
        {
            get => Transform.rotation;
            set => Transform.rotation = value;
        }

        public TObject Root { get; private set; }

        protected readonly TSetting setting;
        protected readonly IContext context;

        protected BaseLocationObjectView(TSetting setting, IContext context, IDroppable parent) : base(parent)
        {
            Id = Guid.NewGuid();
            this.context = context;
            this.setting = setting;
        }

        protected virtual void LoadResource(Action<TObject> onComplete)
        {
            var resource = Resources.Load<TObject>(setting.rootObjectPath);
            onComplete?.Invoke(resource);
        }

        protected override void OnAlive()
        {
            LoadResource(resource =>
            {
                if (resource is null)
                {
                    Debug.LogError($"<COLOR=YELLOW>{typeof(TObject).Name}</COLOR> is not loaded from {setting.rootObjectPath}");
                    return;
                }

                CreateView(resource);
                base.OnAlive();
            });
        }

        protected override void OnDrop()
        {
            base.OnDrop();
            if (Root)
                Object.DestroyImmediate(Root.gameObject);
            Root = null;
        }

        protected void CreateView(TObject resource)
        {
            var parentTransform = parent switch
            {
                ILocationObject locationObject => locationObject.Transform,
                SceneLocation location => location.Root.transform,
                _ => null
            };

            Root = Object.Instantiate(resource, parentTransform);
            Root.name = $"[{GetType().Name}] {setting.name}";
            Root.transform.SetSiblingIndex(setting.siblingIndex);
            OnCreateView();
        }

        protected virtual void OnCreateView()
        {
        }
    }
}