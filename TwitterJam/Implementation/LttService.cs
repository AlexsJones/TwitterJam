using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttService : ITwitterService
    {
        private SingleUserAuthorizer _authorizer;
        private readonly ITwitterStatusFeed _statusFeed;

        public LttService(ITwitterStatusFeed statusFeed)
        {
            _statusFeed = statusFeed;
        }

        public void Authorise(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret)
        {
            _authorizer = new SingleUserAuthorizer
            {
                CredentialStore =
                    new SingleUserInMemoryCredentialStore
                    {
                        ConsumerKey = consumerKey,
                        ConsumerSecret = consumerSecret,
                        AccessToken = accessToken,
                        AccessTokenSecret = accessTokenSecret
                    }
            };
        }

        public ITwitterStatusFeed FetchTimeLine()
        {
  

            var twitterContext = new TwitterContext(_authorizer);

            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home &&
                               tweet.Count == 200
                         select tweet;

            foreach (var tweet in tweets)
            {
                _statusFeed.AddItem(
                    new LttStatusInformation
                    {
                        Count = tweet.Count,
                        CreatedAt = tweet.CreatedAt,
                        CurrentUserRetweet = tweet.CurrentUserRetweet,
                        ExcludeReplies = tweet.ExcludeReplies,
                        Favorited = tweet.Favorited,
                        Id = tweet.ID,
                        IncludeContributorDetails = tweet.IncludeContributorDetails,
                        IncludeEntities = tweet.IncludeEntities,
                        IncludeMyRetweet = tweet.IncludeMyRetweet,
                        IncludeRetweets = tweet.IncludeRetweets,
                        IncludeUserEntities = tweet.IncludeUserEntities,
                        InReplyToScreenName = tweet.InReplyToScreenName,
                        InReplyToStatusId = tweet.InReplyToStatusID,
                        InReplyToUserId = tweet.InReplyToUserID,
                        Lang = tweet.Lang,
                   //     Place = tweet.Place,
                        PossiblySensitive = tweet.PossiblySensitive,
                        RetweetCount = tweet.RetweetCount,
                        Retweeted = tweet.Retweeted,
                        Scopes = tweet.Scopes,
                        ScreenName = tweet.ScreenName,
                        Source = tweet.Source,
                        StatusId = tweet.StatusID,
                        Text = tweet.Text,
                        TweetIDs = tweet.TweetIDs,
                       // User = tweet.User,
                        UserId = tweet.UserID,
                        Users = tweet.Users
                    }
                    );
            }
            return _statusFeed;
        }
    }
}
