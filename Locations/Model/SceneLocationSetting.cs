using Core.Locations.Model;
using Core.Locations.View;
using Core.ObjectsSystem;
using Game.Contexts;
using Game.Locations;
using UnityEngine;

namespace Plugins.BGame.Locations.Model
{
    [CreateAssetMenu(menuName = "Game/Settings/"+ nameof(SceneLocationSetting))]
    public class SceneLocationSetting : LocationSetting
    {
        public string SceneName => sceneName;
        
        [SerializeField] private string sceneName;

        protected override Location GetInstanceInner(IContext context, IDroppable parent)
        {
            return new SceneLocation(this, context, parent);
        }

        protected override LocationView GetViewInstanceInner(IContext context, IDroppable parent)
        {
            return new LocationView(this, context, parent);
        }
    }
}