using GameLogic;
using UnityEngine;

namespace Game
{
    public partial class Bootstrap
    {
        private static ContainerData data;
        
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            Initiate();
            MonoLoop.Initiate();
            Container.Initiate(data);
        }

        static partial void Initiate();
    }
}