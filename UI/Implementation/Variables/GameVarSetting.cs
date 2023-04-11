using System;
using Core.ObjectsSystem;
using UnityEngine;

namespace Game.UI
{
    public abstract class GameVarSetting : UISetting
    {
        public Action<object> OnUpdateSender { get; set; }
        public abstract void Subscribe(IDroppable droppable);
        public abstract void Unsubscribe(IDroppable droppable);

        public Sprite gameVarIcon;
        public Color color;
    }
}