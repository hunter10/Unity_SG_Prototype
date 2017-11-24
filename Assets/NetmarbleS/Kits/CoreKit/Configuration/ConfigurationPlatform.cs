namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class ConfigurationPlatform : IConfiguration
    {
        public string VERSION
        {
            get { return "0.0.0"; }
        }

        public string GetSDKVersion()
        {
            return null;
        }

        public string GetGameCode()
        {
            return null;
        }

        public void SetGameCode(string gameCode)
        {
            
        }

        public string GetZone()
        {
            return null;
        }

        public void SetZone(string zone)
        {
            
        }

        public string GetMarket()
        {
            return null;
        }

        public void SetMarket(string market)
        {
            
        }

        public bool GetUseLog()
        {
            return true;
        }

        public void SetUseLog(bool use)
        {
            
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
            return 0;
        }

        public void SetHttpTimeOutSec(int sec)
        {
            
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
            return false;
        }

        public void SetUseFixedPlayerId(bool use)
        {
            
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