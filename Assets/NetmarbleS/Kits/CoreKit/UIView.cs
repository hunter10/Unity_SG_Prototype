namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public enum UIViewState
    {
        /**
         * Opened.
         */
        OPENED = 0,
        /**
         * Closed.
         */
        CLOSED,
        /**
         * Failed.
         */
        FAILED,
        /**
         * Rewarded.
         */
        REWARDED
    }
    public class UIView
    {
        public delegate void UIViewDelegate(UIViewState uiViewState);

        public static void Show(int location, UIViewDelegate callback)
        {
            Log.Debug("[UIView] Show: " + location);
            UIViewImpl.Show(location, callback);
        }


        private static IUIView uiview;
        private static IUIView UIViewImpl
        {
            get
            {
                if (null == uiview)
                {
                    uiview = Internal.ClassLoader.GetTargetClass("UIView") as IUIView;
                }
                return uiview;
            }
        }
    }
}