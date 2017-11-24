namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class ForumUIView
    {
        public static void ShowForumWebView(UIView.UIViewDelegate callback)
        {
            Log.Debug("[ForumUIView] ShowForumWebView");
            ForumUIViewImpl.ShowForumWebView(callback);
        }

        public static void ShowForumWebView(string guildId, UIView.UIViewDelegate callback)
        {
            Log.Debug("[ForumUIView] ShowForumWebView");
            ForumUIViewImpl.ShowForumWebView(guildId, callback);
        }

        public static void SetViewConfiguration(ForumViewConfiguration configuration)
        {
            Log.Debug("[ForumUIView] SetViewConfiguration");
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(ForumUIViewImpl.FORUM_WEBVIEW, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(ForumUIViewImpl.FORUM_WEBVIEW, false);
            }

            ForumUIViewImpl.SetViewConfiguration(configuration.ToJsonString());
        }

        private static IForumUIView forumUIView;
        private static IForumUIView ForumUIViewImpl
        {
            get
            {
                if (null == forumUIView)
                {
                    forumUIView = NetmarbleS.Internal.ClassLoader.GetTargetClass("ForumUIView") as IForumUIView;
                }
                return forumUIView;
            }
        }

    }
}