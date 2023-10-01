using System;
using System.Threading;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.Locations.Model
{
    public class LocationSection : BaseDroppable
    {
        private readonly IDroppable[] locations;
        private CancellationToken token;

        public LocationSection(IContext context, params LocationSetting[] locationSettings) : base(null)
        {
            locations = new IDroppable[locationSettings.Length];
            for (var i = 0; i < locationSettings.Length; i++)
                locations[i] = locationSettings[i].GetInstance(context, this);
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            foreach (var location in locations)
                location?.SetAlive();
        }

        protected override void OnDrop()
        {
            foreach (var loc in locations)
                loc?.Drop();
            base.OnDrop();
        }
        
        public override TDroppable GetObject<TDroppable>()
        {
            foreach (var loc in locations)
            {
                var result = loc.GetObject<TDroppable>();
                if (result is { })
                    return result;
            }

            return default;
        }
    }
}