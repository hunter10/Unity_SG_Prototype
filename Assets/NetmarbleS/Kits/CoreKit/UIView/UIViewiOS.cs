#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

    public class UIViewiOS : IUIView
    {
		[DllImport("__Internal")] 
		public static extern void nmg_uiview_show(int location, int handlerNum);

        private UIViewCallback uiviewCallback;

		public UIViewiOS()
        {
            uiviewCallback = new UIViewCallback();
        }

        public void Show(int location, UIView.UIViewDelegate callback)
        {
            int handlerNum = uiviewCallback.SetUIViewCallback(callback);
			nmg_uiview_show(location, handlerNum);
        }
    }
}
#endif
