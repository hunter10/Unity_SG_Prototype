namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.Internal;

    public class ForumCallback
    {
        public int SetIsNesDelegate(ForumGuild.IsNewsDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetIsNesDelegate: " + message);

                Result result = message.GetResult();
                int count = message.GetInt("count");
                bool isNews = message.GetBool("isNews");

                if (null != callback)
                    callback(result, count, isNews);
            });

            return handlerNum;
        }

        public int SetCreateArticleDelegate(ForumGuild.CreateArticleDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCreateArticleDelegate: " + message);

                Result result = message.GetResult();
                long articleId = System.Convert.ToInt64(message.GetString("articleId"));
                long bbsId = System.Convert.ToInt64(message.GetString("bbsId"));

                if (null != callback)
                    callback(result, articleId, bbsId);
            });

            return handlerNum;
        }

        public int SetCreateGamePlayerDelegate(ForumGuild.CreateGamePlayerDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCreateGamePlayerDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetUpdateGamePlayerDelegate(ForumGuild.UpdateGamePlayerDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetUpdateGamePlayerDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetRequestGamePlayerDelegate(ForumGuild.RequestGamePlayerDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetRequestGamePlayerDelegate: " + message);

                Result result = message.GetResult();
                ForumPlayerParameter player = null;
                IDictionary playerDic = message.GetDictionary("player");
                if (null != playerDic)
                {
                    player = new ForumPlayerParameter(playerDic);
                }

                if (null != callback)
                    callback(result, player);
            });

            return handlerNum;
        }

        public int SetCreateGuildMemberDelegate(ForumGuild.CreateGuildMemberDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCreateGuildMemberDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetUpdateGuildInfoDelegate(ForumGuild.UpdateGuildInfoDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetUpdateGuildInfoDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetCreateGuildDelegate(ForumGuild.CreateGuildDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCreateGuildDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetCloseGuildDelegate(ForumGuild.CloseGuildDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCloseGuildDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;

        }

        public int SetCheckGuildExistenceDelegate(ForumGuild.CheckGuildExistenceDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCheckGuildExistenceDelegate: " + message);

                Result result = message.GetResult();
                bool isGuild = message.GetBool("isGuild");

                if (null != callback)
                    callback(result, isGuild);
            });

            return handlerNum;
        }

        public int SetWithdrawUserDelegate(ForumGuild.WithdrawUserDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetWithdrawUserDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetCreateGameCharacterDelegate(ForumGuild.CreateGameCharacterDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetCreateGameCharacterDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetUpdateGameCharacterDelegate(ForumGuild.UpdateGameCharacterDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetUpdateGameCharacterDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetDeleteGameCharacterDelegate(ForumGuild.DeleteGameCharacterDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetDeleteGameCharacterDelegate: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;

        }

        public int SetRequestGameCharacterDelegate(ForumGuild.RequestGameCharacterDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetRequestGameCharacterDelegate: " + message);

                Result result = message.GetResult();
                ForumCharacterParameter character = null;
                IDictionary characterDic = message.GetDictionary("character");
                if (null != characterDic)
                {
                    character = new ForumCharacterParameter(characterDic);
                }

                if (null != callback)
                    callback(result, character);
            });

            return handlerNum;
        }

        public int SetOfficialCafeIdDelegate(ForumGuild.OfficialCafeIdDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[ForumCallback] SetOfficialCafeIdDelegate: " + message);

                Result result = message.GetResult();
                string cafeId = message.GetString("cafeId");
                if (null != callback)
                    callback(result, cafeId);
            });

            return handlerNum;
        }
    }
}