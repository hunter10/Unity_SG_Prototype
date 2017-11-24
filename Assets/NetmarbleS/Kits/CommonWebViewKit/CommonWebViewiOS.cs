#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class CommonWebViewiOS : ICommonWebView
    {

        [DllImport("__Internal")]
        public static extern IntPtr nmg_commonWebView_version();
        [DllImport("__Internal")]
        public static extern int nmg_commonWebView_getLocation();
        [DllImport("__Internal")]
        public static extern void nmg_commonWebView_show(string url, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_commonWebView_show_with_configuration(string url, string configuration,int handlerNum);


        private UIViewCallback uiviewCallback;
        private string version;
        private int location;

        public CommonWebViewiOS()
        {
              uiviewCallback = new UIViewCallback();
              version = Marshal.PtrToStringAuto(nmg_commonWebView_version());
            location = nmg_commonWebView_getLocation();
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
            int handlerNum = uiviewCallback.SetUIViewCallback(callback);
            nmg_commonWebView_show(url, handlerNum);
        }

        //
        public void Show(string url, string configuration, UIView.UIViewDelegate callback)
        {
            int handlerNum = uiviewCallback.SetUIViewCallback(callback);
            nmg_commonWebView_show_with_configuration(url, configuration, handlerNum);
        }        

    }
}
#endif