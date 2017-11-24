namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    public class SessionCallback
    {
        public int SetChannelSignInCallback(Session.ChannelSignInDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] ChannelSignInCallback: " + message.ToString());

                Result result = message.GetResult();
                int channelCode = message.GetInt("channelCode");

                if (null != callback)
                    callback(result, channelCode);
            });

            return handlerNum;
        }

        public int SetSignInCallback(Session.SignInDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] SignInCallback: " + message.ToString());

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetConnectToChannelCallback(Session.ConnectToChannelDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] ConnectToChannelCallback: " + message.ToString());

                Result result = message.GetResult();

                List<ChannelConnectOption> channelConnectOptionList = null;
                IList optionList = message.GetList("channelConnectOptionList");
                if (null != optionList)
                {
                    channelConnectOptionList = new List<ChannelConnectOption>();
                    foreach (IDictionary option in optionList)
                    {
                        int type = option.GetInt("type");
                        string playerId = option.GetString("playerId");
                        int channelCode = option.GetInt("channelCode");
                        string channelId = option.GetString("channelId");
                        string region = option.GetString("region");

                        ChannelConnectOption channelConnectOption = new ChannelConnectOption((ChannelConnectOptionType)type, playerId, channelCode, channelId, region);
                        channelConnectOptionList.Add(channelConnectOption);
                    }
                }

                if (null != callback)
                    callback(result, channelConnectOptionList);
            });

            return handlerNum;

        }

        public int SetSelectChannelConnectOptionCallback(Session.SelectChannelConnectOptionDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] SelectChannelConnectOptionCallback: " + message.ToString());

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetDisconnectFromChannelCallback(Session.DisconnectFromChannelDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] DisconnectFromChannelCallback: " + message.ToString());

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetIssueOTPCallback(Session.IssueOTPDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] IssueOTPCallback: " + message.ToString());

                Result result = message.GetResult();
                string otp = message.GetString("otp");

                List<OTPAuthenticationHistory> otpAuthenticationHistoryList = null;
                IList historyList = message.GetList("otpAuthenticationHistoryList");
                if (historyList != null)
                {
                    otpAuthenticationHistoryList = new List<OTPAuthenticationHistory>();
                    foreach (IDictionary history in historyList)
                    {
                        string gameCode = history.GetString("gameCode");
                        string playerId = history.GetString("playerId");
                        string creationDate = history.GetString("creationDate");

                        otpAuthenticationHistoryList.Add(new OTPAuthenticationHistory(gameCode, playerId, creationDate));
                    }
                }

                if (null != callback)
                    callback(result, otp, otpAuthenticationHistoryList);
            });

            return handlerNum;
        }

        public int SetRequestOTPInfoCallback(Session.RequestOTPInfoDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] RequestOTPInfoCallback: " + message.ToString());

                Result result = message.GetResult();

                IDictionary otpInfoDic = message.GetDictionary("otpInfo");
                OTPInfo otpInfo = null;
                if (null != otpInfoDic)
                {
                    string otp = otpInfoDic.GetString("otp");
                    string playerId = otpInfoDic.GetString("playerId");
                    string region = otpInfoDic.GetString("region");

                    List<OTPAuthenticationHistory> otpAuthenticationHistoryList = null;
                    IList historyList = otpInfoDic["otpAuthenticationHistoryList"] as IList;
                    if (historyList != null)
                    {
                        otpAuthenticationHistoryList = new List<OTPAuthenticationHistory>();
                        foreach (IDictionary history in historyList)
                        {
                            string historyGameCode = history.GetString("gameCode");
                            string historyPlayerId = history.GetString("playerId");
                            string creationDate = history.GetString("creationDate");
                            otpAuthenticationHistoryList.Add(new OTPAuthenticationHistory(historyGameCode, historyPlayerId, creationDate));
                        }
                    }
                    otpInfo = new OTPInfo(otp, playerId, region, otpAuthenticationHistoryList); 
                }

                IDictionary restrictOTPInputDic = message.GetDictionary("restrictOTPInput");
                RestrictOTPInput restrictOTPInput = null;
                if (null != restrictOTPInputDic)
                {
                    int failCount = restrictOTPInputDic.GetInt("failCount");
                    string retryDateTime = restrictOTPInputDic.GetString("retryDateTime");

                    restrictOTPInput = new RestrictOTPInput(failCount, retryDateTime);
                }

                if (null != callback)
                    callback(result, otpInfo, restrictOTPInput);
            });

            return handlerNum;
        }

        public int SetCopyPlayerIdWithOTPCallback(Session.CopyPlayerIdWithOTPDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[SessionCallback] CopyPlayerIdWithOTPCallback: " + message.ToString());

                Result result = message.GetResult();

                RestrictOTPInput restrictOTPInput = null;
                IDictionary restrictOTPInputDic = message.GetDictionary("restrictOTPInput");
                if (null != restrictOTPInputDic)
                {
                    int failCount = restrictOTPInputDic.GetInt("failCount");
                    string retryDateTime = restrictOTPInputDic.GetString("retryDateTime");

                    restrictOTPInput = new RestrictOTPInput(failCount, retryDateTime);
                }

                if (null != callback)
                    callback(result, restrictOTPInput);
            });

            return handlerNum;
        }
    }
}