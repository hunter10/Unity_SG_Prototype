#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class ForumGuildAndroid : IForumGuild
    {
        private AndroidJavaClass androidClass;
        private ForumCallback forumCallback;
        private string version;

        public ForumGuildAndroid()
        {
            androidClass = new AndroidJavaClass("com.netmarble.unity.NMGForumUnity");
            forumCallback = new ForumCallback();
            version = androidClass.GetStatic<string>("VERSION");
        }
        public string VERSION
        {
            get { return version; }
        }

        public void IsNews(ForumCommunityType forumCommunityType, string characterId, ForumGuild.IsNewsDelegate callback)
        {
            int handlerNum = forumCallback.SetIsNesDelegate(callback);
            androidClass.CallStatic("nmg_forum_isNews", (int)forumCommunityType, characterId, handlerNum);
        }

        public void CreateGuildArticle(string guildId, string forumArticleParameter, ForumGuild.CreateArticleDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateArticleDelegate(callback);
            androidClass.CallStatic("nmg_forum_createGuildArticle", guildId, forumArticleParameter, handlerNum);
        }

        //deleted?
        //public void CheckConnectionAccount(ForumGuild.CheckConnectionAccountDelegate callback)
        //{
        //    int handlerNum = forumCallback.SetCheckConnectionAccountDelegate(callback);
        //    androidClass.CallStatic("nmg_forum_checkConnectionAccount", handlerNum);
        //}

        public void CreateGamePlayer(string forumPlayerParameter, ForumGuild.CreateGamePlayerDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGamePlayerDelegate(callback);
            androidClass.CallStatic("nmg_forum_createGamePlayer", forumPlayerParameter, handlerNum);
        }

        public void UpdateGamePlayer(string forumPlayerParameter, ForumGuild.UpdateGamePlayerDelegate callback)
        {
            int handlerNum = forumCallback.SetUpdateGamePlayerDelegate(callback);
            androidClass.CallStatic("nmg_forum_updateGamePlayer", forumPlayerParameter, handlerNum);
        }

        public void RequestGamePlayer(ForumGuild.RequestGamePlayerDelegate callback)
        {
            int handlerNum = forumCallback.SetRequestGamePlayerDelegate (callback);
            androidClass.CallStatic("nmg_forum_requestGamePlayer", handlerNum);
        }

        public void CreateGuildMember(string forumCharacterParameter, int guildMemberCount, ForumGuild.CreateGuildMemberDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGuildMemberDelegate(callback);
            androidClass.CallStatic("nmg_forum_createGuildMember", forumCharacterParameter, guildMemberCount, handlerNum);
        }
        //deleted?
        //public void UpdateGuildMember(ForumMemberLevel cafeMemberLevelCd, string guildId, string characterId, ForumGuild.UpdateGuildMemberDelegate callback)
        //{
        //    int handlerNum = forumCallback.SetUpdateGuildMemberDelegate(callback);
        //    androidClass.CallStatic("nmg_forum_updateGuildMember",(int)cafeMemberLevelCd, guildId, characterId, handlerNum);
        //}

        public void WithdrawGuildMember(string guildId, string characterId, int guildMemberCount, ForumGuild.WithdrawUserDelegate callback)
        {
            int handlerNum = forumCallback.SetWithdrawUserDelegate(callback);
            androidClass.CallStatic("nmg_forum_withdrawGuildMember", guildId, characterId, guildMemberCount, handlerNum);
        }

        public void CheckGuildExistence(string guildId, ForumGuild.CheckGuildExistenceDelegate callback)
        {
            int handlerNum = forumCallback.SetCheckGuildExistenceDelegate(callback);
            androidClass.CallStatic("nmg_forum_checkGuildExistence", guildId, handlerNum);
        }

        public void CreateGuild(string forumGuildParameter, ForumGuild.CreateGuildDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGuildDelegate(callback);
            androidClass.CallStatic("nmg_forum_createGuild", forumGuildParameter, handlerNum);
        }

        public void UpdateGuild(string forumGuildParameter, ForumGuild.UpdateGuildInfoDelegate callback)
        {
            int handlerNum = forumCallback.SetUpdateGuildInfoDelegate(callback);
            androidClass.CallStatic("nmg_forum_updateGuild", forumGuildParameter, handlerNum);
        }

		public void CloseGuild(string guildId, string characterId, ForumGuild.CloseGuildDelegate callback)
        {
            int handlerNum = forumCallback.SetCloseGuildDelegate(callback);
			androidClass.CallStatic("nmg_forum_closeGuild", guildId, characterId, handlerNum);
        }

        public void CreateGameCharacter(string forumCharacterParameter, ForumGuild.CreateGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGameCharacterDelegate(callback);
            androidClass.CallStatic("nmg_forum_createGameCharacter", forumCharacterParameter, handlerNum);
        }

        public void UpdateGameCharacter(string forumCharacterParameter, ForumGuild.UpdateGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetUpdateGameCharacterDelegate(callback);
            androidClass.CallStatic("nmg_forum_updateGameCharacter", forumCharacterParameter, handlerNum);
        }

        public void DeleteGameCharacter(string characterId, ForumGuild.DeleteGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetDeleteGameCharacterDelegate(callback);
            androidClass.CallStatic("nmg_forum_deleteGameCharacter", characterId, handlerNum);
        }

        public void RequestGameCharacter(string characterID, ForumGuild.RequestGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetRequestGameCharacterDelegate(callback);
            androidClass.CallStatic("nmg_forum_requestGameCharacter", characterID, handlerNum);
        }

        public void OfficialCafeId(ForumGuild.OfficialCafeIdDelegate callback)
        {
            int handlerNum = forumCallback.SetOfficialCafeIdDelegate(callback);
            androidClass.CallStatic("nmg_forum_officialCafeId", handlerNum);
        }
    }
}
#endif