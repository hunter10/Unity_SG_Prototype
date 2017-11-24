﻿namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using NetmarbleS.Internal;
    using System.Collections.Generic;
    using LitJson;

    public class CouponViewConfiguration
    {
        private bool useTitleBar;
        private string strokeColor;
        private bool useDim;
        private bool useFloatingBackButton;
        private bool useControllerBar;
        private CouponViewConfiguration.ControllerBarConfiguration controllerBarConfiguration;
        private bool useRotation;
        private bool useProgressBar;
        private bool useNotShowToday;
        private bool useLocalData;
        public enum ImmersiveMode
        {
            None = 0,
            Use,
            NotUse
        }

        private ImmersiveMode useImmersiveSticky;

        public class ControllerBarConfiguration
        {
            private bool useBack;
            private bool useForward;
            private bool useRefresh;
            private bool useBrowser;
            private bool useShare;

            public ControllerBarConfiguration(bool useBack, bool useForward, bool useRefresh, bool useBrowser, bool useShare)
            {
                this.useBack = useBack;
                this.useForward = useForward;
                this.useRefresh = useRefresh;
                this.useBrowser = useBrowser;
                this.useShare = useShare;
            }

            public Dictionary<string, object> ToDictionary()
            {
                Dictionary<string, object> ControllerBarConfigDic = new Dictionary<string, object>();
                ControllerBarConfigDic.Add("useBack", this.useBack);
                ControllerBarConfigDic.Add("useForward", this.useForward);
                ControllerBarConfigDic.Add("useRefresh", this.useRefresh);
                ControllerBarConfigDic.Add("useBrowser", this.useBrowser);
                ControllerBarConfigDic.Add("useShare", this.useShare);

                return ControllerBarConfigDic;
            }

            public bool UseBack
            {
                get
                {
                    return useBack;
                }
                set
                {
                    useBack = value;
                }
            }

            public bool UseForward
            {
                get
                {
                    return useForward;
                }
                set
                {
                    useForward = value;
                }
            }

            public bool UseRefresh
            {
                get
                {
                    return useRefresh;
                }
                set
                {
                    useRefresh = value;
                }
            }

            public bool UseBrowser
            {
                get
                {
                    return useBrowser;
                }
                set
                {
                    useBrowser = value;
                }
            }

            public bool UseShare
            {
                get
                {
                    return useShare;
                }
                set
                {
                    useShare = value;
                }
            }
            public override string ToString()
            {
                return "[ControllerBarConfiguration] UseBack(" + UseBack + "), useForward(" + useForward + "), useRefresh(" + useRefresh + "), useBrowser" + useBrowser + "), useShare(" + useShare + ")";
            }

        }

        public override string ToString()
        {
            return "[CouponViewConfiguration] useTitleBar(" + useTitleBar + "), strokeColor(" + strokeColor + "), useDim(" + useDim + "), useFloatingBackButton(" + useFloatingBackButton + "), useControllerBar" + useControllerBar + "), ControllerBarConfiguration(" + controllerBarConfiguration.ToString() + "), useRotation(" + useRotation + "), useProgressBar(" + useProgressBar + "), useNotShowToday(" + useNotShowToday + "), useLocalData(" + useLocalData + ")";
        }

        public string ToJsonString()
        {
            return Internal.Utils.ToJson(ToDictionary());
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("useTitleBar", this.useTitleBar);
            dic.Add("strokeColor", this.strokeColor);
            dic.Add("useDim", this.useDim);
            dic.Add("useFloatingBackButton", this.useFloatingBackButton);
            dic.Add("useControllerBar", this.useControllerBar);
            dic.Add("controllerBarConfiguration", this.controllerBarConfiguration.ToDictionary());
            dic.Add("useRotation", this.useRotation);
            dic.Add("useProgressBar", this.useProgressBar);
            dic.Add("useNotShowToday", this.useNotShowToday);
            dic.Add("useLocalData", this.useLocalData);
            dic.Add("useImmersiveSticky", this.useImmersiveSticky);

            return dic;
        }

        public CouponViewConfiguration()
        {
            string defaultValue = null;
            Log.Debug("[CouponViewConfiguration] GetDefaultValue");
#if !UNITY_EDITOR && UNITY_ANDROID
            AndroidJavaClass couponClass = new AndroidJavaClass("com.netmarble.unity.NMGCouponUnity");
            defaultValue = couponClass.CallStatic<string>("nmg_coupon_getDefaultValue");
#endif
            Log.Debug("[CouponViewConfiguration] DefaultValuie : " + defaultValue);
            if (!string.IsNullOrEmpty(defaultValue))
            {
                CallbackMessage message = new CallbackMessage(defaultValue);

                this.useTitleBar = message.GetBool("useTitleBar");
                this.strokeColor = message.GetString("strokeColor");
                this.useDim = message.GetBool("useDim");
                this.useFloatingBackButton = message.GetBool("useFloatingBackButton");
                this.useControllerBar = message.GetBool("useControllerBar");

                IDictionary controllerBarDic = message.GetDictionary("controllerBarConfiguration");
                bool dafaultUseBack = Convert.ToBoolean(controllerBarDic["useBack"].ToString());
                bool dafaultUseForward = Convert.ToBoolean(controllerBarDic["useForward"].ToString());
                bool dafaultUseRefresh = Convert.ToBoolean(controllerBarDic["useRefresh"].ToString());
                bool dafaultUseBrowser = Convert.ToBoolean(controllerBarDic["useBrowser"].ToString());
                bool dafaultUseShare = Convert.ToBoolean(controllerBarDic["useShare"].ToString());

                this.controllerBarConfiguration =
                    new ControllerBarConfiguration(dafaultUseBack, dafaultUseForward, dafaultUseRefresh, dafaultUseBrowser, dafaultUseShare);

                this.useRotation = message.GetBool("useRotation");
                this.useProgressBar = message.GetBool("useProgressBar");
                this.useNotShowToday = message.GetBool("useNotShowToday");
                this.useLocalData = message.GetBool("useLocalData");
#if !UNITY_EDITOR && UNITY_ANDROID
                this.useImmersiveSticky = (ImmersiveMode) message.GetInt("useImmersiveSticky");
#else
			    this.useImmersiveSticky = ImmersiveMode.None;
#endif
            }
            else
            {
                this.useTitleBar = true;
                this.strokeColor = "#FFCC00";
                this.useDim = false;
                this.useFloatingBackButton = true;
                this.useControllerBar = false;

                bool dafaultUseBack = true;
                bool dafaultUseForward = true;
                bool dafaultUseRefresh = true;
                bool dafaultUseBrowser = true;
                bool dafaultUseShare = true;
                this.controllerBarConfiguration = new ControllerBarConfiguration(dafaultUseBack, dafaultUseForward, dafaultUseRefresh, dafaultUseBrowser, dafaultUseShare);

                this.useRotation = true;
                this.useProgressBar = true;
                this.useNotShowToday = false;
                this.useLocalData = false;
                this.useImmersiveSticky = ImmersiveMode.None;
            }
        }

        public bool UseTitleBar
        {
            get
            {
                return useTitleBar;
            }
            set
            {
                useTitleBar = value;
            }
        }

        public string StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                strokeColor = value;
            }
        }

        public bool UseDim
        {
            get
            {
                return useDim;
            }
            set
            {
                useDim = value;
            }
        }

        public bool UseFloatingBackButton
        {
            get
            {
                return useFloatingBackButton;
            }
            set
            {
                useFloatingBackButton = value;
            }
        }

        public bool UseControllerBar
        {
            get
            {
                return useControllerBar;
            }
            set
            {
                useControllerBar = value;
            }
        }

        public bool UseRotation
        {
            get
            {
                return useRotation;
            }
            set
            {
                useRotation = value;
            }
        }

        public bool UseProgressBar
        {
            get
            {
                return useProgressBar;
            }
            set
            {
                useProgressBar = value;
            }
        }

        public bool UseNotShowToday
        {
            get
            {
                return useNotShowToday;
            }
            set
            {
                useNotShowToday = value;
            }
        }

        public bool UseLocalData
        {
            get
            {
                return useLocalData;
            }
            set
            {
                useLocalData = value;
            }
        }
        public ImmersiveMode UseImmersiveSticky
        {
            get
            {
                return useImmersiveSticky;
            }
            set
            {
                useImmersiveSticky = value;
            }
        }

        public CouponViewConfiguration.ControllerBarConfiguration ControllerBarConfig
        {
            get
            {
                return controllerBarConfiguration;
            }
            set
            {
                controllerBarConfiguration = value;
            }
        }
    }
}