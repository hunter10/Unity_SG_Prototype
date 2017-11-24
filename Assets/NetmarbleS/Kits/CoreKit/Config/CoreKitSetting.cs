namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using NetmarbleS.Internal;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    public class CoreKitSetting : Plugin
    {
        // 공통
        [SerializeField]
        private string gameCode = "";
        [SerializeField]
        private string zone = "";
        [SerializeField]
        private bool useLog = false;
        [SerializeField]
        private int httpTimeOutSec = 15;
        [SerializeField]
        private bool useFixedPlayerId = false;

        // Android
        [SerializeField]
        private string market = "";
        [SerializeField]
        private string googleAppId = "";
        [SerializeField]
        private string mainActivity = "com.netmarble.unity.NMGUnityPlayerActivity";

        //private bool customPush = false;
        //public string pushServiceName = "net.netmarble.sample.GCMCustomIntentService";
        //private bool pushNotify = false;


        [SerializeField]
        private string sdkPath = "";
        [SerializeField]
        private bool useFBLoginInApp = false;
		[SerializeField]
		private string cameraDescription = "";
		[SerializeField]
		private string photoLibraryDescription = "";


        public string GameCode
        {
            get
            {
                return gameCode;
            }
            set
            {
                gameCode = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public string Zone
        {
            get
            {
                return zone;
            }
            set
            {
                zone = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public bool UseLog
        {
            get
            {
                return useLog;
            }
            set
            {
                useLog = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public int HttpTimeOutSec
        {
            get
            {
                return httpTimeOutSec;
            }
            set
            {
                httpTimeOutSec = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public bool UseFixedPlayerId
        {
            get
            {
                return useFixedPlayerId;
            }
            set
            {
                useFixedPlayerId = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public string Market
        {
            get
            {
                return market;
            }
            set
            {
                market = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public string GoogleAppId
        {
            get
            {
                return googleAppId;
            }
            set
            {
                googleAppId = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public string MainActivity
        {
            get
            {
                return mainActivity;
            }
            set
            {
                mainActivity = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public string SdkPath
        {
            get
            {
                return sdkPath;
            }
            set
            {
                sdkPath = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

        public bool UseFBLoginInApp
        {
            get
            {
                return useFBLoginInApp;
            }
            set
            {
                useFBLoginInApp = value;
#if UNITY_EDITOR
                EditorUtility.SetDirty(instance);
#endif
            }
        }

		public string CameraDescription
		{
			get
			{
				return cameraDescription;
			}
			set
			{
				cameraDescription = value;
#if UNITY_EDITOR
				EditorUtility.SetDirty(instance);
#endif
			}
		}

		public string PhotoLibraryDescription
		{
			get
			{
				return photoLibraryDescription;
			}
			set
			{
				photoLibraryDescription = value;
#if UNITY_EDITOR
				EditorUtility.SetDirty(instance);
#endif
			}
		}
        

        public override Dictionary<string, object> GetStrings()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
#if UNITY_EDITOR
            dic.Add("app_name", PlayerSettings.productName);
#endif
            dic.Add("google_app_id", googleAppId);
            return dic;
        }

        public override Dictionary<string, object> GetInfoPlists(Dictionary<string, object> dic)
        {
            List<object> urlType = (List<object>) dic ["CFBundleURLTypes"];
            Dictionary<string, object> item0 = (Dictionary<string, object>)urlType [0];
            List<object> urlSchemes = (List<object>)item0 ["CFBundleURLSchemes"];
            urlSchemes.Add("nm" + gameCode);

            Dictionary<string, bool> nsAppTransportSecurity = new Dictionary<string, bool>();
            nsAppTransportSecurity.Add("NSAllowsArbitraryLoads", true);
            dic.Add("NSAppTransportSecurity", nsAppTransportSecurity);
			dic ["NSCameraUsageDescription"] = cameraDescription;
			dic ["NSPhotoLibraryUsageDescription"] = photoLibraryDescription;

            return dic;
        }

        private static CoreKitSetting instance;
        public static CoreKitSetting getInstance()
        {
            if (instance == null)
            {
                instance = Resources.Load("CoreKit") as CoreKitSetting;
                if (instance == null)
                {
                    instance = CreateInstance<CoreKitSetting>();
#if UNITY_EDITOR
                    string properPath = Path.Combine(Application.dataPath, "NetmarbleS/NMGPlugin/Resources");
                    if (!Directory.Exists(properPath))
                    {
                        AssetDatabase.CreateFolder("Assets/NetmarbleS/NMGPlugin", "Resources");
                    }
                    AssetDatabase.CreateAsset(instance, "Assets/NetmarbleS/NMGPlugin/Resources/CoreKit.asset");
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
#endif
                }
            }
            return instance;
        }
    }
}
