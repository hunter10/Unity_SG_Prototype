namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IAppEvents
    {
        void SetDeepLinkDelegate(AppEvents.DeepLinkDelegate callback);
        void SetRewardDelegate(AppEvents.RewardDelegate callback);
    }
}