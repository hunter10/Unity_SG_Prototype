namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.Internal;

    public class Util
    {
        /**
         * @brief Gets the Time Zone.
         * @return TimeZone.
         */
        public static string GetTimeZone()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return UtilImpl.GetTimeZone();
        }

        /**
         * @brief Gets the DeviceKey.
         * @return DeviceKey.
         */
        public static string GetNMDeviceKey()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return UtilImpl.GetNMDeviceKey();
        }

        /**
         * @brief Gets the PlatformADID.
         * @return PlatformADID.`
         */
        public static string GetPlatformADID()
        {
            if (CallbackManager.NetmarbleGameObject == null)
                return null;

            return UtilImpl.GetPlatformADID();
        }

        private static IUtil util;
        private static IUtil UtilImpl
        {
            get
            {
                if (null == util)
                {
                    util = ClassLoader.GetTargetClass("Util") as IUtil;
                }
                return util;
            }
        }
    }
}