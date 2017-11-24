#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class ForumGuildiOS : IForumGuild
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_forum_version();
        [DllImport("__Internal")]
        public static extern void nmg_forum_isNews(int forumCommunityType, string characterId, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_createGuildArticle(string guildId, string forumArticleParameter, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_createGamePlayer(string forumPlayerParameter, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_updateGamePlayer(string forumPlayerParameter, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_requestGamePlayer(int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_createGuildMember(string forumCharacterParameter, int guildMemberCount, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_withdrawGuildMember(string guildId, string characterId, int guildMemberCount, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_checkGuildExistence(string guildId, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_createGuild(string forumGuildParameter, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_updateGuild(string forumGuildParameter, int handlerNum);
        [DllImport("__Internal")]
		public static extern void nmg_forum_closeGuild(string guildId, string characterId, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_createGameCharacter(string forumCharacterParameter, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_updateGameCharacter(string forumCharacterParameter, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_deleteGameCharacter(string characterId, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_requestGameCharacter(string characterID, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_forum_officialCafeId(int handlerNum);

        private ForumCallback forumCallback;
        private string version;
        public ForumGuildiOS()
        {
            forumCallback = new ForumCallback();
            version = Marshal.PtrToStringAuto(nmg_forum_version());
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public void IsNews(ForumCommunityType forumCommunityType, string characterId, ForumGuild.IsNewsDelegate callback)
        {
            int handlerNum = forumCallback.SetIsNesDelegate(callback);
            nmg_forum_isNews((int)forumCommunityType, characterId, handlerNum);
        }

        public void CreateGuildArticle(string guildId, string forumArticleParameter, ForumGuild.CreateArticleDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateArticleDelegate(callback);
            nmg_forum_createGuildArticle(guildId, forumArticleParameter, handlerNum);
        }

        public void CreateGamePlayer(string forumPlayerParameter, ForumGuild.CreateGamePlayerDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGamePlayerDelegate(callback);
            nmg_forum_createGamePlayer(forumPlayerParameter, handlerNum);
        }

        public void UpdateGamePlayer(string forumPlayerParameter, ForumGuild.UpdateGamePlayerDelegate callback)
        {
            int handlerNum = forumCallback.SetUpdateGamePlayerDelegate(callback);
            nmg_forum_updateGamePlayer(forumPlayerParameter, handlerNum);
        }

        public void RequestGamePlayer(ForumGuild.RequestGamePlayerDelegate callback)
        {
            int handlerNum = forumCallback.SetRequestGamePlayerDelegate(callback);
            nmg_forum_requestGamePlayer(handlerNum);
        }

        public void CreateGuildMember(string forumCharacterParameter, int guildMemberCount, ForumGuild.CreateGuildMemberDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGuildMemberDelegate(callback);
            nmg_forum_createGuildMember(forumCharacterParameter, guildMemberCount, handlerNum);
        }

        public void WithdrawGuildMember(string guildId, string characterId, int guildMemberCount, ForumGuild.WithdrawUserDelegate callback)
        {
            int handlerNum = forumCallback.SetWithdrawUserDelegate(callback);
            nmg_forum_withdrawGuildMember(guildId, characterId, guildMemberCount, handlerNum);
        }

        public void CheckGuildExistence(string guildId, ForumGuild.CheckGuildExistenceDelegate callback)
        {
            int handlerNum = forumCallback.SetCheckGuildExistenceDelegate(callback);
            nmg_forum_checkGuildExistence(guildId, handlerNum);
        }

        public void CreateGuild(string forumGuildParameter, ForumGuild.CreateGuildDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGuildDelegate(callback);
            nmg_forum_createGuild(forumGuildParameter, handlerNum);
        }

        public void UpdateGuild(string forumGuildParameter, ForumGuild.UpdateGuildInfoDelegate callback)
        {
            int handlerNum = forumCallback.SetUpdateGuildInfoDelegate(callback);
            nmg_forum_updateGuild(forumGuildParameter, handlerNum);
        }

		public void CloseGuild(string guildId, string characterId, ForumGuild.CloseGuildDelegate callback)
        {
            int handlerNum = forumCallback.SetCloseGuildDelegate(callback);
			nmg_forum_closeGuild(guildId, characterId, handlerNum);
        }

        public void CreateGameCharacter(string forumCharacterParameter, ForumGuild.CreateGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetCreateGameCharacterDelegate(callback);
            nmg_forum_createGameCharacter(forumCharacterParameter, handlerNum);
        }

        public void UpdateGameCharacter(string forumCharacterParameter, ForumGuild.UpdateGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetUpdateGameCharacterDelegate(callback);
            nmg_forum_updateGameCharacter(forumCharacterParameter, handlerNum);
        }

        public void DeleteGameCharacter(string characterId, ForumGuild.DeleteGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetDeleteGameCharacterDelegate(callback);
            nmg_forum_deleteGameCharacter(characterId, handlerNum);
        }

        public void RequestGameCharacter(string characterID, ForumGuild.RequestGameCharacterDelegate callback)
        {
            int handlerNum = forumCallback.SetRequestGameCharacterDelegate(callback);
            nmg_forum_requestGameCharacter(characterID, handlerNum);
        }

        public void OfficialCafeId(ForumGuild.OfficialCafeIdDelegate callback)
        {
            int handlerNum = forumCallback.SetOfficialCafeIdDelegate(callback);
            nmg_forum_officialCafeId(handlerNum);
        }
    }
}
#endif