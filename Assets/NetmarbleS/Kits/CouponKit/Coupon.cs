namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class Coupon
    {
        public static int COUPON
        {
            get
            {
                return CouponImpl.COUPON;
            }
        }
        public static void SetViewConfiguration(CouponViewConfiguration configuration)
        {
            Log.Debug("[Coupon] SetViewConfiguration");
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(COUPON, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(COUPON, false);
            }
            CouponImpl.SetViewConfiguration(configuration.ToJsonString());
        }

        private static readonly string VERSION = "1.1.0.4000.1";
        private static ICoupon coupon;
        private static ICoupon CouponImpl
        {
            get
            {
                if (null == coupon)
                {
                    coupon = Internal.ClassLoader.GetTargetClass("Coupon") as ICoupon;
                    Log.Debug("[Coupon] NMGUnity Version : " + VERSION + "(" + coupon.VERSION + ")");
                }
                return coupon;
            }
        }
    }
}
