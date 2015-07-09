using System;
using System.Collections.Generic;

namespace TwitterJam.Interfaces
{
    public interface ITwitterStatusInformation
    {
        int Count { get; set; }
        DateTime CreatedAt { get; set; }
        ulong CurrentUserRetweet { get; set; }
        bool ExcludeReplies { get; set; }
        bool Favorited { get; set; }
        ulong Id { get; set; }
        bool IncludeContributorDetails { get; set; }
        bool IncludeEntities { get; set; }
        bool IncludeMyRetweet { get; set; }
        bool IncludeRetweets { get; set; }
        bool IncludeUserEntities { get; set; }
        string InReplyToScreenName { get; set; }
        ulong InReplyToStatusId { get; set; }
        ulong InReplyToUserId { get; set; }
        string Lang { get; set; }
        ITwitterPlace Place { get; set; }
        bool PossiblySensitive { get; set; }
        int RetweetCount { get; set; }
        bool Retweeted { get; set; }
        Dictionary<string, string> Scopes { get; set; }
        string ScreenName { get; set; }
        ulong SinceId { get; set; }
        string Source { get; set; }
        ulong StatusId { get; set; }
        string Text { get; set; }
        string TweetIDs { get; set; }
        ITwitterUser User { get; set; }
        ulong UserId { get; set; }
        List<ulong> Users { get; set; }
    }
}