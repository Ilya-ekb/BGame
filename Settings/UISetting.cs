using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game.UI
{
    public abstract class UISetting : ViewSetting
    {
        public bool showOnAlive = true;
        public UISetting[] childUiElementSettings;

        public override IDroppable GetInstance<TContext>(TContext context, IDroppable parent)
        {
            if (context is UiContext uiContext)
                return GetInstance(uiContext, parent);
            Debug.Log($"Incorrect context for {GetType()}");
            return null;
        }
        
        public override BaseDroppable GetViewInstance<TContext>(TContext context, IDroppable parent)
        {
            if (context is UiContext uiContext)
                return GetViewInstance(uiContext, parent);
            Debug.Log($"Incorrect context for {GetType()}");
            return null;
        }

        protected abstract IDroppable GetInstance(UiContext uiContext, IDroppable parent);
        protected abstract BaseDroppable GetViewInstance(UiContext uiContext, IDroppable parent);
    }
}