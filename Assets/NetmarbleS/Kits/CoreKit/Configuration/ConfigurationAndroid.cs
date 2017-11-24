#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class ConfigurationAndroid : IConfiguration
    {
        private AndroidJavaClass configurationAndroidClass;
        private string version;

        public ConfigurationAndroid()
        {
            configurationAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGConfigurationUnity");
            version = configurationAndroidClass.GetStatic<string>("VERSION");
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public string GetSDKVersion()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getSDKVersion");
        }

        public string GetGameCode()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getGameCode");
        }

        public void SetGameCode(string gameCode)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setGameCode", gameCode);
        }

        public string GetZone()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getZone");
        }

        public void SetZone(string zone)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setZone", zone);
        }

        public string GetMarket()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getMarket");
        }

        public void SetMarket(string market)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setMarket", market);
        }

        public bool GetUseLog()
        {
            return configurationAndroidClass.CallStatic<bool>("nmg_configuration_getUseLog");
        }

        public void SetUseLog(bool use)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setUseLog", use);
        }

        public bool GetUsePush()
        {
            return configurationAndroidClass.CallStatic<bool>("nmg_configuration_getUsePush");
        }

        public void SetUsePush(bool use)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setUsePush", use);
        }

        public int GetHttpTimeOutSec()
        {
            return configurationAndroidClass.CallStatic<int>("nmg_configuration_getHttpTimeOutSec");
        }

        public void SetHttpTimeOutSec(int sec)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setHttpTimeOutSec", sec);
        }
        public bool GetUseFacebookLoginViewInApp()
        {
            Log.Debug("[ConfigurationAndroid] not supported API");
            return true;
        }

        public void SetUseFacebookLoginViewInApp(bool use)
        {
            Log.Debug("[ConfigurationAndroid] not supported API");
        }

        public Language GetLanguage()
        {
            return (Language)configurationAndroidClass.CallStatic<int>("nmg_configuration_getLanguage");
        }

        public void SetLanguage(Language language)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setLanguage", (int)language);
        }

        public string GetCustomLanguage()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getCustomLanguage");
        }

        public void SetCustomLanguage(string customLanguage)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setCustomLanguage", customLanguage);
        }

        public bool GetUseFixedPlayerId()
        {
            return configurationAndroidClass.CallStatic<bool>("nmg_configuration_getUseFixedPlayerId");
        }

        public void SetUseFixedPlayerId(bool use)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setUseFixedPlayerId", use);
        }
        public string GetGMC2Url()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getGMC2Url");
        }

        public void SetGMC2Url(string url)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setGMC2Url", url);
        }

        public string GetLocalizedLevel()
        {
            return configurationAndroidClass.CallStatic<string>("nmg_configuration_getLocalizedLevel");
        }

        public void SetLocalizedLevel(string localizedLevel)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setLocalizedLevel", localizedLevel);
        }

        public int GetOTPLength()
        {
            return configurationAndroidClass.CallStatic<int>("nmg_configuration_getOTPLength");
        }

        public void SetOTPLength(int otpLength)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setOTPLength", otpLength);
        }

        public int GetOTPLifeCycle()
        {
            return configurationAndroidClass.CallStatic<int>("nmg_configuration_getOTPLifeCycle");
        }

        public void SetOTPLifeCycle(int otpLifeCycle)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setOTPLifeCycle", otpLifeCycle);
        }

        public int GetOTPHistoryPeriod()
        {
            return configurationAndroidClass.CallStatic<int>("nmg_configuration_getOTPHistoryPeriod");
        }

        public void SetOTPHistoryPeriod(int otpHistoryPeriod)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setOTPHistoryPeriod", otpHistoryPeriod);
        }
        public bool GetUseChannelConnectionModified()
        {
            return configurationAndroidClass.CallStatic<bool>("nmg_configuration_getUseChannelConnectionModified");
        }

        public bool GetIsHiddenNoticeTitleBar()
        {
            return configurationAndroidClass.CallStatic<bool>("nmg_configuration_getIsHiddenNoticeTitleBar");
        }

        public void SetIsHiddenNoticeTitleBar(bool isHidden)
        {
            configurationAndroidClass.CallStatic("nmg_configuration_setIsHiddenNoticeTitleBar", isHidden);
        }

        public bool GetIsInReview()
        {
            Log.Debug("[ConfigurationAndroid] not supported API");
            return false;
        }

        public void SetIsInReview(bool isInReview)
        {
            Log.Debug("[ConfigurationAndroid] not supported API");
        }
    }
}
#endif