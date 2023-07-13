using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Utility.LoadScene
{
    public class SceneLoader
    {
        public static void LoadSceneAsync(SceneName name, UnityAction<Scene, LoadSceneMode> sceneLoaded = null)
        {
            SceneManager.LoadSceneAsync(name.EnumToString());
            if (sceneLoaded != null)
            {
                void SceneLoaded(Scene sc, LoadSceneMode md)
                {
                    sceneLoaded(sc, md);
                    SceneManager.sceneLoaded -= SceneLoaded;
                }
                SceneManager.sceneLoaded += SceneLoaded;
            }
        }
    }

    public enum SceneName
    {
        Setup,
        Title,
        Map,
        Ending,
    }

    static class SceneNameExtension
    {
        public static string EnumToString(this SceneName name)
        {
            switch (name)
            {
                case SceneName.Setup:
                    return "Setup";
                case SceneName.Title:
                    return "Title";
                case SceneName.Map:
                    return "Map";
                case SceneName.Ending:
                    return "Ending";
            }
            return null;
        }
    }
}