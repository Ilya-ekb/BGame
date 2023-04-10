using System;
using Contexts;
using Game.UI;

namespace Game
{
    public class UiContext : IContext
    {
        public IUiElement MainUiElement { get; private set; }
        public IUiElement ParentUiElement { get; private set; }
        
        private IContext parentContext;
        
        public UiContext SetSelf(IUiElement uiElement)
        {
            MainUiElement = uiElement;
            return this;
        }
        public UiContext SendParent(IUiElement uiElement)
        {
            ParentUiElement = uiElement;
            return this;
        }

        public TType GetContext<TType>(Func<TType, bool> predicate = null) where TType : class, IContext
        {
            TType result;
            if (typeof(TType) == typeof(UiContext))
                result = this as TType;
            else
                result = (TType) parentContext;

            return result;
        }

        public void AddContext<TType>(TType context) where TType : IContext
        {
            parentContext = context;
        }

        public void RemoveContext<TType>() where TType : IContext
        {
        }
    }
}