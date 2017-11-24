namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class CustomerSupport
    {
        public static int HOME
        {
            get
            {
                return customerSupportImpl.HOME;
            }
        }
        public static int FAQ
        {
            get
            {
                return customerSupportImpl.FAQ;
            }
        }
        public static int INQUIRY
        {
            get
            {
                return customerSupportImpl.INQUIRY;
            }
        }
        public static int GUIDE
        {
            get
            {
                return customerSupportImpl.GUIDE;
            }
        }
        public static int INQUIRY_HISTORY
        {
            get
            {
                return customerSupportImpl.INQUIRY_HISTORY;
            }
        }

        public static void SetViewConfiguration(CustomerSupportViewConfiguration configuration)
        {
            Log.Debug("[CustomerSupport] SetViewConfiguration");
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(HOME, true);
                UIViewRotation.Instance.SetRotation(FAQ, true);
                UIViewRotation.Instance.SetRotation(INQUIRY, true);
                UIViewRotation.Instance.SetRotation(GUIDE, true);
                UIViewRotation.Instance.SetRotation(INQUIRY_HISTORY, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(HOME, false);
                UIViewRotation.Instance.SetRotation(FAQ, false);
                UIViewRotation.Instance.SetRotation(INQUIRY, false);
                UIViewRotation.Instance.SetRotation(GUIDE, false);
                UIViewRotation.Instance.SetRotation(INQUIRY_HISTORY, false);
            }
            customerSupportImpl.SetViewConfiguration(configuration.ToJsonString());
        }

        private static readonly string VERSION = "1.2.0.4000.1";
        private static ICustomerSupport customerSupport;
        private static ICustomerSupport customerSupportImpl
        {
            get
            {
                if (null == customerSupport)
                {
                    customerSupport = Internal.ClassLoader.GetTargetClass("CustomerSupport") as ICustomerSupport;
                    Log.Debug("[CustomerSupport] NMGUnity Version : " + VERSION + "(" + customerSupport.VERSION + ")");
                }
                return customerSupport;
            }
        }
    }
}
