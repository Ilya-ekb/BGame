using Core;
using Core.Chapters;
using Core.Locations.Model;
using Game.Contexts;
using Game.Networks;
using UnityEngine;

namespace Game
{
    public static partial class Container
    {
        public static LocationSection StaticSection { get; private set; }
        public static LocationSection DynamicSection { get; private set; }
        public static ThreadDispatcher ThreadDispatcher { get; private set; }

        private static Chapter[] chapters;
        private static IContext context;

        public static void Initiate(ContainerData data)
        {
            if (data is null)
            {
                Debug.LogWarning("Data file is null");
                return;
            }
            chapters = data.chapters;
            context = new MainContext();
            context.AddContext(context);
            StaticSection = new LocationSection(context, data.bootLocationSettings);
            StaticSection.SetAlive();
            ThreadDispatcher = new ThreadDispatcher();
            GEvent.Attach(GlobalEvents.DropDynamicSection, OnDrop);
        }
        
        public static void StartChapter(int index)
        {
            if (chapters is null || index >= chapters.Length)
            {
                Debug.LogWarning($"Chapter with {index} index is not existed");
                return;
            }
            StartChapter(chapters[index]);
        }

        public static void Dispose()
        {
            StaticSection?.Drop();
        }

        private static void StartChapter(Chapter chapter)
        {
            if (chapter is null)
            {
                return;
            }
            
            context.GetContext<MainContext>().SetChapter(chapter);

            GEvent.Call(GlobalEvents.DropDynamicSection);
            DynamicSection = new LocationSection(context, chapter.locationSettings);
            GEvent.Call(GlobalEvents.StartDynamicSection);
        }
        
        private static void OnDrop(object[] obj)
        {
            DynamicSection?.Drop();
        }
    }
}