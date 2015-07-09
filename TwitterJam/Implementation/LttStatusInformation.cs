using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttStatusInformation : ITwitterStatusInformation
    {
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public ulong CurrentUserRetweet { get; set; }
        public bool ExcludeReplies { get; set; }
        public bool Favorited { get; set; }
        public ulong Id { get; set; }
        public bool IncludeContributorDetails { get; set; }
        public bool IncludeEntities { get; set; }
        public bool IncludeMyRetweet { get; set; }
        public bool IncludeRetweets { get; set; }
        public bool IncludeUserEntities { get; set; }
        public string InReplyToScreenName { get; set; }
        public ulong InReplyToStatusId { get; set; }
        public ulong InReplyToUserId { get; set; }
        public string Lang { get; set; }
        public ITwitterPlace Place { get; set; }
        public bool PossiblySensitive { get; set; }
        public int RetweetCount { get; set; }
        public bool Retweeted { get; set; }
        public Dictionary<string, string> Scopes { get; set; }
        public string ScreenName { get; set; }
        public ulong SinceId { get; set; }
        public string Source { get; set; }
        public ulong StatusId { get; set; }
        public string Text { get; set; }
        public string TweetIDs { get; set; }
        public ITwitterUser User { get; set; }
        public ulong UserId { get; set; }
        public List<ulong> Users { get; set; }
    }
}
