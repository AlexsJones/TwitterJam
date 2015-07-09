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
    public class LttService : ITwitterService<LttStatusInformation>
    {
        private SingleUserAuthorizer _authorizer;

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

        public List<LttStatusInformation> FetchTimeline()
        {
            List<LttStatusInformation> statusInformation
                = new List<LttStatusInformation>();

            var twitterContext = new TwitterContext(_authorizer);

            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home &&
                               tweet.Count == 200
                         select tweet;

            foreach (var tweet in tweets)
            {
                statusInformation.Add(
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
            return statusInformation;
        }
    }
}
