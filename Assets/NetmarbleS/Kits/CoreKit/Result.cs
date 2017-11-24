namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class Result {

	    public const string NETMARBLES_DOMAIN = "NETMARBLES_DOMAIN";     /**< NetmarbleS Domain. */

        public const string KAKAO_DOMAIN = "KAKAO_DOMAIN";
        public const string GOOGLEPLUS_DOMAIN = "GOOGLEPLUS_DOMAIN";
        public const string FACEBOOK_DOMAIN = "FACEBOOK_DOMAIN";
        public const string NAVER_DOMAIN = "NAVER_DOMAIN";
        public const string MSDK_DOMAIN = "MSDK_DOMAIN";

        public const int SUCCESS = 0;                                    /**< Success. */

        public const int UNKNOWN = 0x00010001;                           /**< Unknown error. */
        public const int SERVICE = 0x00010002;                           /**< Service error. */
        public const int NETWORK_UNAVAILABLE = 0x00010003;               /**< Network unavailable. */
        public const int TIMEOUT = 0x00010004;                           /**< Time Out. */

        public const int USER_CANCELED = 0x00020001;                     /**< Canceled by the user. */
        public const int INVALID_TOKEN = 0x00020002;                     /**< Invalid token. */

        public const int NOT_AUTHENTICATED = 0x00030001;                 /**< Not authenticated. */
        public const int INVALID_PARAM = 0x00030002;                     /**< Invalid parameter. */
        public const int NOT_SUPPORTED = 0x00030003;                     /**< Not supported. */
        public const int PERMISSION = 0x00030004;                        /**< No permission. */
        public const int JSON_PARSING_FAIL = 0x00030005;                 /**< Json parsing failed. */
        public const int IN_PROGRESS = 0x00030006;

        public const int CONNECT_CHANNEL_OPTION_CHANNEL_CONNECTION_MODIFIED = 0x00050001;   /**< Channel ID is modified from another device.*/
        public const int CONNECT_CHANNEL_OPTION_USED_CHANNELID = 0x00050002;                /**< Used channel ID.*/
        public const int CONNECT_CHANNEL_OPTION_NEW_CHANNELID = 0x00050003;                 /**< New channel ID.*/

        public const int OTP_IS_NOT_VALID = 0x00060001;                  /**OTP를 잘못 입력*/
        public const int OTP_WAS_EXPIRED = 0x00060002;                   /**OTP가 만료*/
        public const int OTP_INPUT_RESTRICT = 0x00060003;                /**OTP를 5회이상 잘못 입력하여, 입력이 제한*/
        
        public const int PLAYERID_MOVED = -101104;
        public const int DETAIL_PLAYERID_MOVED = -101104;

        public const int DETAIL_USED_CHANNELID = -102101;
        public const int DETAIL_NEW_CHANNELID = -102102;

        public const int DETAIL_OTP_WAS_EXPIREXD = -105100;
        public const int DETAIL_OTP_INPUT_RESTRICTED = -105101;
        public const int DETAIL_OTP_INVALID = -105102;

        private string domain;
        private int code;
        private int detailCode;
        private string message;

        public Result()
        {

        }
        public Result(string domain, int code, string message)
        {
            this.domain = domain;
            this.code = code;
            if (code == SUCCESS)
            {
                this.detailCode = 0;
            }
            else
            {
                this.detailCode = -1;
            }
            this.message = message;
        }

        public Result(string domain, int code, int detailCode, string message)
        {
            this.domain = domain;
            this.code = code;
            this.detailCode = detailCode;
            this.message = message;
        }

        public override string ToString()
        {
            return "[Result] Domain(" + domain + "), Code(0x" + code.ToString("X8") + "),, DetailCode(" + detailCode + ") Message(" + message + ")";
        }

        /**
         * @brief Gets a domain of the result.
         * 
         * @return Domain of the result.
         */
        public string Domain
        {
            get
            {
                return domain;
            }
        }

        /**
         * @brief Gets a code of the result.
         * 
         * @return Code of the result.
         */
        public int Code
        {
            get
            {
                return code;
            }
        }

        public int DetailCode
        {
            get
            {
                return detailCode;
            }
        }

        /**
         * @brief Gets a message of the result.
         * 
         * @return Message of the result.
         */
        public string Message
        {
            get
            {
                return message;
            }
        }

        /**
         * @brief Indicates whether the result is successful.
         * 
         * @return Returns true if the result is successful, otherwise it returns false.
         */
        public bool IsSuccess()
        {
            if (code == SUCCESS)
                return true;
            else
                return false;
        }
    }
}
