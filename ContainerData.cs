using System;
using Game.Chapters;
using Game.Locations.Model;

namespace Game
{
    [Serializable]
    public class ContainerData
    {
        public LocationSetting[] bootLocationSettings;
        public Chapter[] chapters;
    }
}