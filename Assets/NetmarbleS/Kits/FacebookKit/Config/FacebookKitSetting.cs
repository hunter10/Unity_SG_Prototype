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
    public class FacebookKitSetting : Plugin
    {
        public string appId = "";

        public override Dictionary<string, object> GetStrings()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("app_id", appId);
            return dic;
        }

        public override Dictionary<string, object> GetInfoPlists(Dictionary<string, object> dic)
        {
            List<object> urlType = (List<object>) dic ["CFBundleURLTypes"];
            Dictionary<string, object> item0 = (Dictionary<string, object>)urlType [0];
            List<object> urlSchemes = (List<object>)item0 ["CFBundleURLSchemes"];

            if (dic.ContainsKey("FacebookAppID"))
            {
                if (urlSchemes.Contains("fb" + (string)dic ["FacebookAppID"]))
                {
                    urlSchemes.Remove("fb" + (string)dic ["FacebookAppID"]);
                }
            }
            urlSchemes.Add("fb" + appId);

            List<object> querySchemes = (List<object>) dic ["LSApplicationQueriesSchemes"];
            if (!querySchemes.Contains("fbapi"))
                querySchemes.Add("fbapi");
            if (!querySchemes.Contains("fb"))
                querySchemes.Add("fb");
            if (!querySchemes.Contains("fbapi20130214"))
                querySchemes.Add("fbapi20130214");
            if (!querySchemes.Contains("fbapi20130410"))
                querySchemes.Add("fbapi20130410");
            if (!querySchemes.Contains("fbapi20130702"))
                querySchemes.Add("fbapi20130702");
            if (!querySchemes.Contains("fbapi20131010"))
                querySchemes.Add("fbapi20131010");
            if (!querySchemes.Contains("fbapi20131219"))
                querySchemes.Add("fbapi20131219");
            if (!querySchemes.Contains("fbapi20140410"))
                querySchemes.Add("fbapi20140410");
            if (!querySchemes.Contains("fbapi20140116"))
                querySchemes.Add("fbapi20140116");
            if (!querySchemes.Contains("fbapi20150313"))
                querySchemes.Add("fbapi20150313");
            if (!querySchemes.Contains("fbapi20150629"))
                querySchemes.Add("fbapi20150629");
            if (!querySchemes.Contains("fbauth"))
                querySchemes.Add("fbauth");
            if (!querySchemes.Contains("fbauth2"))
                querySchemes.Add("fbauth2");
            if (!querySchemes.Contains("fb-messenger-api20140430"))
                querySchemes.Add("fb-messenger-api20140430");  

            dic["FacebookAppID"] = appId;

            return dic;
        }

        private static FacebookKitSetting instance;
        public static FacebookKitSetting getInstance()
        {
            if (instance == null)
            {
                instance = Resources.Load("FacebookKit") as FacebookKitSetting;
                if (instance == null)
                {
                    instance = CreateInstance<FacebookKitSetting>();
#if UNITY_EDITOR
                    string properPath = Path.Combine(Application.dataPath, "NetmarbleS/NMGPlugin/Resources");
                    if (!Directory.Exists(properPath))
                    {
                        AssetDatabase.CreateFolder("Assets/NetmarbleS/NMGPlugin", "Resources");
                    }
                    AssetDatabase.CreateAsset(instance, "Assets/NetmarbleS/NMGPlugin/Resources/FacebookKit.asset");
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
#endif
                }

            }
            return instance;

        }
    }
}
