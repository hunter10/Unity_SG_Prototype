#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class NoticeAndroid : INotice
    {
        private AndroidJavaClass noticeViewClass;
        private string version;
        private int intro;
        private int ingame;

        public NoticeAndroid()
        {
            noticeViewClass = new AndroidJavaClass("com.netmarble.unity.NMGNoticeUnity");
            version = noticeViewClass.GetStatic<string>("VERSION");
            intro = noticeViewClass.CallStatic<int>("nmg_notice_get_intro");
            ingame = noticeViewClass.CallStatic<int>("nmg_notice_get_ingame");

            NoticeViewConfiguration configuration = new NoticeViewConfiguration();
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(intro, true);
                UIViewRotation.Instance.SetRotation(ingame, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(intro, false);
                UIViewRotation.Instance.SetRotation(ingame, false);
            }
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public int INTRO
        {
            get
            {
                return intro;
            }
        }

        public int INGAME
        {
            get
            {
                return ingame;
            }
        }

       
        public void SetViewConfiguration(string configuration)
        {
            noticeViewClass.CallStatic("nmg_notice_setViewConfiguration", configuration);
        }

    }
}
#endif