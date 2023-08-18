using System.Linq;
using Core.Locations.Model;
using Core.ObjectsSystem;
using Game.Contexts;
using Plugins.BGame.Locations.Model;
using UnityEngine.SceneManagement;

namespace Game.Locations
{
    public class SceneLocation : Location
    {
        private Scene scene;

        public SceneLocation(SceneLocationSetting setting, IContext ctx, IDroppable parent) : base(setting, ctx, parent)
        {
            scene = SceneManager.GetSceneByName(setting.SceneName);
            if (scene is {isLoaded: true})
            {
                SetAlive();
                return;
            }

            var operation = SceneManager.LoadSceneAsync(setting.SceneName, LoadSceneMode.Additive);
            operation.completed += _ =>
            {
                scene = SceneManager.GetSceneByName(setting.SceneName);
                SetAlive();
            };
        }

        protected override void OnAlive()
        {
            base.OnAlive();
            if (Root)
                SceneManager.MoveGameObjectToScene(Root, scene);
        }

        protected override void OnDrop()
        {
            var chapter = context.GetContext<MainContext>().CurrentChapter;
            var isNewScene = chapter.locationSettings.All(s => s is SceneLocationSetting sls && sls.SceneName != scene.name);
            if (isNewScene && scene.isLoaded)
                SceneManager.UnloadSceneAsync(scene.name);
            base.OnDrop();
        }
    }
}