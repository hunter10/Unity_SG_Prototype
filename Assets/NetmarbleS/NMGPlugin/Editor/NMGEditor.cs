namespace NetmarbleS.NMGPlugin
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    [CustomEditor(typeof(Setting))]
    public class NMEditor : Editor
    {
        Dictionary<string, Editor> editorList;
        string[] options = { "Use", "Not-Use" };

        public override void OnInspectorGUI()
        {
            Setting instance = target as Setting;

            instance.IsUse = EditorGUILayout.Popup(instance.IsUse, options);

            if (instance.IsUse == 0)
            {
                if (null != instance.kits)
                {
                    if (null == editorList)
                    {
                        editorList = new Dictionary<string, Editor>();
                        foreach (KeyValuePair<string, ScriptableObject> kit in instance.kits)
                        {
                            editorList.Add(kit.Key, Editor.CreateEditor(kit.Value));
                        }
                    }

                    foreach (KeyValuePair<string, Editor> editor in editorList)
                    {
                        EditorGUILayout.LabelField("[" + editor.Key + "]");
                        editor.Value.OnInspectorGUI();
                        DrawSeperator();
                    }

                    if (GUILayout.Button("Apply Android Configuration"))
                    {
                        CoreKitSetting core = instance.kits["CoreKit"] as CoreKitSetting;

                        NMGXmlGenerator xml = new NMGXmlGenerator(PlayerSettings.bundleIdentifier, core);

                        foreach (KeyValuePair<string, ScriptableObject> kit in instance.kits)
                        {
                            System.Type type =  kit.Value.GetType();
                            System.Reflection.FieldInfo fieldInfo = type.GetField("replaceDic", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            if (null != fieldInfo)
                            {
                                Dictionary<string, string> replaceDic = (Dictionary<string, string>) type.GetMethod("GetReplaceDic").Invoke(kit.Value, null);
                                xml.AddReplaceDic(replaceDic);
                            }
                        }

                        xml.GenerateManifest();
                        xml.GenerateNMConfigurationXml();
                        xml.GenerateNMPluginXml(instance.pluginAndroid);

                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (KeyValuePair<string, ScriptableObject> kit in instance.kits)
                        {
                            Plugin plugin = kit.Value as Plugin;
                            Dictionary<string, object> strings = plugin.GetStrings();
                            if (null != strings)
                            {
                                foreach (KeyValuePair<string, object> value in strings)
                                {
                                    if (!dic.ContainsKey(value.Key))
                                        dic.Add(value.Key, value.Value);
                                }
                            }
                        }
                        xml.GenerateStringsXml(dic);
                    }
                }
            }
        }

        private void DrawSeperator()
        {
            GUILayout.Box("", new GUILayoutOption[]
            {
                GUILayout.ExpandWidth(true),
                GUILayout.Height(1)
            });
        }
    }
}