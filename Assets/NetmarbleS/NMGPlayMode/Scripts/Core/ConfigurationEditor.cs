#if UNITY_EDITOR
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.NMGPlayMode;

    public class ConfigurationEditor : IConfiguration
    {
        public string VERSION
        {
            get
            {
                return "1.1.0";
            }
        }

        public string GetSDKVersion()
        {
            return Configuration.GetUnityPluginVersion();
        }

        public string GetGameCode()
        {
            return ConfigurationManager.Instance.GameCode;
        }

        public void SetGameCode(string gameCode)
        {
            ConfigurationManager.Instance.GameCode = gameCode;
        }

        public string GetZone()
        {
            return ConfigurationManager.Instance.Zone;
        }

        public void SetZone(string zone)
        {
            ConfigurationManager.Instance.Zone = zone;
        }

        public string GetMarket()
        {
            return ConfigurationManager.Instance.Market;
        }

        public void SetMarket(string market)
        {
            ConfigurationManager.Instance.Market = market;
        }

        public bool GetUseLog()
        {
            return ConfigurationManager.Instance.UseLog;
        }

        public void SetUseLog(bool use)
        {
            ConfigurationManager.Instance.UseLog = use;
        }

        public bool GetUsePush()
        {
            return true;
        }

        public void SetUsePush(bool use)
        {
        }

        public int GetHttpTimeOutSec()
        {
            return ConfigurationManager.Instance.HttpTimeOutSec;
        }

        public void SetHttpTimeOutSec(int sec)
        {
            ConfigurationManager.Instance.HttpTimeOutSec = sec;
        }

        public bool GetUseFacebookLoginViewInApp()
        {
            return false;
        }

        public void SetUseFacebookLoginViewInApp(bool use)
        {
        }

        public Language GetLanguage()
        {
            return Language.None;
        }

        public void SetLanguage(Language language)
        {
        }

        public string GetCustomLanguage()
        {
            return null;
        }

        public void SetCustomLanguage(string value)
        {
        }

        public bool GetUseFixedPlayerId()
        {
            return ConfigurationManager.Instance.UseFixedPlayerId;
        }

        public void SetUseFixedPlayerId(bool use)
        {
            ConfigurationManager.Instance.UseFixedPlayerId = use;
        }

        public void SetGMC2Url(string url)
        {
        }

        public string GetGMC2Url()
        {
            return null;
        }

        public void SetLocalizedLevel(string localizedLevel)
        {
        }

        public string GetLocalizedLevel()
        {
            return null;
        }

        public int GetOTPLength()
        {
            return 0;
        }

        public void SetOTPLength(int otpLength)
        {
        }

        public int GetOTPLifeCycle()
        {
            return 0;
        }

        public void SetOTPLifeCycle(int otpLifeCycle)
        {

        }

        public int GetOTPHistoryPeriod()
        {
            return 0;
        }

        public void SetOTPHistoryPeriod(int otpHistoryPeriod)
        {

        }

        public bool GetIsHiddenNoticeTitleBar()
        {
            return false;
        }

        public void SetIsHiddenNoticeTitleBar(bool isHidden)
        {

        }

        public bool GetIsInReview()
        {
            return false;
        }

        public void SetIsInReview(bool isInReview)
        {

        }
    }
}
#endif