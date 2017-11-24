namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class Notice
    {
        public static int INTRO
        {
            get
            {
                return NoticeImpl.INTRO;
            }
        }
        public static int INGAME
        {
            get
            {
                return NoticeImpl.INGAME;
            }
        }

        public static void SetViewConfiguration(NoticeViewConfiguration configuration)
        {
            Log.Debug("[Notice] SetViewConfiguration");
            if (configuration.UseRotation)
            {
                UIViewRotation.Instance.SetRotation(INTRO, true);
                UIViewRotation.Instance.SetRotation(INGAME, true);
            }
            else
            {
                UIViewRotation.Instance.SetRotation(INTRO, false);
                UIViewRotation.Instance.SetRotation(INGAME, false);
            }
            NoticeImpl.SetViewConfiguration(configuration.ToJsonString());
        }

        private static readonly string VERSION = "1.3.0.4100.1";
        private static INotice notice;
        private static INotice NoticeImpl
        {
            get
            {
                if (null == notice)
                {
                    notice = Internal.ClassLoader.GetTargetClass("Notice") as INotice;
                    Log.Debug("[Notice] NMGUnity Version : " + VERSION + "(" + notice.VERSION + ")");
                }
                return notice;
            }
        }
    }
}
