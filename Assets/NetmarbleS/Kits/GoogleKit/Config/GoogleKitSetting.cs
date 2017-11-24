namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.IO;
    using System.Collections.Generic;
    using NetmarbleS.Internal;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    [System.Serializable]
    public class GoogleKitSetting : Plugin
    {
        public string gmsAppId = "";
        public string clientId = "";
        public string clientSecret = "";

        public override Dictionary<string, object> GetStrings()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("gms_app_id", gmsAppId);
            dic.Add("GOOGLE_CLIENT_ID", clientId);
            dic.Add("GOOGLE_CLIENT_SECRET", clientSecret);
            return dic;
        }

        private static GoogleKitSetting instance;
        public static GoogleKitSetting getInstance()
        {
            if (instance == null)
            {
                instance = Resources.Load("GoogleKit") as GoogleKitSetting;
                if (instance == null)
                {
                    instance = CreateInstance<GoogleKitSetting>();
#if UNITY_EDITOR
                    string properPath = Path.Combine(Application.dataPath, "NetmarbleS/NMGPlugin/Resources");
                    if (!Directory.Exists(properPath))
                    {
                        AssetDatabase.CreateFolder("Assets/NetmarbleS/NMGPlugin", "Resources");
                    }
                    AssetDatabase.CreateAsset(instance, "Assets/NetmarbleS/NMGPlugin/Resources/GoogleKit.asset");
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
#endif
                }

            }
            return instance;

        }
    }
}