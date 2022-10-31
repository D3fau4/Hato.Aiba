using System.Collections;
using System.Threading;
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

        IEnumerator SearchAndReplaceText(string gameobjectname, string text, float xdiff = 0, float ydiff = 0, float zdiff = 0)
        {
            var gameObject = GameObject.Find(gameobjectname);
            var tmptext = gameObject.GetComponent<TMP_Text>();
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 14f,
                gameObject.transform.position.y, gameObject.transform.position.z);
            tmptext.SetText("AUTOGUARDADO");
            yield return null;
        }

        public override void OnUpdate()
        {
            if (!Isalreadymoded)
            {
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
                                    Isalreadymoded = true;
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
                                    Isalreadymoded = true;
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
                                    Isalreadymoded = true;
                                }
                                else
                                {
                                    Melon<TextMod>.Logger.Msg(
                                        "No se ha podido encontrar el componente de texto de options.");
                                }

                                break;
                        }
                }

                if (Lastestloaded.Equals("save"))
                {
                    var TagSave = GameObject.Find("TagSave");
                    if (TagSave != null)
                    {
                        var textSAVE = TagSave.GetComponent<TMP_Text>();
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño actual de la fuente: {textSAVE.fontSize}");
                        textSAVE.SetText("GUARDAR");
                        textSAVE.fontSize = 23f;
                        TagSave.transform.position = new Vector3(TagSave.transform.position.x - 1f,
                            TagSave.transform.position.y - 1.1f, TagSave.transform.position.z);
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño corregido de la fuente: {textSAVE.fontSize}");
                        Isalreadymoded = true;
                    }
                    else
                    {
                        Melon<TextMod>.Logger.Msg(
                            "No se ha podido encontrar el componente de texto de save");
                    }

                    var TagLoad = GameObject.Find("TagLoad");
                    if (TagLoad != null)
                    {
                        var textLOAD = TagLoad.GetComponent<TMP_Text>();
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño actual de la fuente: {textLOAD.fontSize}");
                        textLOAD.SetText("CARGAR");
                        textLOAD.fontSize = 25f;
                        TagLoad.transform.position = new Vector3(TagLoad.transform.position.x - 0.3f,
                            TagLoad.transform.position.y - 1.1f, TagLoad.transform.position.z);
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño corregido de la fuente: {textLOAD.fontSize}");
                        Isalreadymoded = true;
                    }
                    else
                    {
                        Melon<TextMod>.Logger.Msg(
                            "No se ha podido encontrar el componente de texto de load");
                    }
                    
                    var AutoSave = GameObject.Find("Autosave");
                    if (AutoSave != null)
                    {
                        var autoSave = AutoSave.GetComponent<TMP_Text>();
                        AutoSave.transform.position = new Vector3(AutoSave.transform.position.x - 14f,
                            AutoSave.transform.position.y, AutoSave.transform.position.z);
                        autoSave.SetText("AUTOGUARDADO");
                        Isalreadymoded = true;
                    }
                    else
                    {
                        Melon<TextMod>.Logger.Msg(
                            "No se ha podido encontrar el componente de texto de autosave");
                        Thread a = new Thread(delegate(object o)
                        {
                            while (AutoSave == null)
                            {
                                AutoSave = GameObject.Find("Autosave");
                                if (AutoSave != null)
                                {
                                    var autoSave = AutoSave.GetComponent<TMP_Text>();
                                    AutoSave.transform.position = new Vector3(AutoSave.transform.position.x - 14f,
                                        AutoSave.transform.position.y, AutoSave.transform.position.z);
                                    autoSave.SetText("AUTOGUARDADO");
                                    
                                }
                            }
                        });
                        a.Start();
                        Isalreadymoded = true;
                    }
                }
            }
        }
    }
}