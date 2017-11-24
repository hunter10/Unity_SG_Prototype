#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class ConfigurationiOS : IConfiguration
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_configuration_version();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_configuration_getSDKVersion();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_configuration_getGameCode();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setGameCode(string gameCode);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_configuration_getZone();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setZone(string zone);
		[DllImport("__Internal")] 
		public static extern bool nmg_configuration_getUseLog();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setUseLog(bool use);
		[DllImport("__Internal")] 
		public static extern int nmg_configuration_getHttpTimeOutSec();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setHttpTimeOutSec(int sec);
		[DllImport("__Internal")] 
		public static extern bool nmg_configuration_getUseFacebookLoginViewInApp();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setUseFacebookLoginViewInApp(bool use);
		[DllImport("__Internal")] 
		public static extern int nmg_configuration_getLanguage();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setLanguage(int language);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_configuration_getCustomLanguage();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setCustomLanguage(string customLanguage);
		[DllImport("__Internal")] 
		public static extern bool nmg_configuration_getUseFixedPlayerId();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setUseFixedPlayerId(bool use);
		[DllImport("__Internal")]
		public static extern IntPtr nmg_configuration_getGMC2Url();
		[DllImport("__Internal")]
		public static extern void nmg_configuration_setGMC2Url(string url);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_configuration_getLocalizedLevel();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setLocalizedLevel(string localizedLevel);
		[DllImport("__Internal")] 
		public static extern int nmg_configuration_getOTPLength();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setOTPLength(int otpLength);
		[DllImport("__Internal")] 
		public static extern int nmg_configuration_getOTPLifeCycle();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setOTPLifeCycle(int otpLifeCycle);
		[DllImport("__Internal")] 
		public static extern int nmg_configuration_getOTPHistoryPeriod();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setOTPHistoryPeriod(int otpHistoryPeriod);
		[DllImport("__Internal")] 
		public static extern bool nmg_configuration_getIsHiddenNoticeTitleBar();
		[DllImport("__Internal")] 
		public static extern void nmg_configuration_setIsHiddenNoticeTitleBar(bool isHidden);
		[DllImport("__Internal")] 
		public static extern bool nmg_configuration_getIsInReview();
		[DllImport("__Internal")]
		public static extern void nmg_configuration_setIsInReview(bool use);
        
        private string version;
        public ConfigurationiOS()
        {
            version = Marshal.PtrToStringAuto(nmg_configuration_version());
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
			return Marshal.PtrToStringAuto(nmg_configuration_getSDKVersion());
        }

        public string GetGameCode()
        {
            return Marshal.PtrToStringAuto(nmg_configuration_getGameCode());
        }

        public void SetGameCode(string gameCode)
        {
			nmg_configuration_setGameCode(gameCode);
        }

        public string GetZone()
        {
			return Marshal.PtrToStringAuto(nmg_configuration_getZone());
        }

        public void SetZone(string zone)
        {
			nmg_configuration_setZone(zone);
        }
			
        public string GetMarket()
        {
            Log.Debug("[ConfigurationiOS] not supported API");
            return null;
        }

        public void SetMarket(string market)
        {
            Log.Debug("[ConfigurationiOS] not supported API");
        }
			
        public bool GetUseLog()
        {
			return nmg_configuration_getUseLog();
        }

        public void SetUseLog(bool use)
        {
			nmg_configuration_setUseLog(use);
        }
			
        public bool GetUsePush()
        {
            Log.Debug("[ConfigurationiOS] not supported API");
            return true;
        }

        public void SetUsePush(bool use)
        {
            Log.Debug("[ConfigurationiOS] not supported API");
        }
			
        public int GetHttpTimeOutSec()
        {
			return nmg_configuration_getHttpTimeOutSec();
        }

        public void SetHttpTimeOutSec(int sec)
        {
			nmg_configuration_setHttpTimeOutSec(sec);
        }

        public bool GetUseFacebookLoginViewInApp()
        {
			return nmg_configuration_getUseFacebookLoginViewInApp();
        }

        public void SetUseFacebookLoginViewInApp(bool use)
        {
			nmg_configuration_setUseFacebookLoginViewInApp(use);
        }
			
        public Language GetLanguage()
        {
			return (Language)nmg_configuration_getLanguage();
        }

        public void SetLanguage(Language language)
        {
            nmg_configuration_setLanguage((int)language);
        }

        public string GetCustomLanguage()
        {
			return Marshal.PtrToStringAuto(nmg_configuration_getCustomLanguage());
        }

        public void SetCustomLanguage(string value)
        {
			nmg_configuration_setCustomLanguage(value);
        }

        public bool GetUseFixedPlayerId()
        {
			return nmg_configuration_getUseFixedPlayerId();
        }

        public void SetUseFixedPlayerId(bool use)
        {
			nmg_configuration_setUseFixedPlayerId(use);
        }

		public string GetGMC2Url()
		{
			return Marshal.PtrToStringAuto(nmg_configuration_getGMC2Url());
		}

        public void SetGMC2Url(string url)
        {
			nmg_configuration_setGMC2Url(url);
        }

		public string GetLocalizedLevel()
		{
			return Marshal.PtrToStringAuto(nmg_configuration_getLocalizedLevel());
		}

        public void SetLocalizedLevel(string localizedLevel)
        {
			nmg_configuration_setLocalizedLevel(localizedLevel);
        }

        public int GetOTPLength()
        {
			return nmg_configuration_getOTPLength();
        }

        public void SetOTPLength(int otpLength)
        {
            nmg_configuration_setOTPLength(otpLength);
        }
			
        public int GetOTPLifeCycle()
        {
			return nmg_configuration_getOTPLifeCycle();
        }

        public void SetOTPLifeCycle(int otpLifeCycle)
        {
            nmg_configuration_setOTPLifeCycle(otpLifeCycle);
        }
			
        public int GetOTPHistoryPeriod()
        {
			return nmg_configuration_getOTPHistoryPeriod();
        }

        public void SetOTPHistoryPeriod(int otpHistoryPeriod)
        {
            nmg_configuration_setOTPHistoryPeriod(otpHistoryPeriod);
        }

		public bool GetIsHiddenNoticeTitleBar()
		{
			return nmg_configuration_getIsHiddenNoticeTitleBar();
		}
			
        public void SetIsHiddenNoticeTitleBar(bool isHidden)
        {
			nmg_configuration_setIsHiddenNoticeTitleBar(isHidden);
        }

		public bool GetIsInReview()
		{
			return nmg_configuration_getIsInReview();
		}

		public void SetIsInReview(bool isInReview)
		{
			nmg_configuration_setIsInReview(isInReview);
		}
    }
}
#endif