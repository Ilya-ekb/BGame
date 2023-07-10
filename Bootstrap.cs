using Game.Factories;
using Game.UI;
using UnityEngine;

namespace Game
{
    public abstract class Bootstrap
    {
        public static void Initiate(ContainerData data)
        {
            MonoLoop.Initiate();
            Container.Initiate(data);
        }
    }
}