using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game
{
    public abstract class BaseSetting : ScriptableObject
    {
        public abstract IDroppable GetInstance(IContext context, IDroppable parent);
    }
}