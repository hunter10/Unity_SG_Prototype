namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface ICommonWebView
    {
        string VERSION { get; }
        int COMMON_WEBVIEW { get; }
        void Show(string url, UIView.UIViewDelegate callback);
        void Show(string url, string configuration, UIView.UIViewDelegate callback);
    }
}