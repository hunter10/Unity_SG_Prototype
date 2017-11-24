#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class ForumUIViewiOS : IForumUIView
    {
        [DllImport("__Internal")]
        public static extern void nmg_forum_showForumWebView(int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_showForumWebViewWithGuildId(string guildId, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_setViewConfiguration(string configuration);

		private UIViewCallback forumCallback;

        public ForumUIViewiOS()
        {
            forumCallback = new UIViewCallback();     
        }
        public void ShowForumWebView(UIView.UIViewDelegate callback)
        {
            int handlerNum = forumCallback.SetUIViewCallback(callback);
            nmg_forum_showForumWebView(handlerNum);
        }

        public void ShowForumWebView(string guildId, UIView.UIViewDelegate callback)
        {
            int handlerNum = forumCallback.SetUIViewCallback(callback);
            nmg_forum_showForumWebViewWithGuildId(guildId, handlerNum);
        }

        public void SetViewConfiguration(string configuration)
        {
            nmg_forum_setViewConfiguration(configuration);
        } 

        public int FORUM_WEBVIEW
        { 
            get
            {
                return 0;
            }
        }
    }
}
#endif