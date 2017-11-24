#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.IO;
    using NetmarbleS;

    public class ConfigurationManager
    {
        private static CoreKitSetting instance;
        public static CoreKitSetting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GetCoreKitSetting();
                }
                return instance;
            }
        }

        private static CoreKitSetting GetCoreKitSetting()
        {
            if (null != Resources.Load("CoreKit"))
            {
                if (null != Resources.Load("NMGPlayModeCoreKit"))
                {
                    AssetDatabase.DeleteAsset("Assets/NetmarbleS/NMGPlayMode/Resources/NMGPlayModeCoreKit.asset");
                }

                return CoreKitSetting.getInstance();
            }


            if (null != Resources.Load("NMGPlayModeCoreKit"))
            {
                System.Type settingType = System.Type.GetType("NetmarbleS.NMGPlugin.Setting");
                if (null != settingType)
                {
                    AssetDatabase.DeleteAsset("Assets/NetmarbleS/NMGPlayMode/Resources/NMGPlayModeCoreKit.asset");
                    return CoreKitSetting.getInstance();
                }
                else
                {
                    CoreKitSetting playModeCoreKit = Resources.Load("NMGPlayModeCoreKit") as CoreKitSetting;
                    System.Type playmodetype = playModeCoreKit.GetType();
                    System.Reflection.FieldInfo info = playmodetype.GetField("instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                    info.SetValue(playModeCoreKit, playModeCoreKit);

                    return playModeCoreKit;
                }
            }

            CoreKitSetting setting = ScriptableObject.CreateInstance<CoreKitSetting>();
            AssetDatabase.CreateAsset(setting, "Assets/NetmarbleS/NMGPlayMode/Resources/NMGPlayModeCoreKit.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            System.Type type = setting.GetType();
            System.Reflection.FieldInfo fieldInfo = type.GetField("instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            fieldInfo.SetValue(setting, setting);

            return setting;
        }
        public static bool CheckConfiguration()
        {
            if (string.IsNullOrEmpty(Instance.Zone) || string.IsNullOrEmpty(Instance.GameCode))
            {
                Debug.Log("Check Configuration");
                return false;
            }
            return true;
        }

        [MenuItem("Netmarble/PlayMode/Configuration")]
        public static void Setting()
        {
            System.Type settingType = System.Type.GetType("NetmarbleS.NMGPlugin.Setting");
            if (null == Resources.Load("CoreKit") && null == settingType)
            {
                Selection.activeObject = Instance;
                }
            else
            {
                EditorUtility.DisplayDialog("NMGPlayMode Setting", "Use [Netmarble > Kits] CoreKit Setting.", "OK");
            
            }
        }
    }
}
#endif