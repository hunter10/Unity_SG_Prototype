#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class PromotionAndroid : IPromotion
    {
        private AndroidJavaClass promotionClass;
        private string version;
        private int baseLocation;
        private int main;
        private int eventLocation;
        private int etc;
        private int upper;

        public PromotionAndroid()
        {
            promotionClass = new AndroidJavaClass("com.netmarble.unity.NMGPromotionUnity");
            version = promotionClass.GetStatic<string>("VERSION");
            baseLocation = promotionClass.CallStatic<int>("nmg_promotion_get_base");
            upper = promotionClass.CallStatic<int>("nmg_promotion_get_upper");
            main = promotionClass.CallStatic<int>("nmg_promotion_get_main");
            eventLocation = promotionClass.CallStatic<int>("nmg_promotion_get_event");
            etc = promotionClass.CallStatic<int>("nmg_promotion_get_etc");

            PromotionViewConfiguration configuration = new PromotionViewConfiguration();
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(MAIN, true);
                UIViewRotation.Instance.SetRotation(EVENT, true);
                UIViewRotation.Instance.SetRotation(ETC, true);

                for (int i = baseLocation; i < upper; i++)
                {
                    UIViewRotation.Instance.SetRotation(i, true);
                }
            }
            else
            {
                UIViewRotation.Instance.SetRotation(MAIN, false);
                UIViewRotation.Instance.SetRotation(EVENT, false);
                UIViewRotation.Instance.SetRotation(ETC, false);

                for (int i = baseLocation; i < upper; i++)
                {
                    UIViewRotation.Instance.SetRotation(i, false);
                }
            }
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public int BASE
        {
            get
            {
                return baseLocation;
            }
        }

        public int UPPER
        {
            get
            {
                return upper;
            }
        }
        public int MAIN
        {
            get
            {
                return main;
            }
        }

        public int EVENT
        {
            get
            {
                return eventLocation;
            }
        }

        public int ETC
        {
            get
            {
                return etc;
            }
        }

        public void SetViewConfiguration(string configuration)
        {
            promotionClass.CallStatic("nmg_promotion_setViewConfiguration", configuration);
        }
    }
}
#endif