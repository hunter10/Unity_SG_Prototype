namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    public enum ForumArticleType
    {
        GuildmemberJoin = 0,
        Notice = 1,
        MemberlevelChange = 2,
        Custom = 3
    }

    public class ForumArticleParameter
    {
        public ForumArticleType articleType { get; set; }

        public string nickName { get; set; }
        public string prevLevelName { get; set; }
        public string afterLevelName { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        public ForumArticleParameter()
        {
            articleType = ForumArticleType.GuildmemberJoin;
            nickName = "";
            prevLevelName = "";
            afterLevelName = "";
            title = "";
            content = "";
        }

        public ForumArticleParameter(IDictionary dic)
        {
            articleType = (ForumArticleType)dic.GetInt("articleType");
            nickName = dic.GetString("nickname");
            prevLevelName = dic.GetString("prevLevelName");
            afterLevelName = dic.GetString("afterLevelName");
            title = dic.GetString("title");
            content = dic.GetString("content");
        }

        public string ToJsonString()
        {
            return Internal.Utils.ToJson(ToDictionary());
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> forumArticleParameterDic = new Dictionary<string, object>();
            forumArticleParameterDic.Add("articleType", this.articleType);
            forumArticleParameterDic.Add("nickname", this.nickName);
            forumArticleParameterDic.Add("prevLevelName", this.prevLevelName);
            forumArticleParameterDic.Add("afterLevelName", this.afterLevelName);
            forumArticleParameterDic.Add("title", this.title);
            forumArticleParameterDic.Add("content", this.content);

            return forumArticleParameterDic;
        }
    }

    public enum ForumChannel
    {
        //???
        None = -1,
        Facebook = 1,
        Google = 5,
        QQ = 9,
        Twitter = 12
    }

    public class ForumCharacterParameter
    {

        public string characterId { get; set; }
        public string characterName { get; set; }
        public string characterImgUrl { get; set; }
        public string statusCd { get; set; }
        public string serverId { get; set; }
        public string serverName { get; set; }
        public string characterInfo { get; set; }
        public string guildId { get; set; }

        public ForumCharacterParameter()
        {
            characterId = "";
            characterName = "";
            characterImgUrl = "";
            statusCd = "";
            serverId = "";
            serverName = "";
            characterInfo = "";
            guildId = "";
        }

        public ForumCharacterParameter(IDictionary dic)
        {
            characterId = dic.GetString("characterId");
            characterName = dic.GetString("characterName");
            characterImgUrl = dic.GetString("characterImgUrl");
            statusCd = dic.GetString("statusCd");
            serverId = dic.GetString("serverId");
            serverName = dic.GetString("serverName");
            characterInfo = dic.GetString("characterInfo");
            guildId = dic.GetString("guildId");
        }

        public string ToJsonString()
        {
            return Internal.Utils.ToJson(ToDictionary());
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("characterId", this.characterId);
            dic.Add("characterName", this.characterName);
            dic.Add("characterImgUrl", this.characterImgUrl);
            dic.Add("statusCd", this.statusCd);
            dic.Add("serverId", this.serverId);
            dic.Add("serverName", this.serverName);
            dic.Add("characterInfo", this.characterInfo);
            dic.Add("guildId", this.guildId);
            return dic;
        }
    }

    public enum ForumCommunityType
    {
        Official = 0,
        Guild = 1
    }

    public enum ForumMemberLevel
    {
        Staff,
        Normal
    }

    public class ForumGuildParameter
    {

        public string characterId { get; set; }
        public string guildId { get; set; }
        public string guildName { get; set; }
        public string guildMarkImgUrl { get; set; }
        public string guildDescription { get; set; }
        public string guildInfo { get; set; }
        public string guildMembers { get; set; }
        public string managerCharacterId { get; set; }
        public int guildMemberCount { get; set; }

        public ForumGuildParameter()
        {
            characterId = "";
            guildId = "";
            guildName = "";
            guildMarkImgUrl = "";
            guildDescription = "";
            guildInfo = "";
            guildMembers = "";
            managerCharacterId = "";
            guildMemberCount = 0;
        }

        public ForumGuildParameter(IDictionary dic)
        {
            characterId = dic.GetString("characterId");
            guildId = dic.GetString("guildId");
            guildName = dic.GetString("guildName");
            guildMarkImgUrl = dic.GetString("guildMarkImgUrl");
            guildDescription = dic.GetString("guildDescription");
            guildInfo = dic.GetString("guildInfo");
            guildMembers = dic.GetString("guildMembers");
            managerCharacterId = dic.GetString("managerCharacterId");
            guildMemberCount = dic.GetInt("guildMemberCount");
        }

        public string ToJsonString()
        {
            return Internal.Utils.ToJson(ToDictionary());
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("characterId", this.characterId);
            dic.Add("guildId", this.guildId);
            dic.Add("guildName", this.guildName);
            dic.Add("guildMarkImgUrl", this.guildMarkImgUrl);
            dic.Add("guildDescription", this.guildDescription);
            dic.Add("guildInfo", this.guildInfo);
            dic.Add("guildMembers", this.guildMembers);
            dic.Add("managerCharacterId", this.managerCharacterId);
            dic.Add("guildMemberCount", this.guildMemberCount);
            return dic;
        }
    }

    public class ForumPlayerParameter
    {
        public long userSeq { get; set; }
        public long playerSeq { get; set; }
        public string gameCode { get; set; }
        public string playerId { get; set; }
        public string playerName { get; set; }
        public string guildId { get; set; }
        public string languageCd { get; set; }
        public string statusCd { get; set; }
        public string playerInfo { get; set; }
        public long memberSeq { get; set; }
        public string playerImageUrl { get; set; }
        public string serverId { get; set; }
        public string serverName { get; set; }
        public string memberLevelCd { get; set; }
        public string characterList { get; set; }

        public ForumPlayerParameter()
        {
            userSeq = 0;
            playerSeq = 0;
            gameCode = "";
            playerId = "";
            playerName = "";
            guildId = "";
            languageCd = "";
            statusCd = "";
            playerInfo = "";
            memberSeq = 0;
            playerImageUrl = "";
            serverId = "";
            serverName = "";
            memberLevelCd = "";
            characterList = "";
        }

        public ForumPlayerParameter(IDictionary dic)
        {
            userSeq = dic.GetInt("userSeq");
            playerSeq = dic.GetInt("playerSeq");
            gameCode = dic.GetString("gameCode");
            playerId = dic.GetString("playerId");
            playerName = dic.GetString("playerName");
            guildId = dic.GetString("guildId");
            languageCd = dic.GetString("languageCd");
            statusCd = dic.GetString("statusCd");
            playerInfo = dic.GetString("playerInfo");
            memberSeq = dic.GetInt("memberSeq");
            playerImageUrl = dic.GetString("playerImgUrl");
            serverId = dic.GetString("serverId");
            serverName = dic.GetString("serverName");
            memberLevelCd = dic.GetString("memberLevelCd");
            characterList = dic.GetString("characterList");
        }

        public string ToJsonString()
        {
            return Internal.Utils.ToJson(ToDictionary());
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userSeq", this.userSeq);
            dic.Add("playerSeq", this.playerSeq);
            dic.Add("gameCode", this.gameCode);
            dic.Add("playerId", this.playerId);
            dic.Add("playerName", this.playerName);
            dic.Add("guildId", this.guildId);
            dic.Add("languageCd", this.languageCd);
            dic.Add("statusCd", this.statusCd);
            dic.Add("playerInfo", this.playerInfo);
            dic.Add("memberSeq", this.memberSeq);
            dic.Add("playerImgUrl", this.playerImageUrl);
            dic.Add("serverId", this.serverId);
            dic.Add("serverName", this.serverName);
            dic.Add("memberLevelCd", this.memberLevelCd);
            dic.Add("characterList", this.characterList);
            return dic;
        }
    }

    public class ForumGuild
    {

        public delegate void IsNewsDelegate(Result result, int count, bool isNews);

        public delegate void CreateArticleDelegate(Result result, long articleId, long bbsId);

        public delegate void CreateGamePlayerDelegate(Result result);

        public delegate void UpdateGamePlayerDelegate(Result result);

        public delegate void RequestGamePlayerDelegate(Result result, ForumPlayerParameter player);

        public delegate void CreateGuildMemberDelegate(Result result);

        public delegate void UpdateGuildInfoDelegate(Result result);

        public delegate void CreateGuildDelegate(Result result);

        public delegate void CloseGuildDelegate(Result result);

        public delegate void CheckGuildExistenceDelegate(Result result, bool isGuild);

        public delegate void WithdrawUserDelegate(Result result);

        public delegate void CreateGameCharacterDelegate(Result result);

        public delegate void UpdateGameCharacterDelegate(Result result);

        public delegate void DeleteGameCharacterDelegate(Result result);

        public delegate void RequestGameCharacterDelegate(Result result, ForumCharacterParameter character);

        public delegate void OfficialCafeIdDelegate(Result result, string cafeId);

        public static void IsNews(ForumCommunityType forumCommunityType, string characterId, IsNewsDelegate callback)
        {
            Log.Debug("[ForumGuild] IsNews");
            ForumGuildImpl.IsNews(forumCommunityType, characterId, callback);
        }

        public static void CreateGuildArticle(string guildId, ForumArticleParameter forumArticleParameter, CreateArticleDelegate callback)
        {
            Log.Debug("[ForumGuild] CreateGuildArticle");
            ForumGuildImpl.CreateGuildArticle(guildId, forumArticleParameter.ToJsonString(), callback);
        }

        public static void CreateGamePlayer(ForumPlayerParameter forumPlayerParameter, CreateGamePlayerDelegate callback)
        {
            Log.Debug("[ForumGuild] CreateGamePlayer");
            ForumGuildImpl.CreateGamePlayer(forumPlayerParameter.ToJsonString(), callback);
        }

        public static void UpdateGamePlayer(ForumPlayerParameter forumPlayerParameter, UpdateGamePlayerDelegate callback)
        {
            Log.Debug("[ForumGuild] UpdateGamePlayer");
            ForumGuildImpl.UpdateGamePlayer(forumPlayerParameter.ToJsonString(), callback);
        }

        public static void RequestGamePlayer(RequestGamePlayerDelegate callback)
        {
             Log.Debug("[ForumGuild] RequestGamePlayer");
             ForumGuildImpl.RequestGamePlayer(callback);
        }

        public static void CreateGuildMember(ForumCharacterParameter forumCharacterParameter, int guildMemberCount, CreateGuildMemberDelegate callback)
        {
            Log.Debug("[ForumGuild] CreateGuildMember");
            ForumGuildImpl.CreateGuildMember(forumCharacterParameter.ToJsonString(), guildMemberCount, callback);
        }

        public static void WithdrawGuildMember(string guildId, string characterId, int guildMemberCount, WithdrawUserDelegate callback)
        {
            Log.Debug("[ForumGuild] WithdrawGuildMember");
            ForumGuildImpl.WithdrawGuildMember(guildId, characterId, guildMemberCount, callback);
        }

        public static void CheckGuildExistence(string guildId, CheckGuildExistenceDelegate callback)
        {
            Log.Debug("[ForumGuild] CheckGuildExistence");
            ForumGuildImpl.CheckGuildExistence(guildId, callback);
        }

        public static void CreateGuild(ForumGuildParameter forumGuildParameter, CreateGuildDelegate callback)
        {
            Log.Debug("[ForumGuild] CreateGuild");
            ForumGuildImpl.CreateGuild(forumGuildParameter.ToJsonString(), callback);
        }

        public static void UpdateGuild(ForumGuildParameter forumGuildParameter, UpdateGuildInfoDelegate callback)
        {
             Log.Debug("[ForumGuild] CheckConnectionAccount");
             ForumGuildImpl.UpdateGuild(forumGuildParameter.ToJsonString(), callback);
        }

        public static void CloseGuild(string guildId, string characterId, CloseGuildDelegate callback)
        {
            Log.Debug("[ForumGuild] CloseGuild");
			ForumGuildImpl.CloseGuild(guildId, characterId, callback);
        }

        public static void CreateGameCharacter(ForumCharacterParameter forumCharacterParameter, CreateGameCharacterDelegate callback)
        {
            Log.Debug("[ForumGuild] CreateGameCharacter");
            ForumGuildImpl.CreateGameCharacter(forumCharacterParameter.ToJsonString(), callback);
        }

        public static void UpdateGameCharacter(ForumCharacterParameter forumCharacterParameter, UpdateGameCharacterDelegate callback)
        {
            Log.Debug("[ForumGuild] UpdateGameCharacter");
            ForumGuildImpl.UpdateGameCharacter(forumCharacterParameter.ToJsonString(), callback);
        }

        public static void DeleteGameCharacter(string characterId, DeleteGameCharacterDelegate callback)
        {
            Log.Debug("[ForumGuild] DeleteGameCharacter");
            ForumGuildImpl.DeleteGameCharacter(characterId, callback);
        }

        public static void RequestGameCharacter(string characterID, RequestGameCharacterDelegate callback)
        {
            Log.Debug("[ForumGuild] RequestGameCharacter");
            ForumGuildImpl.RequestGameCharacter(characterID, callback);
        }

        public static void OfficialCafeId(OfficialCafeIdDelegate callback)
        {
            Log.Debug("[ForumGuild] OfficialCafeId");
            ForumGuildImpl.OfficialCafeId(callback);
        }

        private static readonly string VERSION = "1.2.0.4100.1";
        private static IForumGuild forumGuild;
        private static IForumGuild ForumGuildImpl
        {
            get
            {
                if (null == forumGuild)
                {
                    forumGuild = NetmarbleS.Internal.ClassLoader.GetTargetClass("ForumGuild") as IForumGuild;
                    Log.Debug("[ForumGuild] NMGUnity Version : " + VERSION + "(" + forumGuild.VERSION + ")");
                }
                return forumGuild;
            }
        }
    }
}