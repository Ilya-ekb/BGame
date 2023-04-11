using System;
using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.Factories
{
    public interface IFactory 
    {
        Type SettingType { get; }
        IDroppable CreateItem<TConfig>(TConfig config, IContext context);
    }
}