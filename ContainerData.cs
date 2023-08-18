using System;
using Core.Chapters;
using Core.Locations.Model;
using Plugins.BGame.Locations.Model;
using UnityEngine.Serialization;

namespace Game
{
    [Serializable]
    public class ContainerData
    {
        public LocationSetting[] bootLocationSettings;
        public Chapter[] chapters;
    }
}