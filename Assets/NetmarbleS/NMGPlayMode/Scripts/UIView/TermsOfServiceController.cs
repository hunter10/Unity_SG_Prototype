#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;

    public class TermsOfServiceController : MonoBehaviour
    {

        public Button serviceTerms;
        public Button privacyPolicy;
        private static GameObject termsOfServicePanel;
        private UIViewManager.ShowViewDelegate callback;
        private UIView.UIViewDelegate handler;
        private bool privacyPolicyChecked;
        private bool serviceTermsChecked;

        void Start()
        {
            privacyPolicyChecked = false;
            serviceTermsChecked = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnClose();
            }
        }

        public static void Show(UIViewManager.ShowViewDelegate callback, UIView.UIViewDelegate handler)
        {
            Close();
            termsOfServicePanel = (GameObject)Instantiate(Resources.Load("NMGPlayModeTermsOfServiceView"));

            TermsOfServiceController controller = termsOfServicePanel.transform.FindChild("TermsOfServicePanel").gameObject.GetComponent<TermsOfServiceController>();
            controller.callback = callback;
            controller.handler = handler;

            callback(UIViewState.OPENED, handler);
        }

        public static void Close()
        {
            if (termsOfServicePanel != null)
            {
                DestroyObject(termsOfServicePanel);
            }
        }

        public void OnClose()
        {
            callback(UIViewState.FAILED, handler);
            Close();
        }

        public void OnClickServiceTerms()
        {
            if (serviceTermsChecked)
            {
                serviceTermsChecked = false;
                serviceTerms.image.color = new Color(0.33f, 0.33f, 0.33f);
            }
            else
            {
                serviceTermsChecked = true;
                serviceTerms.image.color = new Color(1f, 0.80f, 0.23f);
            }

            CheckConfirm();
        }

        public void OnClickPrivacyPolicy()
        {
            if (privacyPolicyChecked)
            {
                privacyPolicyChecked = false;
                privacyPolicy.image.color = new Color(0.33f, 0.33f, 0.33f);
            }
            else
            {
                privacyPolicyChecked = true;
                privacyPolicy.image.color = new Color(1f, 0.80f, 0.23f);
            }

            CheckConfirm();
        }

        public void CheckConfirm()
        {
            if (serviceTermsChecked == true && privacyPolicyChecked == true)
            {
                callback(UIViewState.CLOSED, handler);
                Close();
            }
        }
    }
}
#endif