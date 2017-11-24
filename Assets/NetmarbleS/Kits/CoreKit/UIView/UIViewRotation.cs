namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class UIViewRotation
    {
        private bool autorotateToLandscapeLeft;
        private bool autorotateToLandscapeRight;
        private bool autorotateToPortrait;
        private bool autorotateToPortraitUpsideDown;
        private ScreenOrientation currentOrientation;

        private Dictionary<int, bool> rotationDic;

        private UIViewRotation()
        {
            currentOrientation = Screen.orientation;
            autorotateToLandscapeLeft = Screen.autorotateToLandscapeLeft;
            autorotateToLandscapeRight = Screen.autorotateToLandscapeRight;
            autorotateToPortrait = Screen.autorotateToPortrait;
            autorotateToPortraitUpsideDown = Screen.autorotateToPortraitUpsideDown;

            rotationDic = new Dictionary<int, bool>();

            //Debug.Log("currentOrientation : " + currentOrientation);
            //Debug.Log("autorotateToLandscapeLeft : " + autorotateToLandscapeLeft);
            //Debug.Log("autorotateToLandscapeRight : " + autorotateToLandscapeRight);
            //Debug.Log("autorotateToPortrait : " + autorotateToPortrait);
            //Debug.Log("autorotateToPortraitUpsideDown : " + autorotateToPortraitUpsideDown);
        }

        public void SetRotation(int location, bool rotate)
        {
            rotationDic[location] = rotate;
        }

        public bool GetRotaton(int location)
        {
            if (rotationDic.ContainsKey(location))
                return rotationDic[location];
            else
                return false;
        }

        public void SetAutoRotation(int location)
        {
            if (GetRotaton(location))
            {
                Debug.Log("SetAutoRotation : " + location);
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.orientation = ScreenOrientation.AutoRotation;
            }
        }

        public void SetGameRotation(int location)
        {
            if (GetRotaton(location))
            {
                Debug.Log("SetGameRotation : " + location);
                Screen.orientation = currentOrientation;
                Screen.autorotateToLandscapeLeft = autorotateToLandscapeLeft;
                Screen.autorotateToLandscapeRight = autorotateToLandscapeRight;
                Screen.autorotateToPortrait = autorotateToPortrait;
                Screen.autorotateToPortraitUpsideDown = autorotateToPortraitUpsideDown;
                Screen.orientation = ScreenOrientation.AutoRotation;
            }

        }
        private static UIViewRotation instance;
        public static UIViewRotation Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new UIViewRotation();
                }
                return instance;
            }
        }
    }
}