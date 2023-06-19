﻿using System.Collections.Generic;
using System.Linq;
using Core;
using Core.ObjectsSystem;
using Game.Contexts;
using Game.Factories;
using UnityEngine;

namespace Game.UI
{
    public abstract class UiElement<TView, TSetting, TComponent> : BaseDroppable, IUiElement 
                    where TView : UiElementView<TSetting, TComponent>
                    where TSetting : UISetting
                    where TComponent : Component, IUIGraphicComponent
    {
        public IUIGraphicComponent RootComponent => view.Root;
        public Transform ContentHolder { get; protected set; }

        public bool IsShown { get; protected set; }

        protected List<IUiElement> ChildUiElements { get; set; }
        protected readonly UiContext uiContext;
        
        protected TView view;
        protected readonly TSetting setting;

        public void AddChild(IUiElement uiElement)
        {
            ChildUiElements.Add(uiElement);
            uiElement.SetAlive(parent);
            view.AddChildComponent(uiElement.RootComponent);
        }

        protected UiElement(TSetting setting, UiContext context)
        {
            uiContext = context;
            uiContext?.SetSelf(this);
            this.setting = setting;
            view = (TView) setting.GetViewInstance(uiContext);
            AssignChild();
        }
        
        public void Show()
        {
            if(IsShown)
                return;
            IsShown = true;
            OnShow();
        }
        
        public void Hide()
        {
            if(!IsShown)
                return;
            IsShown = false;
            OnHide();
        }
        
        public void Update<TUiAgs>(object sender, TUiAgs ags)
        {
        }

        public T GetChild<T>() where T : IUiElement
        {
            foreach (var child in ChildUiElements)
            {
                if (child is T validChild)
                    return validChild;
                validChild = child.GetChild<T>();
                if (validChild is { })
                    return validChild;
            }

            return default;
        }

        public TUiElement GetElement<TUiElement>()
        {
            return (TUiElement) ChildUiElements.FirstOrDefault(e => e is TUiElement);
        }
        
        protected override void OnAlive()
        {
            base.OnAlive();
            view.SetAlive(parent);
            SetContentHolder();
            ChildSetAlive();
            IsShown = setting.showOnAlive;
            if (setting.showOnAlive)
            {
                view.Show();
                return;
            }
            view.Hide();
        }

        protected virtual void SetContentHolder()
        {
            ContentHolder = view.Root.ContentHolder;
        }

        protected virtual void OnShow()
        {
            view.Show();
            ShowChild();
        }
        
        protected virtual void OnHide()
        {
            HideChild();
            view.Hide();
        }
        
        protected override void OnDrop()
        {
            base.OnDrop();
            view?.Drop();

            if (ChildUiElements is { })
            {
                foreach (var childUiElement in ChildUiElements)
                    childUiElement?.Drop();
            }

            ChildUiElements = null;
            view = null;
        }
        
        protected void ChildSetAlive()
        {
            if (ChildUiElements is null)
                return;

            foreach (var childUiElement in ChildUiElements)
            {
                childUiElement.SetAlive(parent);
                view.AddChildComponent(childUiElement.RootComponent);
            }
        }
        
        private void AssignChild()
        {
            ChildUiElements = new List<IUiElement>();
            foreach (var uiSetting in setting.childUiElementSettings)
            {
                var childContext = new UiContext().SendParent(this);
                childContext.AddContext(uiContext.GetContext<MainContext>());
                ChildUiElements.Add((IUiElement) uiSetting.GetInstance(childContext));
            }
        }
        
        private void ShowChild()
        {
            foreach (var uiElement in ChildUiElements)
                uiElement.Show();
        }

        private void HideChild()
        {
            foreach (var uiElement in ChildUiElements)
                uiElement.Hide();
        }
    }
}