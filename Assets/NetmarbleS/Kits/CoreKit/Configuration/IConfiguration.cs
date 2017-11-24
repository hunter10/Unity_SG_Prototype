namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IConfiguration
    {
        string VERSION { get; }
        string GetSDKVersion();
        string GetGameCode();
        void SetGameCode(string gameCode);
        string GetZone();
        void SetZone(string zone);
        string GetMarket();
        void SetMarket(string market);
        bool GetUseLog();
        void SetUseLog(bool use);
        bool GetUsePush();
        void SetUsePush(bool use);
        int GetHttpTimeOutSec();
        void SetHttpTimeOutSec(int sec);
        bool GetUseFacebookLoginViewInApp();
        void SetUseFacebookLoginViewInApp(bool use);
        Language GetLanguage();
        void SetLanguage(Language language);
        string GetCustomLanguage();
        void SetCustomLanguage(string value);
        bool GetUseFixedPlayerId();
        void SetUseFixedPlayerId(bool use);
        void SetGMC2Url(string url);
        string GetGMC2Url();
        void SetLocalizedLevel(string localizedLevel);
        string GetLocalizedLevel();
        int GetOTPLength();
        void SetOTPLength(int otpLength);
        int GetOTPLifeCycle();
        void SetOTPLifeCycle(int otpLifeCycle);
        int GetOTPHistoryPeriod();
        void SetOTPHistoryPeriod(int otpHistoryPeriod);
        bool GetIsHiddenNoticeTitleBar();
        void SetIsHiddenNoticeTitleBar(bool isHidden);
        bool GetIsInReview();
        void SetIsInReview(bool isInReview);
    }
}