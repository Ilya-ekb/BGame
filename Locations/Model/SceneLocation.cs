using System.Linq;
using Core;
using Core.ObjectsSystem;
using Game.Contexts;
using Game.Locations.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Locations.Model
{
    public class SceneLocation : Location
    {
        public GameObject Root => view.Root;

        private Scene scene;
        protected readonly SceneLocationView view;

        public SceneLocation(SceneLocationSetting setting, IContext ctx, IDroppable parent) : base(setting, ctx, parent)
        {
            view = (SceneLocationView) setting.GetViewInstance(context, parent);

            scene = SceneManager.GetSceneByName(setting.SceneName);
            if (scene is {isLoaded: true})
            {
                return;
            }

            var operation = SceneManager.LoadSceneAsync(setting.SceneName, LoadSceneMode.Additive);
            operation.completed += _ =>
            {
                scene = SceneManager.GetSceneByName(setting.SceneName);
            };
        }

        protected override void OnAlive()
        {
            Scheduler.InvokeWhen(()=> scene.isLoaded && !IsAlive, () =>
            {
                view.SetAlive();

                if (Root)
                    SceneManager.MoveGameObjectToScene(Root, scene);
                SetAliveChildren();
                IsAlive = true;
            });
        }

        protected override void OnDrop()
        {
            Scheduler.InvokeWhen(()=> !IsAlive, () =>
            {
                var chapter = context.GetContext<MainContext>().CurrentChapter;
                var isNewScene = chapter.locationSettings.All(s => s is SceneLocationSetting sls && sls.SceneName != scene.name);
                DropChildren();
                view?.Drop();

                if (isNewScene && scene.isLoaded)
                    SceneManager.UnloadSceneAsync(scene.name);
                base.OnDrop();
            });
        }
    }
}