namespace NetmarbleS.NMGPlugin
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.IO;
#if UNITY_EDITOR
    using UnityEditor;

    [InitializeOnLoad]
#endif
    public class Setting : ScriptableObject
    {
        public Dictionary<string, ScriptableObject> kits;
        public Dictionary<string, List<object>> pluginAndroid;
        public Dictionary<string, object> pluginiOS;

        [SerializeField]
        private int isUse = 0;
        public int IsUse
        {
            get
            {
                return isUse;
            }
            set
            {
                isUse = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(Instance);
#endif
            }
        }

        public void refreshKits()
        {
            kits = new Dictionary<string, ScriptableObject>();
            pluginAndroid = new Dictionary<string, List<object>>();
            pluginiOS = new Dictionary<string, object>();

            string path = Path.Combine(Application.dataPath, "NetmarbleS/Kits");
            string[] files = Directory.GetFiles(path, "*.nmplugin", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                FileInfo projectFileInfo = new FileInfo(file);
                if (projectFileInfo.Exists)
                {
                    StreamReader reader = projectFileInfo.OpenText();
                    string contents = reader.ReadToEnd();
                    IDictionary kit = LitJson.JsonMapper.ToObject(contents) as IDictionary;
                    reader.Dispose();

                    foreach (string key in kit.Keys)
                    {
                        IDictionary kitInfo = kit[key] as IDictionary;

                        if (kitInfo.Contains("Setting"))
                        {
                            string className = kitInfo["Setting"].ToString();
                            Type type = Type.GetType("NetmarbleS." + className);

                            if (null != type)
                            {
                                ScriptableObject kitInstance = type.GetMethod("getInstance").Invoke(null, null) as ScriptableObject;
                                if (!kits.ContainsKey(key))
                                    kits.Add(key, kitInstance);
                            }
                        }

                        if (kitInfo.Contains("Android"))
                        {
                            IDictionary android = kitInfo["Android"] as IDictionary;
                            foreach (string typeKey in android.Keys)
                            {
                                if (!pluginAndroid.ContainsKey(typeKey))
                                    pluginAndroid.Add(typeKey, new List<object>());

                                List<object> list = pluginAndroid[typeKey];
                                list.Add(android[typeKey]);
                            }
                        }

                        if (kitInfo.Contains("iOS"))
                        {
                            IDictionary ios = kitInfo["iOS"] as IDictionary;
                            foreach (string typeKey in ios.Keys)
                            {
                                if (typeKey.Equals("UiView"))
                                {
                                    if (!pluginiOS.ContainsKey(typeKey))
                                        pluginiOS.Add(typeKey, new Dictionary<string, object>());
                                    

                                    Dictionary<string, object> dic = (Dictionary<string, object>)pluginiOS [typeKey];
                                    IDictionary uiview = ios [typeKey] as IDictionary;
                                    foreach (string uiviewkey in uiview.Keys)
                                    {
                                        dic.Add(uiviewkey, uiview [uiviewkey].ToString());
                                    }
								} else if (typeKey.Equals("DeepLink") || typeKey.Equals("Transfer"))
                                {
                                    if (!pluginiOS.ContainsKey(typeKey))
                                    {
                                        pluginiOS.Add(typeKey, new List<object>());
                                    }
                                    List<object> list = (List<object>)pluginiOS [typeKey];

                                    Dictionary<string, object> dic = new Dictionary<string, object>();

                                    IDictionary deeplink = ios [typeKey] as IDictionary;
                                    foreach (string deeplinkkey in deeplink.Keys)
                                    {
                                        dic.Add(deeplinkkey, deeplink [deeplinkkey].ToString());
                                    }
                                    list.Add(dic);
                                }
                                else
                                {
                                    if (!pluginiOS.ContainsKey(typeKey))
                                        pluginiOS.Add(typeKey, new List<object>());
                                    

                                    List<object> list = (List<object>) pluginiOS[typeKey];
                                    list.Add(ios[typeKey].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private static Setting instance;
        public static Setting Instance
        {
            get
            {
                if (instance == null)
                {
                    //instance = Resources.Load("NMGPlugin") as Setting;
                    if (instance == null)
                    {
                        instance = CreateInstance<Setting>();
                        instance.refreshKits();
#if UNITY_EDITOR
                        //string properPath = Path.Combine(Application.dataPath, "NetmarbleS/NMGPlugin/Resources");
                        //if (!Directory.Exists(properPath))
                        //{
                        //    AssetDatabase.CreateFolder("Assets/NetmarbleS/NMGPlugin", "Resources");
                        //}
                        //AssetDatabase.CreateAsset(instance, "Assets/NetmarbleS/NMGPlugin/Resources/NMGPlugin.asset");
                        //AssetDatabase.SaveAssets();
                        //AssetDatabase.Refresh();
#endif
                    }
                }
                //if (instance.kits == null)
                //{
                   
                //}
                return instance;
            }
        }
#if UNITY_EDITOR
        [MenuItem("Netmarble/Kits")]
        public static void Edit()
        {
            Instance.refreshKits();
            Selection.activeObject = Instance;
        }
#endif
    }
}