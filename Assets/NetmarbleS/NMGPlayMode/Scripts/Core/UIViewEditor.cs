#if UNITY_EDITOR
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.NMGPlayMode;

    public class UIViewEditor : IUIView
    {

        public void Show(int location, UIView.UIViewDelegate callback)
        {
            if (location == 11001)
            {
                UIViewManager.Instance.ShowTermsOfServiceView(callback);
            }
        }
    }
}
#endif
