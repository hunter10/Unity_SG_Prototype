namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IForumGuild
    {
        string VERSION { get; }
        void IsNews(ForumCommunityType forumCommunityType, string characterId, ForumGuild.IsNewsDelegate callback);
        void CreateGuildArticle(string guildId, string forumArticleParameter, ForumGuild.CreateArticleDelegate callback);
        void CreateGamePlayer(string forumPlayerParameter, ForumGuild.CreateGamePlayerDelegate callback);
        void UpdateGamePlayer(string forumPlayerParameter, ForumGuild.UpdateGamePlayerDelegate callback);
        void RequestGamePlayer(ForumGuild.RequestGamePlayerDelegate callback);
        void CreateGuildMember(string forumCharacterParameter, int guildMemberCount, ForumGuild.CreateGuildMemberDelegate callback);
        void WithdrawGuildMember(string guildId, string characterId, int guildMemberCount, ForumGuild.WithdrawUserDelegate callback);
        void CheckGuildExistence(string guildId, ForumGuild.CheckGuildExistenceDelegate callback);
        void CreateGuild(string forumGuildParameter, ForumGuild.CreateGuildDelegate callback);
        void UpdateGuild(string forumGuildParameter, ForumGuild.UpdateGuildInfoDelegate callback);
		void CloseGuild(string guildId, string characterId, ForumGuild.CloseGuildDelegate callback);
        void CreateGameCharacter(string forumCharacterParameter, ForumGuild.CreateGameCharacterDelegate callback);
        void UpdateGameCharacter(string forumCharacterParameter, ForumGuild.UpdateGameCharacterDelegate callback);
        void DeleteGameCharacter(string characterId, ForumGuild.DeleteGameCharacterDelegate callback);
        void RequestGameCharacter(string characterID, ForumGuild.RequestGameCharacterDelegate callback);
        void OfficialCafeId(ForumGuild.OfficialCafeIdDelegate callback);        
    }
}