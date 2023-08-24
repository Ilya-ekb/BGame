using Game.Contexts;
using Game.Locations.Model;
using Core.ObjectsSystem;
using UnityEngine;

namespace Game.Locations.View
{
    public class LocationView : BaseDroppable
    {
        public GameObject Root { get; private set; }
        
        protected readonly IContext context;
        private readonly GameObject resources;

        public LocationView(LocationSetting setting, IContext ctx, IDroppable parent) : base(parent)
        {
            resources = Resources.Load<GameObject>(setting.rootObjectPath);
            context = ctx;
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            if(!resources)
                return;
            Root = Object.Instantiate(resources);
            Root.name = $"[{GetType().Name}]"+ resources.name;
        }
        
        protected override void OnDrop()
        {
            base.OnDrop();
            Object.Destroy(Root);
            Root = null;
        }
    }
}