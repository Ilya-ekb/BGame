using Game.Factories;
using Game.UI;
using UnityEngine;

namespace Game
{
    public abstract class Bootstrap
    {
        
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            MonoLoop.Initiate();
        }

        public static void Initiate(ContainerData data)
        {
            Container.Initiate(data);
        }
    }
}