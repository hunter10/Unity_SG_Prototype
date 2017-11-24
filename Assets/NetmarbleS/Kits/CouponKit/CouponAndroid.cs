#if UNITY_ANDROID
namespace NetmarbleS
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CouponAndroid : ICoupon
    {
        private AndroidJavaClass couponClass;
        private string version;
        private int coupon;

        public CouponAndroid()
        {
            couponClass = new AndroidJavaClass("com.netmarble.unity.NMGCouponUnity");
            version = couponClass.GetStatic<string>("VERSION");
            coupon = couponClass.CallStatic<int>("nmg_coupon_get_location");

            CouponViewConfiguration configuration = new CouponViewConfiguration();
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(coupon, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(coupon, false);
            }
        }

        public string VERSION
        {
            get { return version; }
        }

        public int COUPON
        {
            get { return coupon; }
        }

        public void SetViewConfiguration(string configuration)
        {
            couponClass.CallStatic("nmg_coupon_setViewConfiguration", configuration);
        }
    }
}
#endif