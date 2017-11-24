#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class UIViewAndroid : IUIView
    {
        private AndroidJavaClass uiviewAndroidClass;
        private UIViewCallback uiviewCallback;

        public UIViewAndroid()
        {
            uiviewAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGUIViewUnity");
            uiviewCallback = new UIViewCallback();
        }

        public void Show(int location, UIView.UIViewDelegate callback)
        {
            int handlerNum = uiviewCallback.SetUIViewCallback(location, callback);
            uiviewAndroidClass.CallStatic("nmg_uiview_show", location, handlerNum);
        }
    }
}
#endif
