namespace NetmarbleS
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CustomerSupportPlatform : ICustomerSupport
    {
        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }

        public int HOME
        {
            get { return 0; }
        }

        public int FAQ
        {
            get { return 0; }
        }

        public int INQUIRY
        {
            get { return 0; }
        }

        public int GUIDE
        {
            get { return 0; }
        }

        public int INQUIRY_HISTORY
        {
            get { return 0; }
        }

        public void SetViewConfiguration(string configuration)
        {

        }
    }
}