#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class CommonWebViewAndroid : ICommonWebView
    {
        private AndroidJavaClass commonWebViewClass;
        private UIViewCallback uiviewCallback;
        private string version;
        private int location;

        public CommonWebViewAndroid()
        {
            commonWebViewClass = new AndroidJavaClass("com.netmarble.unity.NMGCommonWebViewUnity");
            uiviewCallback = new UIViewCallback();
            version = commonWebViewClass.GetStatic<string>("VERSION");
            location = commonWebViewClass.CallStatic<int>("nmg_commonWebView_getLocation");

            CommonWebViewConfiguration configuration = new CommonWebViewConfiguration();
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(location, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(location, false);
            }
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public int COMMON_WEBVIEW
        {
            get
            {
                return location;
            }
        }

        public void Show(string url, UIView.UIViewDelegate callback)
        {
            int handlerNum = uiviewCallback.SetUIViewCallback(location, callback);
            commonWebViewClass.CallStatic("nmg_commonWebView_show", url, handlerNum);
        }

        public void Show(string url, string configuration, UIView.UIViewDelegate callback)
        {
            int handlerNum = uiviewCallback.SetUIViewCallback(location, callback);
            commonWebViewClass.CallStatic("nmg_commonWebView_show", url, configuration, handlerNum);
        }
    }
}
#endif