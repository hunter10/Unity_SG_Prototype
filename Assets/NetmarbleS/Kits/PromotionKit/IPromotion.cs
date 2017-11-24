namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IPromotion
    {
        string VERSION { get; }
        int BASE { get; }

        int UPPER { get; }
        int MAIN { get; }
        int EVENT { get; }
        int ETC { get; }
        void SetViewConfiguration(string configuration);
    }
}