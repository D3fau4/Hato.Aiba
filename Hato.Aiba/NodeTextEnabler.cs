using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hato.Aiba
{
    public class NodeTextEnabler : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Melon<NodeTextEnabler>.Logger.Msg("Aiba cargada!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            Melon<NodeTextEnabler>.Logger.Msg($"Se ha cargado la scena: {sceneName}");
        }

        public override void OnUpdate()
        {
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName.Contains("flowchart") || sceneName.Contains("file") || sceneName.Contains("options"))
            {
                var gameObject = GameObject.Find("UpperGuide/title/Text");
                if (gameObject != null) gameObject.SetActive(true);
                var gameObject2 = GameObject.Find("UpperGuide/title/Text1_root");
                if (gameObject2 != null) gameObject2.SetActive(false);
            }
        }
    }
}