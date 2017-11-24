namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class Promotion
    {
        public static int BASE
        {
            get
            {
                return PromotionImpl.BASE;
            }
        }

        public static int UPPER
        {
            get
            {
                return PromotionImpl.UPPER;
            }
        }

        public static int MAIN
        {
            get
            {
                return PromotionImpl.MAIN;

            }
        }
        public static int EVENT
        {
            get
            {
                return PromotionImpl.EVENT;

            }
        }

        public static int ETC
        {
            get
            {
                return PromotionImpl.ETC;

            }
        }

        public static void SetViewConfiguration(PromotionViewConfiguration configuration)
        {
            Log.Debug("[Promotion] SetViewConfiguration");
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(MAIN, true);
                UIViewRotation.Instance.SetRotation(EVENT, true);
                UIViewRotation.Instance.SetRotation(ETC, true);

                for (int i = BASE; i < UPPER; i++)
                {
                    UIViewRotation.Instance.SetRotation(i, true);
                }
            }
            else
            {
                UIViewRotation.Instance.SetRotation(MAIN, false);
                UIViewRotation.Instance.SetRotation(EVENT, false);
                UIViewRotation.Instance.SetRotation(ETC, false);

                for (int i = BASE; i < UPPER; i++)
                {
                    UIViewRotation.Instance.SetRotation(i, false);
                }
            }
            PromotionImpl.SetViewConfiguration(configuration.ToJsonString());
        }

        private static readonly string VERSION = "1.3.0.4000.3";
        private static IPromotion promotion;
        private static IPromotion PromotionImpl
        {
            get
            {
                if (null == promotion)
                {
                    promotion = Internal.ClassLoader.GetTargetClass("Promotion") as IPromotion;
                    Log.Debug("[Promotion] NMGUnity Version : " + VERSION + "(" + promotion.VERSION + ")");
                }
                return promotion;
            }
        }
    }

}