using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.Locations.Model
{
    public class LocationSection : BaseDroppable
    {
        private readonly IDroppable[] locations;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken token;

        public LocationSection(IContext context, params LocationSetting[] locationSettings) : base(null)
        {
            locations = new IDroppable[locationSettings.Length];
            for (var i = 0; i < locationSettings.Length; i++)
                locations[i] = locationSettings[i].GetInstance(context, this);
        }

        public async void DelayedSetAlive()
        {
            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;
            await Task.Run(AwaitLoad, token);
        }

        protected override void OnDrop()
        {
            cancellationTokenSource.Cancel();
            foreach (var loc in locations)
                loc.Drop();
            base.OnDrop();
        }

        private void AwaitLoad() {
            while (locations.Any(l => l is {IsAlive: false}))
            {
                if(token.IsCancellationRequested)
                    return;
            } 
            SetAlive();
        }

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