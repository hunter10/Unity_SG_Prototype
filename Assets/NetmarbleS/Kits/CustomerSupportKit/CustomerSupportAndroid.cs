#if UNITY_ANDROID
namespace NetmarbleS
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CustomerSupportAndroid : ICustomerSupport
    {
        private AndroidJavaClass customerSupportClass;
        private string version;
        private int home;
        private int faq;
        private int inquiry;
        private int guide;
        private int inquiryHistory;

        public CustomerSupportAndroid()
        {
            customerSupportClass = new AndroidJavaClass("com.netmarble.unity.NMGCustomerSupportUnity");
            version = customerSupportClass.GetStatic<string>("VERSION");
            home = customerSupportClass.CallStatic<int>("nmg_cs_get_home");
            faq = customerSupportClass.CallStatic<int>("nmg_cs_get_faq");
            inquiry = customerSupportClass.CallStatic<int>("nmg_cs_get_inquiry");
            guide = customerSupportClass.CallStatic<int>("nmg_cs_get_guide");
            inquiryHistory = customerSupportClass.CallStatic<int>("nmg_cs_get_inquiryHistory");

            CustomerSupportViewConfiguration configuration = new CustomerSupportViewConfiguration();
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(home, true);
                UIViewRotation.Instance.SetRotation(faq, true);
                UIViewRotation.Instance.SetRotation(inquiry, true);
                UIViewRotation.Instance.SetRotation(guide, true);
                UIViewRotation.Instance.SetRotation(inquiryHistory, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(home, false);
                UIViewRotation.Instance.SetRotation(faq, false);
                UIViewRotation.Instance.SetRotation(inquiry, false);
                UIViewRotation.Instance.SetRotation(guide, false);
                UIViewRotation.Instance.SetRotation(inquiryHistory, false);
            }
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
            customerSupportClass.CallStatic("nmg_cs_setViewConfiguration", configuration);
        }
    }
}
#endif