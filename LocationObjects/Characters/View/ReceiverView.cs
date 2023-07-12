using System;
using System.Collections.Generic;
using Core.ObjectsSystem;
using Game.Contexts;
using Game.Characters.Control;
using Game.Views;
using UnityEngine;

namespace Game.Characters.View
{
    public abstract class ReceiverView<TSetting, TObject> : BaseLocationObjectView<TSetting, TObject>, IReceiver
        where TSetting : ViewSetting
        where TObject : Component
    {
        protected readonly IDictionary<Type, IReceiver> receivers = new Dictionary<Type, IReceiver>();

        protected ReceiverView(TSetting setting, IContext context, IDroppable parent) : base(setting, context, parent)
        {
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            foreach (var receiver in receivers.Values)
                receiver.SetAlive(parent);
        }

        protected override void OnDrop()
        {
            base.OnDrop();
            foreach (var receiver in receivers.Values)
                receiver.Drop();
        }

        public virtual void Pull(ICommand command)
        {
            var type = command.GetType();
            if (receivers.TryGetValue(type, out var receiver))
                receiver.Pull(command);
        }

        public virtual void Action(ICommand command)
        {
            var type = command.GetType();
            if (receivers.TryGetValue(type, out var receiver))
                receiver.Action(command);
        }

        public virtual void ExecuteCommands()
        {
            foreach (var receiver in receivers.Values)
                receiver.ExecuteCommands();
        }
    }
}