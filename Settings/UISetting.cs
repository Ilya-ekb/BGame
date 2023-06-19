using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game.UI
{
    public abstract class UISetting : ViewSetting
    {
        public bool showOnAlive = true;
        public UISetting[] childUiElementSettings;

        public override IDroppable GetInstance<TContext>(TContext context)
        {
            if (context is UiContext uiContext)
                return GetInstance(uiContext);
            Debug.Log($"Incorrect context for {GetType()}");
            return null;
        }
        
        public override BaseDroppable GetViewInstance<TContext>(TContext context)
        {
            if (context is UiContext uiContext)
                return GetViewInstance(uiContext);
            Debug.Log($"Incorrect context for {GetType()}");
            return null;
        }

        protected abstract IDroppable GetInstance(UiContext uiContext);
        protected abstract BaseDroppable GetViewInstance(UiContext uiContext);
    }
}