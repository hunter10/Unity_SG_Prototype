namespace NetmarbleS.NMGPlugin
{
    using UnityEngine;
    using UnityEditor;
    using UnityEditor.Callbacks;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using NetmarbleS.Internal;
    using NetmarbleS.NMGPlugin.NMGPlistCS;
    using NetmarbleS.NMGPlugin.NMGXCodeEditor;

    public class NMPostProcess
    {

        [PostProcessBuild(7465)]
        public static void OnPostProcessBuild(BuildTarget target, string path)
        {
            if (Setting.Instance.IsUse == 0)
            {
                BuildTarget buildTargetIOS;
#if UNITY_5
                buildTargetIOS = BuildTarget.iOS;
#else
                buildTargetIOS = BuildTarget.iPhone;
#endif

                if (target == buildTargetIOS)
                {
                    string sdkPath = NetmarbleS.CoreKitSetting.getInstance().SdkPath;

                    if (sdkPath == null || sdkPath == "")
                    {
                        Debug.LogError("Check SDK Path");
                        return;
                    }

                    // 상대경로 -> 절대경로
                    if (!Path.IsPathRooted(sdkPath))
                    {
                        sdkPath = Path.GetFullPath(Path.Combine(Application.dataPath, sdkPath));
                    }

                    XCProject project = new XCProject(path);

                    string projmodsPath = Path.Combine(Application.dataPath, "NetmarbleS/Kits");
                    string[] files = System.IO.Directory.GetFiles(projmodsPath, "*.projmods", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        project.ApplyMod(sdkPath, file);
                    }
                    project.Adjust();
                    project.Save();
                    UpdateInfoPlist(path);
                    UpdateNMPluginPlist(sdkPath);
                    UpdateNMConfigurationPlist(sdkPath);
                }
            }
        }

        public static void UpdateInfoPlist(string path)
        {
            string fileName = "Info.plist";
            string pListPath = Path.Combine(path, fileName);
            Dictionary<string, object> pList = (Dictionary<string, object>)Plist.readPlist(pListPath);

            Dictionary<string, object> dic = new Dictionary<string,object>();

            List<object> urlType = new List<object>();
            Dictionary<string, object> item0 = new Dictionary<string, object>();
            List<object> urlSchemes = new List<object>();
            item0.Add("CFBundleURLSchemes", urlSchemes);
            urlType.Add(item0);
            dic.Add("CFBundleURLTypes", urlType);

            List<object> querySchemes = new List<object>();
            dic.Add("LSApplicationQueriesSchemes", querySchemes);

            foreach (string kitKey in Setting.Instance.kits.Keys)
            {
                Plugin plugin = Setting.Instance.kits [kitKey] as Plugin;
                dic = plugin.GetInfoPlists(dic);
            }

            foreach (string key in dic.Keys)
            {
                if (key.Equals("CFBundleURLTypes"))
                {
                    List<object> cfBundleURLTypes;
                    Dictionary<string, object> item;
                    List<object> cfBundleURLSchemes;

                    bool existItem = false;
                    bool existUrlScheme = false;

                    if (pList.ContainsKey("CFBundleURLTypes"))
                    {
                        cfBundleURLTypes = (List<object>)pList["CFBundleURLTypes"];
                    }
                    else
                    {
                        cfBundleURLTypes = new List<object>();
                        pList.Add("CFBundleURLTypes", cfBundleURLTypes); 
                    }

                    List<object> urlTypeList = (List<object>)dic["CFBundleURLTypes"];
                    
                    foreach (Dictionary<string, object> dicItem in urlTypeList)
                    {
                        item = new Dictionary<string, object>();
                        
                        foreach (Dictionary<string, object> plistitem in cfBundleURLTypes)
                        {
                            existItem = false;

                            if (dicItem.ContainsKey("CFBundleURLName") && plistitem.ContainsKey("CFBundleURLName"))
                            {
                                if (dicItem.GetString("CFBundleURLName").Equals(plistitem.GetString("CFBundleURLName")))
                                {
                                    item = plistitem;
                                    existItem = true;
                                    break;
                                }
                                else
                                {
                                    //
                                }
                            }
                            else if (!dicItem.ContainsKey("CFBundleURLName") && !plistitem.ContainsKey("CFBundleURLName"))
                            {
                                item = plistitem;
                                existItem = true;
                                break;
                            }
                            else
                            {
                                //
                            }
                        }

                        if (dicItem.ContainsKey("CFBundleURLName") && !item.ContainsKey("CFBundleURLName"))
                        {
                            item.Add("CFBundleURLName", dicItem.GetString("CFBundleURLName"));
                        }

                        if (dicItem.ContainsKey("CFBundleTypeRole") && !item.ContainsKey("CFBundleTypeRole"))
                        {
                            item.Add("CFBundleTypeRole", dicItem.GetString("CFBundleTypeRole"));
                        }

                        if (dicItem.ContainsKey("CFBundleURLSchemes"))
                        {
                            if (item.ContainsKey("CFBundleURLSchemes"))
                            {
                                cfBundleURLSchemes = (List<object>)item["CFBundleURLSchemes"];
                                existUrlScheme = true;
                            }
                            else
                            {
                                cfBundleURLSchemes = new List<object>();
                                existUrlScheme = false;
                            }

                            List<object> urlSchamesList = (List<object>)dicItem["CFBundleURLSchemes"];

                            foreach (string obj in urlSchamesList)
                            {
                                if (!cfBundleURLSchemes.Contains(obj))
                                    cfBundleURLSchemes.Add(obj);
                            }

                            if (!existUrlScheme)
                                item.Add("CFBundleURLSchemes", cfBundleURLSchemes);

                        }

                        if (!existItem)
                            cfBundleURLTypes.Add(item); 
                    } 

                } else if (key.Equals("LSApplicationQueriesSchemes"))
                {
                    List<object> lsApplicationQueriesSchemes;
                    if (pList.ContainsKey(key))
                    {
                        lsApplicationQueriesSchemes = (List<object>)pList [key];

                    } else
                    {
                        lsApplicationQueriesSchemes = new List<object>();
                        pList.Add(key, lsApplicationQueriesSchemes);
                    }
                    List<object> list = (List<object>)dic [key];
                    foreach (string obj in list)
                    {
                        if (!lsApplicationQueriesSchemes.Contains(obj))
                            lsApplicationQueriesSchemes.Add(obj);
                    }
                } else
                {
                    pList [key] = dic [key];
                }
            }

            Plist.writeXml(pList, pListPath);
        }

        public static void UpdateNMPluginPlist(string path)
        {
            string fileName = "NMGSDKCoreKit.framework/Resources/NMPlugin.plist";
            string pListPath = Path.Combine(path, fileName);
            Dictionary<string, object> pList = (Dictionary<string, object>)Plist.readPlist(pListPath);
            pList.Clear();

            Dictionary<string, object> plugins = Setting.Instance.pluginiOS;

            foreach (string key in plugins.Keys)
            {
                object obj = plugins [key] as object;
                pList.Add(key, obj);
            }

            Plist.writeXml(pList, pListPath);
        }

        public static void UpdateNMConfigurationPlist(string path)
        {
            string fileName = "NMGSDKCoreKit.framework/Resources/NMConfiguration.plist";
            string pListPath = Path.Combine(path, fileName);
            Dictionary<string, object> pList = (Dictionary<string, object>)Plist.readPlist(pListPath);

            pList ["zone"] = CoreKitSetting.getInstance().Zone;
            pList ["gameCode"] = CoreKitSetting.getInstance().GameCode;
            pList ["useLog"] = CoreKitSetting.getInstance().UseLog;
            pList ["httpTimeOutSec"] = CoreKitSetting.getInstance().HttpTimeOutSec;
            pList ["useFacebookLoginViewInApp"] = CoreKitSetting.getInstance().UseFBLoginInApp;
            pList ["useFixedPlayerID"] = CoreKitSetting.getInstance().UseFixedPlayerId;
//            pList ["OTPLength"] = NMConfigSetting.Instance.OtpLength;
//            pList ["OTPLifeCycle"] = NMConfigSetting.Instance.OtpLifeCycle;
//            pList ["OTPHistoryPeriod"] = NMConfigSetting.Instance.OtpHistoryPeriod;

            Plist.writeXml(pList, pListPath);
        }
    }
}