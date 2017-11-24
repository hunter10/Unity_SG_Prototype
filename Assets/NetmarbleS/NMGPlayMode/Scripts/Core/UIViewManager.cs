#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;

    public class UIViewManager
    {

        private bool isActionTermsOfServiceView = false;

        public delegate void ShowViewDelegate(UIViewState state, UIView.UIViewDelegate handler);

        private static UIViewManager instance;
        public static UIViewManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIViewManager();
                }
                return instance;
            }
        }

        public void ShowTermsOfServiceView(UIView.UIViewDelegate handler)
        {
            string isShowed = NMGPlayerPrefs.GetTermsOfServiceViewShowed();

            if (!string.IsNullOrEmpty(isShowed))
            {
                Log.Debug("[NMGPlayMode.UIViewManager] Terms of service view is show only once.");

                OnShowView(UIViewState.CLOSED, handler);
                return;
            }

            if (SessionManager.SessionStatus.INITIALIZING == SessionManager.Instance.status)
            {
                SessionManager.Instance.waitForTermsOfService = true;
                SessionManager.Instance.termsOfServiceHandler = handler;
                return;
            }

            if (true == isActionTermsOfServiceView)
            {
                Log.Debug("[NMGPlayMode.UIViewManager] Terms of service view is progress.");

                OnShowView(UIViewState.FAILED, handler);
                return;
            }

            TermsOfServiceController.Show(OnShowView, handler);
        }

        public void OnShowView(UIViewState state, UIView.UIViewDelegate handler)
        {
            if (state == UIViewState.OPENED)
            {
                isActionTermsOfServiceView = true;
                Debug.Log("[NMGPlayMode.UIViewManager] OPENED");
            }
            else if (state == UIViewState.FAILED)
            {
                isActionTermsOfServiceView = false;
                Debug.Log("[NMGPlayMode.UIViewManager] FAILED");
            }
            else if (state == UIViewState.CLOSED)
            {
                isActionTermsOfServiceView = false;
                Debug.Log("[NMGPlayMode.UIViewManager] CLOSED");
                NMGPlayerPrefs.SetTermsOfServiceViewShowed("True");
            }
            else if (state == UIViewState.REWARDED)
            {
                isActionTermsOfServiceView = false;
                Debug.Log("[NMGPlayMode.UIViewManager] REWARDED");
            }

            if (handler != null)
                handler(state);
        }
    }
}
#endif
