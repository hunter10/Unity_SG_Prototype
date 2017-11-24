#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class NMGConstants
    {
        public static readonly string TEST_DATA_PATH = "Assets/NetmarbleS/NMGPlayMode/Editor/NMGPlayModeTestData.asset";
        

        public static readonly string SIGN_IN = "/signin";

        public static readonly string KEY_PLAYER_ID = "NetmarbleS.PlayerID";
        public static readonly string KEY_DEVICEKEY = "NetmarbleS.DeviceKey";
        public static readonly string KEY_GMC2_REGION = "NetmarbleS.GMC2.Region";
        public static readonly string KEY_REGION = "NetmarbleS.Region";
        public static readonly string KEY_COUNTRYCODE = "NetmarbleS.CountryCode";
        public static readonly string KEY_JOINEDCOUNTRYCODE = "NetmarbleS.JoinedCountryCode";
        public static readonly string KEY_CLIENT_IP = "NetmarbleS.ClientIP";
        public static readonly string KEY_LANGUAGE = "NetmarbleS.Language";
        public static readonly string KEY_CHANNEL_ID_FACEBOOK = "NetmarbleS.ChannelID.Facebook";
        public static readonly string KEY_CHANNEL_ID_GOOGLEPLUS = "NetmarbleS.ChannelID.GooglePlus";
        public static readonly string KEY_CHANNEL_ID_KAKAO = "NetmarbleS.ChannelID.Kakao";
        public static readonly string KEY_CHANNEL_ID_EVERYNETMARBLE = "NetmarbleS.ChannelID.EMA";
        public static readonly string KEY_CHANNEL_ID_GAMECENTER = "NetmarbleS.ChannelID.AppleGC";
        public static readonly string KEY_CHANNEL_ID_NAVER = "NetmarbleS.ChannelID.Naver";
        public static readonly string KEY_CHANNEL_ID_TWITTER = "NetmarbleS.ChannelID.Twitter";
        public static readonly string KEY_TERMS_OF_SERVICE = "NetmarbleS.TermsOfServiceView";
    }
}
#endif