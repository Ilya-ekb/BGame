using Core;

namespace Game
{
    public static class GameEvents
    {
        public static string Start { get; } = GEvent.GetUniqueCategory();
        public static string Stop { get; } = GEvent.GetUniqueCategory();
    }
}