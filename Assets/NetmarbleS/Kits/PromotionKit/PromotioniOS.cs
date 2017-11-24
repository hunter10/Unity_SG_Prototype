#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class PromotioniOS : IPromotion
    {

        [DllImport("__Internal")]
        public static extern IntPtr nmg_promotion_version();
        [DllImport("__Internal")]
		public static extern int nmg_promotion_getBaseLocation();
        [DllImport("__Internal")]
		public static extern int nmg_promotion_getUpperLocation();
        [DllImport("__Internal")]
		public static extern int nmg_promotion_getMainLocation();
        [DllImport("__Internal")]
		public static extern int nmg_promotion_getEventLocation();
        [DllImport("__Internal")]
		public static extern int nmg_promotion_getEtcLocation();
        [DllImport("__Internal")]
        public static extern void nmg_promotion_setViewConfiguration(string configuration);

		
        private string version;
        private int location;
        private int upper;
        private int main;
        private int eventLocation;
        private int etc;

        public PromotioniOS()
        {
            version = Marshal.PtrToStringAuto(nmg_promotion_version());
			location = nmg_promotion_getBaseLocation();
			main = nmg_promotion_getMainLocation();
			eventLocation = nmg_promotion_getEventLocation ();
			etc = nmg_promotion_getEtcLocation();
            upper = nmg_promotion_getUpperLocation();
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
                return location;
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

        //
        public void SetViewConfiguration(string configuration)
        {
            nmg_promotion_setViewConfiguration(configuration);
        }            

    }
}
#endif