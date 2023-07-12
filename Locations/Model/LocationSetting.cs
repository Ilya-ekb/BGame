using System.Linq;
using Core.Locations.View;
using Core.ObjectsSystem;
using Game;
using Game.Locations;
using UnityEngine;

namespace Core.Locations.Model
{
    [CreateAssetMenu(menuName = "Game/Settings/"+ nameof(LocationSetting), fileName = nameof(LocationSetting))]
    public class LocationSetting : ViewSetting
    {
        public string SceneName => sceneName;
        
        public BaseSetting[] childSettings;

        [SerializeField] private string sceneName;

        public T GetConfig<T>() where T: BaseSetting
        {
            return childSettings.FirstOrDefault(s => s is T) as T;
        }

        public override IDroppable GetInstance<TContext>(TContext context, IDroppable parent)
        {
            return new SceneLocation(this, context, parent);
        }

        public override BaseDroppable GetViewInstance<TContext>(TContext context, IDroppable parent)
        {
            return new LocationView(this, context, parent);
        }
    }
}