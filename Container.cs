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
        public static LocationSection ActiveSection { get; private set; }
        public static ThreadDispatcher ThreadDispatcher { get; private set; }

        private static Chapter[] chapters;

        public static void Initiate(ContainerData data)
        {
            if (data is null)
            {
                Debug.LogWarning("Data file is null");
                return;
            }
            chapters = data.chapters;
            ThreadDispatcher = new ThreadDispatcher();
            GEvent.Attach(GlobalEvents.DropSection, OnDrop);
        }

        private static void OnDrop(object[] obj)
        {
            ActiveSection?.Drop();
        }

        public static void StartChapter(int index, IContext ctx)
        {
            if (chapters is null || index >= chapters.Length)
            {
                Debug.LogWarning($"Chapter with {index} index is not existed");
                return;
            }
            StartChapter(chapters[index], ctx);
        }

        private static void StartChapter(Chapter chapter, IContext context)
        {
            if (chapter is null)
            {
                return;
            }
            
            context.GetContext<MainContext>().SetChapter(chapter);

            GEvent.Call(GlobalEvents.DropSection);
            ActiveSection = new LocationSection(context, chapter.locationSettings);
            GEvent.Call(GlobalEvents.Start);
        }
    }
}