using Core.ObjectsSystem;
using Game.Contexts;

namespace Game.Factories
{
    public abstract class Factory : IFactory
    {
        public IDroppable CreateItem<TConfig>(TConfig config, IContext context) where TConfig : ISetting
        {
            return config.GetInstance(context);
        }
    }
}