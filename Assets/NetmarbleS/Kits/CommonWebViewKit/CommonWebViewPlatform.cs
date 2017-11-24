namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class CommonWebViewPlatform : ICommonWebView
    {
        public string VERSION
        {
            get
            {
                return "0.0.0.0000";
            }
        }

        public int COMMON_WEBVIEW
        {
            get { return 0; }
        }

        public void Show(string url, UIView.UIViewDelegate callback)
        {

        }
        
        public void Show(string url, string configuration, UIView.UIViewDelegate callback)
        {

        }
    }
}