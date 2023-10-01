using Core.Entities.Loopables;
using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game
{
    public abstract class ViewSetting : BaseSetting
    {
        public int siblingOffset;
        public int siblingIndex;
        public Object rootObject;
        public string rootObjectPath;
        public ViewSetting[] childrenSettings;
        
        public abstract BaseDroppable GetViewInstance<TContext>(TContext context, IDroppable parent) where TContext : IContext;

        protected virtual void GetReference()
        {
#if UNITY_EDITOR
            rootObjectPath = Core.Utilities.GetValidPathToResource(rootObject);
#endif
        }
        
        protected virtual void OnValidate()
        {
            if (!rootObject) return;
#if UNITY_EDITOR
            GetReference();
            for (var i = 0; i < childrenSettings.Length; i++)
            {
                childrenSettings[i].siblingIndex = i + siblingOffset;
                childrenSettings[i].GetReference();
            }
#endif
        }
    }

    public abstract class ControlSetting<TControl> : ViewSetting where TControl : ControlLoopable
    {
        public abstract TControl GetControlLoopable<TContext>(TContext context) where TContext : IContext;
    }
}