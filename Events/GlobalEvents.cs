using Core;

namespace Game
{
    public static class GlobalEvents
    {
        public static string StartDynamicSection { get; } = GEvent.GetUniqueCategory();
        public static string LocationScenesUnloaded { get; }= GEvent.GetUniqueCategory();
        public static string Restart { get; } = GEvent.GetUniqueCategory();
        public static string DropDynamicSection { get; }= GEvent.GetUniqueCategory();
    }
}