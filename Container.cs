using System;
using Core;
using Core.ObjectsSystem;
using Game.Chapters;
using Game.Locations.Model;
using Game.Contexts;

namespace Game
{
    public static class Container
    {
        public static LocationSection StaticSection { get; private set; }
        public static LocationSection DynamicSection { get; private set; }

        private static Chapter[] chapters;
        private static IContext context;

        public static void Initiate(ContainerData data)
        {
            if (data is null)
            {
                throw new Exception("Data file is null");
            }

            chapters = data.chapters;
            context = new MainContext();
            context.AddContext(context);

            GEvent.Attach(Events.GlobalEvents.StartStatic, OnStartStatic);
        }

        public static void StartStaticSection(LocationSetting[] locationSettings)
        {
            if (locationSettings is null || locationSettings.Length == 0)
                return;

            StaticSection = new LocationSection(context, locationSettings);

            GEvent.Attach(Events.GlobalEvents.DropStatic, OnDropStatic);
            GEvent.Call(Events.GlobalEvents.StartStatic);
        }

        public static void StartDynamicSection(int index)
        {
            if (chapters is null || index >= chapters.Length)
            {
                throw new Exception($"Chapter with {index} index is not existed");
            }

            StartChapter(chapters[index]);
        }

        public static TDroppable GetObject<TDroppable>(Func<TDroppable, bool> predicate = null) where TDroppable : IDroppable
        {
            return StaticSection is { } ? StaticSection.GetObject(predicate) :
                DynamicSection is { } ? DynamicSection.GetObject(predicate) : 
                default;
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

            GEvent.Attach(Events.GlobalEvents.StartDynamic, OnStartDynamic);
            GEvent.Call(Events.GlobalEvents.DropDynamic);
            
            DynamicSection = new LocationSection(context, chapter.locationSettings);

            GEvent.Attach(Events.GlobalEvents.DropDynamic, OnDropDynamic);
            GEvent.Call(Events.GlobalEvents.StartDynamic);
        }

        private static void OnStartStatic(object[] obj)
        {
            GEvent.Detach(Events.GlobalEvents.StartStatic, OnStartStatic);
            StaticSection?.DelayedSetAlive();
        }

        private static void OnStartDynamic(object[] obj)
        {
            GEvent.Detach(Events.GlobalEvents.StartDynamic, OnStartDynamic);
            DynamicSection?.DelayedSetAlive();
        }

        private static void OnDropStatic(object[] obj)
        {
            GEvent.Detach(Events.GlobalEvents.DropStatic, OnDropStatic);
            StaticSection?.Drop();
        }

        private static void OnDropDynamic(object[] obj)
        {
            GEvent.Detach(Events.GlobalEvents.DropDynamic, OnDropDynamic);
            DynamicSection?.Drop();
        }
    }
}