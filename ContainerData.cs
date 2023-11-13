using System;
using Game.Chapters;
using Game.Locations.Model;

namespace Game
{
    [Serializable]
    public class ContainerData
    {
        public int startChapter = 0;
        public LocationSetting[] bootLocationSettings;
        public Chapter[] chapters;
    }
}