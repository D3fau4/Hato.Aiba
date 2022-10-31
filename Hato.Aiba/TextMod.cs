using MelonLoader;
using TMPro;
using UnityEngine;

namespace Hato.Aiba
{
    public class TextMod : MelonMod
    {
        private string Lastestloaded { get; set; }
        private bool Isalreadymoded { get; set; }

        public override void OnInitializeMelon()
        {
            Melon<TextMod>.Logger.Msg("Aiba cargada!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            Lastestloaded = sceneName;
            Isalreadymoded = false;
            Melon<TextMod>.Logger.Msg($"Se ha cargado la scena: {sceneName}");
        }

        public override void OnUpdate()
        {
            if (!Isalreadymoded)
                if (Lastestloaded.Equals("flowchart") || Lastestloaded.Equals("file") ||
                    Lastestloaded.Equals("options"))
                {
                    var gameObject = GameObject.Find("UpperGuide/title/Text");
                    if (gameObject != null) gameObject.SetActive(true);
                    else Melon<TextMod>.Logger.Msg("No se ha encontrado: UpperGuide/title/Text");
                    var gameObject2 = GameObject.Find("UpperGuide/title/Text1_root");
                    if (gameObject2 != null) gameObject2.SetActive(false);
                    else Melon<TextMod>.Logger.Msg("No se ha encontrado: UpperGuide/title/Text1_root");
                    TMP_Text text;
                    if (gameObject != null)
                        switch (Lastestloaded)
                        {
                            case "flowchart":
                                text = gameObject.GetComponent<TMP_Text>();
                                if (text != null)
                                {
                                    text.SetText("CRONOGRAMA");
                                    text.color = Color.red;
                                }
                                else
                                {
                                    Melon<TextMod>.Logger.Msg(
                                        "No se ha podido encontrar el componente de texto de flowchart");
                                }

                                break;
                            case "file":
                                text = gameObject.GetComponent<TMP_Text>();
                                if (text != null)
                                {
                                    text.SetText("ARCHIVO");
                                    text.color = Color.red;
                                }
                                else
                                {
                                    Melon<TextMod>.Logger.Msg(
                                        "No se ha podido encontrar el componente de texto de file.");
                                }

                                break;
                            case "options":
                                text = gameObject.GetComponent<TMP_Text>();
                                if (text != null)
                                {
                                    text.SetText("AJUSTES");
                                    text.color = Color.red;
                                }
                                else
                                {
                                    Melon<TextMod>.Logger.Msg(
                                        "No se ha podido encontrar el componente de texto de options.");
                                }

                                break;
                        }
                }
        }
    }
}