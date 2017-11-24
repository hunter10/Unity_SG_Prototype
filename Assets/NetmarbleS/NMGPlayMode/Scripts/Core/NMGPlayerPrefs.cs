#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;

    public class NMGPlayerPrefs
    {
        public static string GetPlayerId()
        {
            string playerId = PlayerPrefs.GetString(NMGConstants.KEY_PLAYER_ID, null);

            if (string.IsNullOrEmpty(playerId))
                return null;

            return playerId;
        }

        public static void SetPlayerId(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_PLAYER_ID);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_PLAYER_ID, playerId);
            }
        }

        public static string GetDeviceKey()
        {
            string deviceKey = PlayerPrefs.GetString(NMGConstants.KEY_DEVICEKEY, null);

            if (string.IsNullOrEmpty(deviceKey))
                return null;

            return deviceKey;
        }

        public static void SetDeviceKey(string deviceKey)
        {
            if (string.IsNullOrEmpty(deviceKey))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_DEVICEKEY);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_DEVICEKEY, deviceKey);
            }
        }

        public static string GetRegion()
        {
            string region = PlayerPrefs.GetString(NMGConstants.KEY_REGION, null);

            if (string.IsNullOrEmpty(region))
                return null;

            return region;
        }

        public static void SetRegion(string region)
        {
            if (string.IsNullOrEmpty(region))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_REGION);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_REGION, region);
            }
        }

        public static string GetChannelKey(NMGChannel channel)
        {
            string channelKey = null;
            switch (channel)
            {
                case NMGChannel.EveryNetmarble:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_EVERYNETMARBLE, null);
                    break;
                case NMGChannel.Facebook:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_FACEBOOK, null);
                    break;
                case NMGChannel.Kakao:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_KAKAO, null);
                    break;
                case NMGChannel.Google:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_GOOGLEPLUS, null);
                    break;
                case NMGChannel.GameCenter:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_GAMECENTER, null);
                    break;
                case NMGChannel.Naver:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_NAVER, null);
                    break;
                case NMGChannel.Twitter:
                    channelKey = PlayerPrefs.GetString(NMGConstants.KEY_CHANNEL_ID_TWITTER, null);
                    break;
            }

            if (string.IsNullOrEmpty(channelKey))
                return null;

            return channelKey;
        }

        public static void SetChannelKey(NMGChannel channel, string channelKey)
        {
            switch (channel)
            {
                case NMGChannel.EveryNetmarble:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_EVERYNETMARBLE);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_EVERYNETMARBLE, channelKey);
                    }
                    break;
                case NMGChannel.Facebook:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_FACEBOOK);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_FACEBOOK, channelKey);
                    }
                    break;
                case NMGChannel.Kakao:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_KAKAO);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_KAKAO, channelKey);
                    }
                    break;
                case NMGChannel.Google:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_GOOGLEPLUS);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_GOOGLEPLUS, channelKey);
                    }
                    break;
                case NMGChannel.GameCenter:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_GAMECENTER);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_GAMECENTER, channelKey);
                    }
                    break;
                case NMGChannel.Naver:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_NAVER);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_NAVER, channelKey);
                    }
                    break;
                case NMGChannel.Twitter:
                    if (string.IsNullOrEmpty(channelKey))
                    {
                        PlayerPrefs.DeleteKey(NMGConstants.KEY_CHANNEL_ID_TWITTER);
                    }
                    else
                    {
                        PlayerPrefs.SetString(NMGConstants.KEY_CHANNEL_ID_TWITTER, channelKey);
                    }
                    break;
            }
        }

        public static string GetCountryCode()
        {
            string countryCode = PlayerPrefs.GetString(NMGConstants.KEY_COUNTRYCODE, null);

            if (string.IsNullOrEmpty(countryCode))
                return null;

            return countryCode;
        }

        public static void SetCountryCode(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_COUNTRYCODE);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_COUNTRYCODE, countryCode);
            }
        }

        public static string GetJoinedCountryCode()
        {
            string joinedCountryCode = PlayerPrefs.GetString(NMGConstants.KEY_JOINEDCOUNTRYCODE, null);

            if (string.IsNullOrEmpty(joinedCountryCode))
                return null;

            return joinedCountryCode;
        }

        public static void SetJoinedCountryCode(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_JOINEDCOUNTRYCODE);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_JOINEDCOUNTRYCODE, countryCode);
            }
        }

        public static string GetIPAddress()
        {
            string ipAddress = PlayerPrefs.GetString(NMGConstants.KEY_CLIENT_IP, null);

            if (string.IsNullOrEmpty(ipAddress))
                return null;

            return ipAddress;
        }

        public static void SetIPAddress(string clientIp)
        {
            if (string.IsNullOrEmpty(clientIp))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_CLIENT_IP);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_CLIENT_IP, clientIp);
            }
        }

        public static string GetLanguage()
        {
            string language = PlayerPrefs.GetString(NMGConstants.KEY_LANGUAGE, "none");

            if (string.IsNullOrEmpty(language))
                return null;

            return language;
        }

        public static void SetLanguage(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
            {
                PlayerPrefs.DeleteKey(NMGConstants.KEY_LANGUAGE);
            }
            else
            {
                PlayerPrefs.SetString(NMGConstants.KEY_LANGUAGE, languageCode);
            }
        }

        public static string GetTermsOfServiceViewShowed()
        {
            string key = NMGConstants.KEY_TERMS_OF_SERVICE + "_" + SessionManager.Instance.playerId;
            string isShowed = PlayerPrefs.GetString(key, null);

            if (string.IsNullOrEmpty(isShowed))
                return null;

            return isShowed;

        }
        public static void SetTermsOfServiceViewShowed(string showed)
        {
            string key = NMGConstants.KEY_TERMS_OF_SERVICE + "_" + SessionManager.Instance.playerId;
            if (string.IsNullOrEmpty(showed))
            {
                PlayerPrefs.DeleteKey(key);
            }
            else
            {
                PlayerPrefs.SetString(key, showed);
            }
        }

        public static void DeleteAll()
        {
            NMGPlayerPrefs.SetPlayerId(null);
            NMGPlayerPrefs.SetDeviceKey(null);
            NMGPlayerPrefs.SetRegion(null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.EveryNetmarble, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Facebook, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Kakao, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Google, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.GameCenter, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Naver, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Twitter, null);
            NMGPlayerPrefs.SetCountryCode(null);
            NMGPlayerPrefs.SetLanguage(null);
            NMGPlayerPrefs.SetJoinedCountryCode(null);
            NMGPlayerPrefs.SetIPAddress(null);

        }
    }
}
#endif