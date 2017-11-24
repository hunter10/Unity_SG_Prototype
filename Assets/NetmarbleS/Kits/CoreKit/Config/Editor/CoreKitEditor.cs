namespace NetmarbleS
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.IO;

    [CustomEditor(typeof(CoreKitSetting))]
    public class CoreKitEditor : Editor
    {
        private CoreKitSetting instance;
        private string[] zoneOptions = { "", "dev", "real" };
        bool showAndroidConfig;
        bool showiOSCongifig;

        void OnEnable()
        {
            showAndroidConfig = (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android);
#if UNITY_5
            showiOSCongifig = (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS);
#else
		   showiOSCongifig = (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iPhone);
#endif
        }

        public override void OnInspectorGUI()
        {
            instance = target as CoreKitSetting;

            instance.GameCode = EditorGUILayout.TextField("GameCode", instance.GameCode);
            int zone = 0;
            for (int i = 0; i < zoneOptions.Length; i++)
            {
                if (zoneOptions[i] == instance.Zone)
                {
                    zone = i;
                    break;
                }
            }
            zone = EditorGUILayout.Popup("Zone", zone, zoneOptions);
            instance.Zone = zoneOptions[zone];
            instance.UseLog = EditorGUILayout.Toggle("UseLog", instance.UseLog);
            instance.HttpTimeOutSec = EditorGUILayout.IntField("HttpTimeOutSec", instance.HttpTimeOutSec);
            instance.UseFixedPlayerId = EditorGUILayout.Toggle("UseFixedPlayerId", instance.UseFixedPlayerId);

            showAndroidConfig = EditorGUILayout.Foldout(showAndroidConfig, "Android");
            if (showAndroidConfig)
            {
                instance.Market = EditorGUILayout.TextField("Market", instance.Market);
                instance.GoogleAppId = EditorGUILayout.TextField("GoogleAppId", instance.GoogleAppId);
                instance.MainActivity = EditorGUILayout.TextField("Activity", instance.MainActivity);
                //instance.customPush = EditorGUILayout.Toggle("Use Custom Push", instance.customPush);
                //if (instance.customPush)
                //{
                //    instance.pushServiceName = EditorGUILayout.TextField("GCMCustomIntentService", instance.pushServiceName);
                //    instance.pushNotify = EditorGUILayout.Toggle("Notify", instance.pushNotify);
                //}
                EditorGUILayout.LabelField("Package", PlayerSettings.bundleIdentifier);
            }

            showiOSCongifig = EditorGUILayout.Foldout(showiOSCongifig, "iOS Configuration");
            if (showiOSCongifig)
            {
                EditorGUILayout.BeginHorizontal();
                instance.SdkPath = EditorGUILayout.TextField("iOS SDK Path", instance.SdkPath);
                if (GUILayout.Button("Search", EditorStyles.miniButton, GUILayout.Width(50)))
                {
                    var selectedPath = EditorUtility.SaveFolderPanel("SDK destination", instance.SdkPath, "");
                    if (!string.IsNullOrEmpty(selectedPath))
                        instance.SdkPath = Path.GetFullPath(selectedPath);
                }
                EditorGUILayout.EndHorizontal();
                instance.UseFBLoginInApp = EditorGUILayout.Toggle("UseFacebookLoginViewInApp", instance.UseFBLoginInApp);
				instance.CameraDescription = EditorGUILayout.TextField("Privacy - Camera Usage Description", instance.CameraDescription);
				instance.PhotoLibraryDescription = EditorGUILayout.TextField("Privacy - Photo Library Usage Description", instance.PhotoLibraryDescription);
            }
        }
    }
}
