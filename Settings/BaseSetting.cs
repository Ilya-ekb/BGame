using Core.ObjectsSystem;
using Game.Characters.Control;
using Game.Contexts;
using UnityEngine;

namespace Game
{
    public abstract class BaseSetting : ScriptableObject
    {
        public abstract IDroppable GetInstance<TContext>(TContext context, IDroppable parent) where TContext : IContext;
    }
}