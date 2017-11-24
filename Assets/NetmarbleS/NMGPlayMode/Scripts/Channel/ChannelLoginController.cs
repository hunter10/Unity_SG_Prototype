#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;

    public class ChannelLoginController : MonoBehaviour
    {
        public Image titleImage;
        public Text titleText;

        public Image backgroundImage;
        public Button loginButton;
        public Text loginText;

        public InputField idField;
        public InputField pwField;

        private static GameObject loginPanel;
        private List<TestUserData> userList;
        private SessionManager.ConnectToChannelDelegate callback;
        private NMGChannel channel;
        private Session.ConnectToChannelDelegate handler;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnClickCloseButton();

            }
        }

        public static void Show(NMGChannel channel, List<TestUserData> userList, SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            Close();
            loginPanel = (GameObject)Instantiate(Resources.Load("NMGPlayModeChannelLoginPanel"));
            //loginPanel = (GameObject)Instantiate(EditorGUIUtility.Load("NMPlayModeChannelLoginPanel.prefab"));

            ChannelLoginController controller = loginPanel.transform.FindChild("LoginPanel").gameObject.GetComponent<ChannelLoginController>();
            controller.callback = callback;
            controller.userList = userList;
            controller.channel = channel;
            controller.handler = handler;
            controller.SetChannel();
        }

        public static void Close()
        {
            if (loginPanel != null)
            {
                DestroyObject(loginPanel);
            }
        }

        public void SetChannel()
        {
            switch (channel)
            {
                case NMGChannel.EveryNetmarble:
                    backgroundImage.color = Color.white;
                    titleImage.color = new Color(1f, 0.85f, 0.05f);
                    titleText.text = "EveryNetmarble";
                    titleText.color = Color.black;
                    loginButton.image.color = new Color(0.29f, 0.23f, 0.20f);
                    loginText.color = Color.white;
                    break;
                case NMGChannel.Facebook:
                    backgroundImage.color = new Color(0.92f, 0.95f, 1f);
                    titleImage.color = new Color(0.28f, 0.39f, 0.62f);
                    titleText.text = "Facebook";
                    titleText.color = Color.white;
                    loginButton.image.color = new Color(0.28f, 0.39f, 0.62f);
                    loginText.color = Color.white;
                    break;
                case NMGChannel.Kakao:
                    backgroundImage.color = Color.white;
                    titleImage.color = new Color(0.27f, 0.19f, 0.20f);
                    titleText.text = "Kakao";
                    titleText.color = Color.white;
                    loginButton.image.color = Color.white;
                    loginText.color = new Color(0.27f, 0.19f, 0.20f);
                    break;
                case NMGChannel.Google:
                    backgroundImage.color = Color.white;
                    titleImage.color = new Color(0.48f, 0.58f, 0.11f);
                    titleText.text = "GooglePlus";
                    titleText.color = Color.white;
                    loginButton.image.color = Color.white;
                    loginText.color = new Color(0.48f, 0.58f, 0.11f);
                    break;
                case NMGChannel.GameCenter:
                    backgroundImage.color = Color.white;
                    titleImage.color = Color.white;
                    titleText.text = "AppleGameCenter";
                    titleText.color = Color.black;
                    loginButton.image.color = Color.white;
                    loginText.color = Color.black;
                    break;
                case NMGChannel.Naver:
                    backgroundImage.color = Color.white;
                    titleImage.color = Color.white;
                    titleText.text = "NAVER";
                    titleText.color = new Color(0f, 0.78f, 0.23f);
                    loginButton.image.color = new Color(0f, 0.78f, 0.23f);
                    loginText.color = Color.white;
                    break;
                case NMGChannel.Twitter:
                    backgroundImage.color = Color.white;
                    titleImage.color = new Color(0.19f, 0.79f, 0.99f);
                    titleText.text = "TWITTER";
                    titleText.color = Color.white;
                    loginButton.image.color = new Color(0.19f, 0.79f, 0.99f);
                    loginText.color = Color.white;
                    break;
            }
        }

        public void OnClickLogInButton()
        {
            if (!string.IsNullOrEmpty(idField.text) && !string.IsNullOrEmpty(pwField.text))
            {
                if (!TestData.Instance.Exist(userList, idField.text))
                {
                    TestData.Instance.Add(userList, channel, idField.text);
                }
                TestUserData userData = TestData.Instance.GetUserData(userList, idField.text);

                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, channel, userData.ChannelKey, handler);
                Close();
            }

        }

        public void OnClickCloseButton()
        {
            Result result = new Result(Result.NETMARBLES_DOMAIN, Result.USER_CANCELED, "User Canceled");
            callback(result, channel, null, handler);
            Close();
        }
    }
}
#endif