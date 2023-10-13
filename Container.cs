using System;
using System.ComponentModel;
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
        private static MainContext context;

        public static void Initiate(ContainerData data)
        {
            if (data is null)
            {
                throw new Exception("Data file is null");
            }

            chapters = data.chapters;
            context = new MainContext();
            context.AddContext(context);
            StartStaticSection(data.bootLocationSettings);
            StartDynamicSection(0);
        }

        public static void StartStaticSection(LocationSetting[] locationSettings)
        {
            if (locationSettings is null || locationSettings.Length == 0)
                return;

            StaticSection = new LocationSection(context, locationSettings);
            GEvent.Attach(Events.GlobalEvents.StartStatic, OnStartStatic);
            GEvent.Attach(Events.GlobalEvents.DropStatic, OnDropStatic);
            GEvent.Call(Events.GlobalEvents.StartStatic);
        }

        public static void StartDynamicSection(int index)
        {
            if (chapters is null || index >= chapters.Length || index < 0)
            {
                Console.WriteLine($"Chapter with {index} index is not existed");
                return;
            }

            StartChapter(chapters[index]);
        }

        public static TDroppable GetObject<TDroppable>() where TDroppable : IDroppable
        {
            var result = (StaticSection is { } ? StaticSection.GetObject<TDroppable>() : default) ??
                         (DynamicSection is { } ? DynamicSection.GetObject<TDroppable>() : default);
            return result;
        }

        public static TContext GetContext<TContext>(Func<TContext, bool> predicate = null)
            where TContext : class, IContext
        {
            return context.GetContext(predicate);
        }

        public static void Dispose()
        {
            DynamicSection?.Drop();
            StaticSection?.Drop();

            DynamicSection = null;
            StaticSection = null;
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
            StaticSection?.SetAlive();
        }

        private static void OnStartDynamic(object[] obj)
        {
            GEvent.Detach(Events.GlobalEvents.StartDynamic, OnStartDynamic);
            DynamicSection?.SetAlive();
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