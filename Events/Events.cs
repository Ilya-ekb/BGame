using Core;

namespace Game
{
    public static partial class Events
    {
        public static class GlobalEvents
        {
            public static string StartStatic { get; } = GEvent.GetUniqueCategory();
            public static string StartDynamic { get; } = GEvent.GetUniqueCategory();
            public static string DropStatic { get; } = GEvent.GetUniqueCategory();
            public static string DropDynamic { get; }= GEvent.GetUniqueCategory();
        }
        
        public static class GameEvents
        {
            public static string Start { get; } = GEvent.GetUniqueCategory();
            public static string Stop { get; } = GEvent.GetUniqueCategory();
            public static string Check { get; } = GEvent.GetUniqueCategory();
        }

        public static class NetworkEvents
        {
            public static string ConnectClient { get; } = GEvent.GetUniqueCategory();
            public static string DisconnectClient { get; } = GEvent.GetUniqueCategory();
        }
    }
}