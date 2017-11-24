namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IForumUIView
    {
        void ShowForumWebView(UIView.UIViewDelegate callback);
        void ShowForumWebView(string guildId, UIView.UIViewDelegate callback);
        void SetViewConfiguration(string configuration);
        int FORUM_WEBVIEW { get; }
    }
}