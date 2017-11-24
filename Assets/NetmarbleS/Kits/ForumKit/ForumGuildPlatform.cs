namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class ForumGuildPlatform : IForumGuild
    {
        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }

        public void IsNews(ForumCommunityType forumCommunityType, string characterId, ForumGuild.IsNewsDelegate callback)
        {
            
        }

        public void CreateGuildArticle(string guildId, string forumArticleParameter, ForumGuild.CreateArticleDelegate callback)
        {
            
        }

        public void CreateGamePlayer(string forumPlayerParameter, ForumGuild.CreateGamePlayerDelegate callback)
        {
            
        }

        public void UpdateGamePlayer(string forumPlayerParameter, ForumGuild.UpdateGamePlayerDelegate callback)
        {
            
        }

        public void RequestGamePlayer(ForumGuild.RequestGamePlayerDelegate callback)
        {
            
        }

        public void CreateGuildMember(string forumCharacterParameter, int guildMemberCount, ForumGuild.CreateGuildMemberDelegate callback)
        {
            
        }

        public void WithdrawGuildMember(string guildId, string characterId, int guildMemberCount, ForumGuild.WithdrawUserDelegate callback)
        {
            
        }

        public void CheckGuildExistence(string guildId, ForumGuild.CheckGuildExistenceDelegate callback)
        {
            
        }

        public void CreateGuild(string forumGuildParameter, ForumGuild.CreateGuildDelegate callback)
        {
            
        }

        public void UpdateGuild(string forumGuildParameter, ForumGuild.UpdateGuildInfoDelegate callback)
        {
            
        }

		public void CloseGuild(string guildId, string characterId, ForumGuild.CloseGuildDelegate callback)
        {
            
        }

        public void CreateGameCharacter(string forumCharacterParameter, ForumGuild.CreateGameCharacterDelegate callback)
        {
            
        }

        public void UpdateGameCharacter(string forumCharacterParameter, ForumGuild.UpdateGameCharacterDelegate callback)
        {
            
        }

        public void DeleteGameCharacter(string characterId, ForumGuild.DeleteGameCharacterDelegate callback)
        {
            
        }

        public void RequestGameCharacter(string characterID, ForumGuild.RequestGameCharacterDelegate callback)
        {
            
        }

        public void OfficialCafeId(ForumGuild.OfficialCafeIdDelegate callback)
        {
            
        }
    }
}