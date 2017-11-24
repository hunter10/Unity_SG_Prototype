#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using LitJson;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;
    using NetmarbleS.Internal;

    public class GMC2ServiceManager
    {
        private readonly string GMC2 = "https://mobileapi.netmarble.com/v2/commonCs/getKey";
        private readonly string SERVICE_CODE = "netmarbles";
        private readonly string LOCALE = "ko_kr";

        public delegate void InitializeDelegate(Result result);

        private static GMC2ServiceManager instance;
        private Dictionary<string, string> constantDic;

        private GMC2ServiceManager()
        {
            constantDic = new Dictionary<string, string>();
        }

        public static GMC2ServiceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GMC2ServiceManager();
                }
                return instance;
            }
        }

        public int GetConstantCount()
        {
            return constantDic.Count;
        }

        public bool ContainsKey(string key)
        {
            return constantDic.ContainsKey(key);
           
        }

        public string GetConstantValue(string key)
        {
            if (ContainsKey(key))
                return constantDic[key];
            else
                return null;
        }

        public WWW Initialize(InitializeDelegate callback)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            string gmc2Url = GMC2;

            string[] versionArray = Configuration.GetUnityPluginVersion().Split('.');
            string version = versionArray[0] + "." + versionArray[1];

            WWWForm wwwForm = new WWWForm();
            wwwForm.AddField("localeCode", LOCALE);
            wwwForm.AddField("serviceCode", SERVICE_CODE);
            wwwForm.AddField("gameCode", Configuration.GetGameCode());
            wwwForm.AddField("version", version);
            wwwForm.AddField("zone", Configuration.GetZone());
            //      wwwForm.AddField("checksum", checksum);


            wwwForm.headers["Content-Type"] = "application/octet-stream";

            WWW www = new WWW(gmc2Url, wwwForm);

            CallbackManager.NetmarbleGameObject.StartCoroutine(WaitForInitialize(www, callback));
            return www;
        }

        private IEnumerator WaitForInitialize(WWW www, InitializeDelegate callback)
        {
            yield return www;

            if (www.error == null)
            {
                ProcessData(www.text, callback);
            }
            else
            {
                if (callback != null && callback is InitializeDelegate)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, www.error);
                    Log.Debug("[NMGPlayMode.GMC2Service] Initialize Fail (" + result + ")");
                    callback(result);
                }
            }
        }

        private void ProcessData(string jsonString, InitializeDelegate callback)
        {
            Debug.Log("GMC2Service : " + jsonString);
            JsonData jsonData = JsonMapper.ToObject(jsonString);

            int resCode = (int)jsonData["resCode"];
            if (resCode == 0)
            {
                string countryCode = (string)jsonData["geoLocation"];
                if (countryCode != null)
                {
                    NMGPlayerPrefs.SetCountryCode(countryCode);
                }

                string clientIp = (string)jsonData["clientIp"];
                if (clientIp != null)
                {
                    NMGPlayerPrefs.SetIPAddress(clientIp);
                }

                constantDic = new Dictionary<string, string>();
                for (int i = 0; i < jsonData["result"].Count; i++)
                {
                    string keyStr = jsonData["result"][i]["key"].ToString();
                    string valueStr = jsonData["result"][i]["value"].ToString();

                    constantDic.Add(keyStr, valueStr);
                }

                if (callback != null && callback is InitializeDelegate)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                    Log.Debug("[NMGPlayMode.GMC2Service] Initialize OK (" + result + ")");

                    InitTalkKit();

                    callback(result);
                }
            }
            else
            {
                if (callback != null && callback is InitializeDelegate)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, jsonString);
                    Log.Debug("[NMGPlayMode.GMC2Service] Initialize Fail (" + result + ")");
                    callback(result);
                }
            }
        }

        private void InitTalkKit()
        {
            if (null != Type.GetType("NetmarbleS.TalkSession"))
            {
                Type talkManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TalkManager");
                System.Reflection.PropertyInfo propertyInfo = talkManagerType.GetProperty("Instance", talkManagerType);
                object talkManager = propertyInfo.GetValue(propertyInfo, null);

                System.Reflection.MethodInfo init = talkManager.GetType().GetMethod("Init", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                init.Invoke(talkManager, null);


                Type tcpSessionManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TCPSessionManager");
                System.Reflection.PropertyInfo tcpSessionManagerPropertyInfo = tcpSessionManagerType.GetProperty("Instance", tcpSessionManagerType);
                object tcpSessionManager = tcpSessionManagerPropertyInfo.GetValue(tcpSessionManagerPropertyInfo, null);

                System.Reflection.MethodInfo onInitializedSession = tcpSessionManager.GetType().GetMethod("OnInitializedSession", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                onInitializedSession.Invoke(tcpSessionManager, null);
            }
        }
    }
}
#endif