
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;


    [CustomEditor(typeof(TestData))]
    public class NMGPlayModeTestDataEditor : Editor
    {
        private TestData instance;
        private Vector2 scrollPosition;
        private enum EditState
        {
            BLANK,
            EDIT,
            ADD
        }
        private EditState state;
        private enum EditChannel
        {
            EMA,
            FACEBOOK,
            KAKAO,
            GOOGLE,
            APPLE,
            NAVER,
            TWITTER
        }
        private EditChannel channel;
        private int selected;
        string newId;

        bool showEveryNetmarble;
        bool showFacebook;
        bool showKakao;
        bool showGooglePlus;
        bool showAppleGameCenter;
        bool showNaver;
        bool showTwitter;

        void OnEnable()
        {
            instance = TestData.Instance;
            state = EditState.BLANK;
            newId = "";
            showEveryNetmarble = false;
            showFacebook = false;
            showKakao = false;
            showGooglePlus = false;
            showAppleGameCenter = false;
            showNaver = false;
            showTwitter = false;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical();

            showEveryNetmarble = EditorGUILayout.Foldout(showEveryNetmarble, "EveryNetmarble Users");
            if (showEveryNetmarble)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.EveryNetmarbleUserList, EditChannel.EMA);
                ShowUserData(instance.EveryNetmarbleUserList, EditChannel.EMA);
                EditorGUILayout.EndHorizontal();
            }
            showFacebook = EditorGUILayout.Foldout(showFacebook, "Facebook Users");
            if (showFacebook)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.FacebookUserList, EditChannel.FACEBOOK);
                ShowUserData(instance.FacebookUserList, EditChannel.FACEBOOK);
                EditorGUILayout.EndHorizontal();
            }
            showKakao = EditorGUILayout.Foldout(showKakao, "Kakao Users");
            if (showKakao)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.KakaoUserList, EditChannel.KAKAO);
                ShowUserData(instance.KakaoUserList, EditChannel.KAKAO);
                EditorGUILayout.EndHorizontal();
            }
            showGooglePlus = EditorGUILayout.Foldout(showGooglePlus, "Google Users");
            if (showGooglePlus)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.GoogleUserList, EditChannel.GOOGLE);
                ShowUserData(instance.GoogleUserList, EditChannel.GOOGLE);
                EditorGUILayout.EndHorizontal();
            }
            showAppleGameCenter = EditorGUILayout.Foldout(showAppleGameCenter, "AppleGameCenter Users");
            if (showAppleGameCenter)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.GameCenterUserList, EditChannel.APPLE);
                ShowUserData(instance.GameCenterUserList, EditChannel.APPLE);
                EditorGUILayout.EndHorizontal();
            }
            showNaver = EditorGUILayout.Foldout(showNaver, "Naver Users");
            if (showNaver)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.NaverUserList, EditChannel.NAVER);
                ShowUserData(instance.NaverUserList, EditChannel.NAVER);
                EditorGUILayout.EndHorizontal();
            }

            showTwitter = EditorGUILayout.Foldout(showTwitter, "Twitter Users");
            if (showTwitter)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                ShowUserList(instance.TwitterUserList, EditChannel.TWITTER);
                ShowUserData(instance.TwitterUserList, EditChannel.TWITTER);
                EditorGUILayout.EndHorizontal();
            }

            //#if NETMARBLES_UNITY_SAMPLE
            //        EditorGUILayout.BeginHorizontal();
            //        ShowServerData(instance.ChannelConnectionDataList);
            //        EditorGUILayout.EndHorizontal();
            //#endif
            //        EditorGUILayout.BeginHorizontal();
            //        ShowAppDelete();
            //        EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }

        private void ShowUserList(List<TestUserData> userDataList, EditChannel channel)
        {
            EditorGUILayout.BeginVertical(GUILayout.Width(130));
            EditorGUILayout.Space();

            //scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, "box");

            for (int i = 0; i < userDataList.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("-", GUILayout.Width(25)))
                {
                    instance.RemoveAt(userDataList, i);
                    return;
                }

                if (GUILayout.Button(userDataList[i].ChannelID, "box", GUILayout.ExpandWidth(true)))
                {
                    selected = i;
                    this.channel = channel;
                    state = EditState.EDIT;
                }
                EditorGUILayout.EndHorizontal();
            }

            //   EditorGUILayout.EndScrollView();

            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("Users: " + userDataList.Count, GUILayout.Width(80));

            if (GUILayout.Button("Add User"))
                state = EditState.ADD;

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }

        private void ShowUserData(List<TestUserData> userDataList, EditChannel channel)
        {
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();

            switch (state)
            {
                case EditState.ADD:
                    if (this.channel == channel)
                    {
                        newId = EditorGUILayout.TextField("ID : ", newId);
                        EditorGUILayout.Space();

                        if (GUILayout.Button("Save", GUILayout.Width(100)))
                        {
                            if (channel == EditChannel.EMA)
                                instance.Add(userDataList, new EveryNetmarbleUserData(newId));
                            else if (channel == EditChannel.FACEBOOK)
                                instance.Add(userDataList, new FacebookUserData(newId));
                            else if (channel == EditChannel.KAKAO)
                                instance.Add(userDataList, new KakaoUserData(newId));
                            else if (channel == EditChannel.GOOGLE)
                                instance.Add(userDataList, new GoogleUserData(newId));
                            else if (channel == EditChannel.APPLE)
                                instance.Add(userDataList, new GameCenterUserData(newId));
                            else if (channel == EditChannel.NAVER)
                                instance.Add(userDataList, new NaverUserData(newId));
                            else if (channel == EditChannel.TWITTER)
                                instance.Add(userDataList, new TwitterUserData(newId));

                            state = EditState.BLANK;

                            newId = "";
                        }
                    }
                    break;
                case EditState.EDIT:

                    if (this.channel == channel)
                    {
                        EditorGUILayout.LabelField("ID : ", userDataList[selected].ChannelID);

                        EditorGUILayout.Space();

                        if (GUILayout.Button("Edit", GUILayout.Width(100)))
                        {
                            state = EditState.BLANK;
                        }
                    }

                    break;
                default:
                    break;
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }

        private void ShowServerData(List<ChannelConnectionData> channelDataList)
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();

            foreach (ChannelConnectionData data in channelDataList)
            {
                EditorGUILayout.BeginVertical();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.SelectableLabel(data.PlayerId, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.DeviceKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.GameRegion, GUILayout.Width(200));
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.SelectableLabel(data.EmailKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.FacebookKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.KakaoTalkKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.GoogleKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.GameCenterKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.NaverKey, GUILayout.Width(200));
                EditorGUILayout.SelectableLabel(data.TwitterKey, GUILayout.Width(200));
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }
    }
}
