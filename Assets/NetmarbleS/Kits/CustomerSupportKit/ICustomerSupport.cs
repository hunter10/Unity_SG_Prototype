namespace NetmarbleS
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface ICustomerSupport
    {
        string VERSION { get; }
        int HOME { get; }
        int FAQ { get; }
        int INQUIRY { get; }
        int GUIDE { get; }
        int INQUIRY_HISTORY { get; }
        void SetViewConfiguration(string configuration);
    }
}

