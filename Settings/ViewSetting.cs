using Core;
using Core.Entities.Loopables;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game
{
    public abstract class ViewSetting : BaseSetting
    {
        public Object rootObject;
        public string rootObjectPath;

        public abstract BaseDroppable GetViewInstance<TContext>(TContext context) where TContext : IContext;
        
        protected virtual void OnValidate()
        {
            if (rootObject)
            {
#if UNITY_EDITOR
                rootObjectPath = Utilities.GetValidPathToResource(rootObject);
#endif
            }
        }
    }

    public abstract class ControlSetting<TControl> : ViewSetting where TControl : ControlLoopable
    {
        public abstract TControl GetControlLoopable<TContext>(TContext context) where TContext : IContext;
    }
}