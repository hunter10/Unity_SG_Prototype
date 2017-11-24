#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class NoticeiOS : INotice
    {

        [DllImport("__Internal")]
        public static extern IntPtr nmg_notice_version();
        [DllImport("__Internal")]
		public static extern int nmg_notice_getIntroLocation();
        [DllImport("__Internal")]
		public static extern int nmg_notice_getInGameLocation();
        [DllImport("__Internal")]
        public static extern void nmg_notice_setViewConfiguration(string configuration);
		
        private string version;
        private int intro;
        private int ingame;
        public NoticeiOS()
        {
            version = Marshal.PtrToStringAuto(nmg_notice_version());
			intro = nmg_notice_getIntroLocation();
			ingame = nmg_notice_getInGameLocation ();
        }


        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public int INTRO 
        { 
            get
            {
                return intro;
            }
        }

        public int INGAME
        { 
            get
            {
                return ingame;
            }
        }


        public void SetViewConfiguration(string configuration)
        {
            nmg_notice_setViewConfiguration(configuration);
        }        

    }
}
#endif