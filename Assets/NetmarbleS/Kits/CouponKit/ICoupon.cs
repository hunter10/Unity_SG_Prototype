namespace NetmarbleS
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface ICoupon
    {
        string VERSION { get; }
        int COUPON { get; }
        void SetViewConfiguration(string configuration);
    }
}