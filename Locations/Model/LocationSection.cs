using System;
using System.Linq;
using System.Threading.Tasks;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Core.Locations.Model
{
    public class LocationSection : BaseDroppable
    {
        private readonly IDroppable[] locations;

        public LocationSection(IContext context, params LocationSetting[] locationSettings) : base(null)
        {
            locations = new IDroppable[locationSettings.Length];
            for (var i = 0; i < locationSettings.Length; i++)
                locations[i] = locationSettings[i].GetInstance(context, this);
            GEvent.Attach(GlobalEvents.StartDynamicSection, OnStart);
        }

        private async void OnStart(object[] obj)
        {
            GEvent.Detach(GlobalEvents.StartDynamicSection, OnStart);
            await Task.Run(AwaitLoad);
            SetAlive();
        }

        protected override void OnDrop()
        {
            foreach (var loc in locations)
                loc.Drop();
            base.OnDrop();
        }

        private void AwaitLoad() { while (locations.Any(l => l is {Alive: false})) { } }

        public TDroppable GetObject<TDroppable>(Func<TDroppable, bool> predicate = null) where TDroppable : IDroppable
        {
            foreach (var loc in locations)
            {
                var result = ((Location)loc).GetFirstOrDefaultObject(predicate);
                if (result is { })
                    return result;
            }

            return default;
        }
    }
}