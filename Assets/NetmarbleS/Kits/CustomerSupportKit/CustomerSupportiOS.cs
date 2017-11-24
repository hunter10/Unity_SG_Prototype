#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using System.Runtime.InteropServices;

    public class CustomerSupportiOS : ICustomerSupport
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_cs_version();
        [DllImport("__Internal")]
        public static extern int nmg_cs_getHomeLocation();
        [DllImport("__Internal")]
        public static extern int nmg_cs_getFaqLocation();
        [DllImport("__Internal")]
        public static extern int nmg_cs_getInquiryLocation();
        [DllImport("__Internal")]
        public static extern int nmg_cs_getGuideLocation();
        [DllImport("__Internal")]
        public static extern int nmg_cs_getInquiryHistoryLocation();
        [DllImport("__Internal")]
        public static extern void nmg_cs_setViewConfiguration(string configuration);

        private string version;
        private int home;
        private int faq;
        private int inquiry;
        private int guide;
        private int inquiryHistory;

        public CustomerSupportiOS()
        {
            version = Marshal.PtrToStringAuto(nmg_cs_version());
            home = nmg_cs_getHomeLocation();
            faq = nmg_cs_getFaqLocation();
            inquiry = nmg_cs_getInquiryLocation();
            guide = nmg_cs_getGuideLocation();
            inquiryHistory = nmg_cs_getInquiryHistoryLocation();
        }

        public string VERSION
        {
            get { return version; }
        }

        public int HOME
        {
            get { return home; }
        }

        public int FAQ
        {
            get { return faq; }
        }

        public int INQUIRY
        {
            get { return inquiry; }
        }

        public int GUIDE
        {
            get { return guide; }
        }

        public int INQUIRY_HISTORY
        {
            get { return inquiryHistory; }
        }

        public void SetViewConfiguration(string configuration)
        {
            nmg_cs_setViewConfiguration(configuration);
        }
    }
}
#endif