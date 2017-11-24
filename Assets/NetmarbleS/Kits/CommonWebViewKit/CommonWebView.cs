namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Runtime.InteropServices;
    using System.Collections;
    using NetmarbleS.Internal;
    using System.Collections.Generic;
    using LitJson;

    public class CommonWebView
    {
        public static int COMMON_WEBVIEW
        {
            get
            {
                return CommonWebViewImpl.COMMON_WEBVIEW;
            }
        }

        public static void Show(string url, UIView.UIViewDelegate callback)
        {
            Log.Debug("[CommonWebView] Show");
            CommonWebViewImpl.Show(url, callback);
        }

        public static void Show(string url, CommonWebViewConfiguration configuration, UIView.UIViewDelegate callback)
        {
            Log.Debug("[CommonWebView] Show");
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(COMMON_WEBVIEW, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(COMMON_WEBVIEW, false);
            }
            CommonWebViewImpl.Show(url, configuration.ToJsonString(), callback);
        }

        private static readonly string VERSION = "1.3.0.4000.2";
        private static ICommonWebView commonWebView;
        private static ICommonWebView CommonWebViewImpl
        {
            get
            {
                if (null == commonWebView)
                {
                    commonWebView = Internal.ClassLoader.GetTargetClass("CommonWebView") as ICommonWebView;
                    Log.Debug("[CommonWebView] NMGUnity Version : " + VERSION + "(" + commonWebView.VERSION + ")");
                }
                return commonWebView;
            }
        }
    }
}