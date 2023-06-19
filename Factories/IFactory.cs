using System;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.Factories
{
    public interface IFactory
    {
        IDroppable CreateItem<TConfig>(TConfig config, IContext context) where TConfig : ISetting;
    }
}