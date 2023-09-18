using System;
using Core.ObjectsSystem;
using UnityEngine;

namespace Game.LocationObjects
{
    public interface ILocationObject : IDroppable
    {
        public Guid Id { get; }
        public Transform Transform { get; }
    }
}