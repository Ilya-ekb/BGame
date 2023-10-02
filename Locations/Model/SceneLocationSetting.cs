using Game.Locations.View;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Locations.Model
{
    [CreateAssetMenu(menuName = "Game/Settings/" + nameof(SceneLocationSetting))]
    public class SceneLocationSetting : LocationSetting
    {
        public string SceneName => sceneName;
        
#if UNITY_EDITOR
        [SerializeField] private Object rootObject;
#endif
        [SerializeField] public string rootObjectPath;
        [SerializeField] private string sceneName;

        public BaseDroppable GetViewInstance(IContext context, IDroppable parent)
        {
            return GetViewInstanceInner(context, parent);
        }

        protected override Location GetInstanceInner(IContext context, IDroppable parent)
        {
            return new SceneLocation(this, context, parent);
        }

        protected SceneLocationView GetViewInstanceInner(IContext context, IDroppable parent)
        {
            return new SceneLocationView(this, context, parent);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {

            if (rootObject)
            {
                rootObjectPath = Core.Utilities.GetValidPathToResource(rootObject);
            }
        }
#endif
    }
}