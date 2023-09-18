using Core.ObjectsSystem;
using Game.Contexts;
using Game.Locations.Model;
using UnityEngine;

namespace Game.Locations.View
{
    public class SceneLocationView : BaseDroppable
    {
        public GameObject Root { get; protected set; }

        private readonly GameObject resources;
        protected readonly IContext context;
        protected readonly SceneLocationSetting setting;

        public SceneLocationView(SceneLocationSetting setting, IContext ctx, IDroppable parent) : base(parent)
        {
            resources = Resources.Load<GameObject>(setting.rootObjectPath);
            context = ctx;
            this.setting = setting;
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            if(!resources)
                return;
            Root = Object.Instantiate(resources);
            Root.name = $"[{GetType().Name}] "+ setting.name;
        }

        protected override void OnDrop()
        { 
            Object.Destroy(Root);
            Root = null;
            base.OnDrop();
        }
    }
}