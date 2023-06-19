using Core.ObjectsSystem;
using Game.Contexts;
using UnityEngine;

namespace Game
{
    public abstract class BaseSetting : ScriptableObject, ISetting
    {
        public abstract IDroppable GetInstance<TContext>(TContext context) where TContext : IContext;
    }

    public interface ISetting
    {
        IDroppable GetInstance<TContext>(TContext context) where TContext : IContext;
    }
}