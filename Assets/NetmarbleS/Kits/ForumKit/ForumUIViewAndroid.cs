#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class ForumUIViewAndroid : IForumUIView
    {
        private AndroidJavaClass androidClass;
        private UIViewCallback forumCallback;
        private int location;

        public ForumUIViewAndroid()
        {
            androidClass = new AndroidJavaClass("com.netmarble.unity.NMGForumUnity");
            forumCallback = new UIViewCallback();
           
            AndroidJavaClass forumClass = new AndroidJavaClass("com.netmarble.forum.view.ForumWebView");
            location = forumClass.GetStatic<int>("FORUM_WEBVIEW");

            ForumViewConfiguration configuration = new ForumViewConfiguration();
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(location, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(location, false);
            }
        }

        public int FORUM_WEBVIEW
        {
            get
            {
                return location;
            }
        }

        public void ShowForumWebView(UIView.UIViewDelegate callback)
        {
            int handlerNum = forumCallback.SetUIViewCallback(location, callback);
            androidClass.CallStatic("nmg_forum_showForumWebView", handlerNum);
        }

        public void ShowForumWebView(string guildId, UIView.UIViewDelegate callback)
        {
            int handlerNum = forumCallback.SetUIViewCallback(location, callback);
            androidClass.CallStatic("nmg_forum_showForumWebViewWithGuildId", guildId, handlerNum);
        }

        public void SetViewConfiguration(string configuration)
        {
            androidClass.CallStatic("nmg_forum_setViewConfiguration", configuration);
        }
    }
}
#endif