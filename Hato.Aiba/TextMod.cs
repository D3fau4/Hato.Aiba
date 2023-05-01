using System.Collections.Generic;
using MelonLoader;
using TMPro;
using UnityEngine;

namespace Hato.Aiba
{
    public class TextMod : MelonMod
    {
        private readonly List<string> scenesloaded = new List<string>();
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
            scenesloaded.Add(sceneName);
            Melon<TextMod>.Logger.Msg($"Se ha cargado la scena: {sceneName}");
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasUnloaded(buildIndex, sceneName);
            if (scenesloaded.Contains(sceneName))
                scenesloaded.Remove(sceneName);
        }

        public override void OnUpdate()
        {
            switch (Lastestloaded)
            {
                case "flowchart":
                case "file":
                case "options":
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
                                    text.SetText("ARCHIVOS");
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

                    break;
                }
                case "save":
                {
                    var TagSave = GameObject.Find("TagSave");
                    if (TagSave != null)
                    {
                        var textSAVE = TagSave.GetComponent<TMP_Text>();
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño actual de la fuente: {textSAVE.fontSize}");
                        textSAVE.SetText("GUARDAR");
                        textSAVE.fontSize = 23f;
                        TagSave.transform.position = new Vector3(-83.1f,
                            39.8f, TagSave.transform.position.z);
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño corregido de la fuente: {textSAVE.fontSize}");
                        Melon<TextMod>.Logger.Msg(
                            $"Posición del texto: {TagSave.transform.position}");
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
                        TagLoad.transform.position = new Vector3(-83.1f,
                            39.8f, TagLoad.transform.position.z);
                        Melon<TextMod>.Logger.Msg(
                            $"Tamaño corregido de la fuente: {textLOAD.fontSize}");
                        Melon<TextMod>.Logger.Msg(
                            $"Posición del texto: {textLOAD.transform.position}");
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
                        AutoSave.transform.position = new Vector3(32.6f,
                            AutoSave.transform.position.y, AutoSave.transform.position.z);
                        Melon<TextMod>.Logger.Msg(
                            $"Posición del texto: {AutoSave.transform.position}");
                        autoSave.SetText("AUTOGUARDADO");
                        Isalreadymoded = true;
                    }

                    break;
                }
                case "LanguageSelect":
                    var TextLanguageUS = GameObject.Find("TextLanguage-us");
                    if (TextLanguageUS != null)
                    {
                        var tmptext = TextLanguageUS.GetComponent<TMP_Text>();
                        tmptext.SetText("<align=center>Español</align>");
                    }

                    break;
            }

            if (scenesloaded.Contains("Somnium"))
            {
                var retrytext = GameObject.Find("ResetDialog/Window/Title");
                var life1 = GameObject.Find("ResetDialog/Window/Title/Life1");
                var life2 = GameObject.Find("ResetDialog/Window/Title/Life2");
                var life3 = GameObject.Find("ResetDialog/Window/Title/Life3");
                var mapname = GameObject.Find("Windows/Map/MapName/name_base/Text");
                
                if (retrytext != null)
                {
                    var tmptext = retrytext.GetComponent<TMP_Text>();
                    tmptext.SetText("Repetir");
                    tmptext.fontSize = 46;
                    retrytext.transform.position = new Vector3(-1.1842f, 2.85f, -9.64f);
                }

                if (life1 != null && life2 != null && life3 != null)
                {
                    life1.transform.position = new Vector3(0.7f, 2.9f, -9.6f);
                    life2.transform.position = new Vector3(1.5f, 2.9f, -9.6f);
                    life3.transform.position = new Vector3(2.3f, 2.9f, -9.6f);
                }

                if (mapname != null)
                {
                    var mapnametmp = mapname.GetComponent<TMP_Text>();
                    mapnametmp.fontSize = 34;
                }
            }

            if (scenesloaded.Contains("flowchart"))
            {
                {
                    var a = GameObject.Find("Canvas/ScreenScaler/locked/Text");
                    TMP_Text b = a.GetComponent<TMP_Text>();
                    b.SetText("CERRADO");
                    a = GameObject.Find("Canvas/ScreenScaler/unlocked/Text00");
                    b = a.GetComponent<TMP_Text>();
                    b.SetText("ABIERTO");
                }
            }
        }
    }
}