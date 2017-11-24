namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.Internal;
    public enum Language
    {
        /**
         * None.
         */
        None = 0,
        /**
         * Korean.
         */
        Korean,
        /**
         * Japanese.
         */
        Japanese,
        /**
         * English.
         */
        English,
        /**
         * Thai.
         */
        Thai,
        /**
         * Simplified Chinese.
         */
        SimplifiedChinese,
        /**
         * Traditional Chinese.
         */
        TraditionalChinese,
        /**
        * Turkish.
        */
        Turkish,
        /**
        * Arabic.
        */
        Arabic,
        /**
         * FRENCH : "fr-fr"
         */
        French,
        /**
         * ITALIAN : "it-it"
         */
        Italian,
        /**
         * GERMAN : "de-de"
         */
        German,
        /**
         * SPANISH : "es-es"
         */
        Spanish,
        /**
         * PORTUGUESE : "pt-pt"
         */
        Portuguese,
        /**
         * INDONESIAN : "in-id"
         */
        Indonesian,
        /**
         * RUSSIAN : "ru-ru"
         */
        Russian
    }
    public class Configuration
    {
        /**
         * @brief Gets NetmarbleS Unity Plugin version.
         * @return NetmarbleS Unity Plugin version.
         */
        public static string GetUnityPluginVersion()
        {
            return VERSION;
        }

        public static string GetNativePluginVersion()
        {
            return ConfigurationImpl.VERSION;
        }

        /**
         * @brief Gets NetmarbleS SDK version.
         * @return NetmarbleS SDK version.
         */
        public static string GetSDKVersion()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetSDKVersion();
        }

        /**
         * @brief Gets the game code.
         * @return Game code.
         */
        public static string GetGameCode()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetGameCode();
        }

        /**
         * @brief Sets the game code.
         * @param gameCode Game code.
         */
        public static void SetGameCode(string gameCode)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetGameCode(gameCode);
        }

        /**
         * @brief Gets the zone.
         * @return Zone. ex)alpha, dev, real
         */
        public static string GetZone()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetZone();
        }

        /**
         * @brief Sets the zone.
         * @param zone Zone. ex)alpha, dev, real
         */
        public static void SetZone(string zone)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetZone(zone);
        }

        /**
         * @brief Gets the market.
         * @return Market.
         */
        public static string GetMarket()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetMarket();
        }

        /**
         * @brief Sets the market.
         * @param market Market.
         */
        public static void SetMarket(string market)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetMarket(market);
        }

        /**
         * @brief Gets the status of log setting.
         * @return Use of log.
         */
        public static bool GetUseLog()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return false;

            return ConfigurationImpl.GetUseLog();
        }

        /**
         * @brief Sets the use of log.
         * @param use Use.
         */
        public static void SetUseLog(bool use)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetUseLog(use);
        }

        /**
         * @brief Gets the timeout interval for HTTP requests.
         * @return Timeout interval second. (unit: second).
         */
        public static int GetHttpTimeOutSec()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return 0;

            return ConfigurationImpl.GetHttpTimeOutSec();
        }

        /**
         * @brief Sets the timeout interval for HTTP requests.
         * @param sec Timeout interval second. (unit: second).
         */
        public static void SetHttpTimeOutSec(int sec)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetHttpTimeOutSec(sec);
        }

        /**
         * @brief Gets whether use Facebook login inapp webView.
         * @return Use of Facebook login inapp webView.
         */
        public static bool GetUseFacebookLoginViewInApp()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return false;

            return ConfigurationImpl.GetUseFacebookLoginViewInApp();
        }

        /**
         * @brief Sets whether use Facebook login inapp webView.
         * @param use Use of Facebook login inapp webView.
         */
        public static void SetUseFacebookLoginViewInApp(bool use)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetUseFacebookLoginViewInApp(use);
        }

        /**
         * @brief Gets the SDK language.
         * if return value is null, SDK use the langauge set in device.
         * @return SDK language.
         * @see Language
         */
        public static Language GetLanguage()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return (Language)0;

            return (Language)(ConfigurationImpl.GetLanguage());
        }

        /**
         * @brief Sets the SDK langauage.
         * if sets null, SDK use the langauage set in device.
         * 
         * @param language SDK language.
         * @see Language
         */
        public static void SetLanguage(Language language)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetLanguage(language);
        }

        /**
         * @brief Gets the custom language.
         * @return Saved custom language.
         */
        public static string GetCustomLanguage()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetCustomLanguage();
        }

        /**
         * @brief Sets the custom langauage.
         * @param customLanguage custom language.
         */
        public static void SetCustomLanguage(string customLanguage)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetCustomLanguage(customLanguage);
        }

        /**
         * @brief Gets whether use netmarble push.
         * @return Use of netmarble push.
         */
        public static bool GetUsePush()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return false;

            return ConfigurationImpl.GetUsePush();
        }

        /**
         * @brief Sets whether use netmarble push.
         * @param use Use of netmarble push.
         */
        public static void SetUsePush(bool use)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetUsePush(use);
        }

        /**
         * @brief Gets whether use fixed playerID.
         * @return Use of Fixed PlayerID.
         */
        public static bool GetUseFixedPlayerID()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return false;

            return ConfigurationImpl.GetUseFixedPlayerId();
        }

        /**
         * @brief Sets whether use fixed playerID.
         * @param use Use of fixed playerID.
         */
        public static void SetUseFixedPlayerID(bool use)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetUseFixedPlayerId(use);
        }

        /**
         * @brief Gets the OTP length.
         * @return OTPLength.
         */
        public static int GetOTPLength()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return 0;

            return ConfigurationImpl.GetOTPLength();
        }

        /**
         * @brief Sets the OTP length.
         * @param OTPLength The length of OTP.
         */
        public static void SetOTPLength(int otpLength)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetOTPLength(otpLength);
        }

        /**
         * @brief Gets the OTP life cycle.
         * @return OTPLifeCycle.
         */
        public static int GetOTPLifeCycle()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return 0;

            return ConfigurationImpl.GetOTPLifeCycle();

        }

        /**
         * @brief Sets the OTP life cycle.
         * @param OTPLifeCycle The life cycle of OTP.
         */
        public static void SetOTPLifeCycle(int otpLifeCycle)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetOTPLifeCycle(otpLifeCycle);
        }

        /**
         * @brief Gets the OTP history period.
         * @return OTPHistoryPeriod.
         */
        public static int GetOTPHistoryPeriod()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return 0;

            return ConfigurationImpl.GetOTPHistoryPeriod();
        }

        /**
         * @brief Sets the OTP history period.
         * @param OTPHistoryPeriod The history period of OTP.
         */
        public static void SetOTPHistoryPeriod(int otpHistoryPeriod)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetOTPHistoryPeriod(otpHistoryPeriod);
        }

        /**
         * @brief 공지사항 TitleBar 숨김 여부 조회.
         */
        public static bool GetIsHiddenNoticeTitleBar()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return false;

            return ConfigurationImpl.GetIsHiddenNoticeTitleBar();
        }
        /**
         * @brief 공지사항의 TitleBar를 숨김.
         * @param isHidden 디폴트 NO, Rolling형 YES.
         */
        public static void SetIsHiddenNoticeTitleBar(bool isHidden)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetIsHiddenNoticeTitleBar(isHidden);
        }
        /**
         * @brief 다국어 지원 처리 단계 설정값 조회
         */
        public static string GetLocalizedLevel()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetLocalizedLevel();
        }

        /**
         * @brief 다국어 지원 처리 단계 설정
         * @param localizedLevel 디폴트 value는 1 (번역만 지원 : 1, 번역 and UI 지원 : 2)
         */
        public static void SetLocalizedLevel(string localizedLevel)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetLocalizedLevel(localizedLevel);
        }

        public static bool GetIsInReview()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return false;

            return ConfigurationImpl.GetIsInReview();

        }

        public static void SetIsInReview(bool isInReview)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetIsInReview(isInReview);
        }

        public static string GetGMC2Url()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return ConfigurationImpl.GetGMC2Url();
        }

        public static void SetGMC2Url(string url)
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return;

            ConfigurationImpl.SetGMC2Url(url);
        }

        private static readonly string VERSION = "4.1.1.2";
        private static IConfiguration configuration;
        private static IConfiguration ConfigurationImpl
        {
            get
            {
                if (null == configuration)
                {
                    configuration = ClassLoader.GetTargetClass("Configuration") as IConfiguration;
                }
                return configuration;
            }
        }
    }
}