using System;
using System.Linq;
using LinqToTwitter;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttService : ITwitterService
    {
        private readonly ITwitterStatusFeed _statusFeed;
        private ITwitterAuthorizer _authorizer;
        private bool isAuthorized = false;

        public LttService(ITwitterStatusFeed statusFeed,
            ITwitterAuthorizer authorizer)
        {
            _statusFeed = statusFeed;
            _authorizer = authorizer;
        }

        public void Authorise(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret)
        {

           isAuthorized  =  _authorizer.Authorise(consumerKey, consumerSecret, accessToken, accessTokenSecret);

        }

        public ITwitterStatusFeed FetchTimeLine()
        {
            if (!isAuthorized)
                {
                    throw new Exception("Not Authorized");
            }

            var twitterContext = (TwitterContext)_authorizer.FetchContext();

            var tweets = from tweet in twitterContext.Status
                where tweet.Type == StatusType.Home &&
                      tweet.Count == 200
                select tweet;

            foreach (var tweet in tweets)
            {
                var place = new LttPlace
                {
                    Country = tweet.Place.Country,
                    CountryCode = tweet.Place.CountryCode,
                    FullName = tweet.Place.FullName,
                    Id = tweet.Place.ID,
                    PlaceType = tweet.Place.PlaceType
                };

                var user = new LttUser
                {
                    Count = tweet.User.Count,
                    CreatedAt = tweet.User.CreatedAt,
                    Cursor = tweet.User.Cursor,
                    FavoritesCount = tweet.User.FavoritesCount,
                    FollowRequestSent = tweet.User.FollowRequestSent,
                    FollowersCount = tweet.User.FollowersCount,
                    Following = tweet.User.Following,
                    FriendsCount = tweet.User.FriendsCount,
                    GeoEnabled = tweet.User.GeoEnabled,
                    Location = tweet.User.Location,
                    Name = tweet.User.Name,
                    ScreenName = tweet.User.ScreenName,
                    UserId = tweet.User.UserID,
                    UserIdList = tweet.User.UserIdList,
                    UserIdResponse = tweet.User.UserIDResponse
                };

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
                        Place = place,
                        PossiblySensitive = tweet.PossiblySensitive,
                        RetweetCount = tweet.RetweetCount,
                        Retweeted = tweet.Retweeted,
                        Scopes = tweet.Scopes,
                        ScreenName = tweet.ScreenName,
                        Source = tweet.Source,
                        StatusId = tweet.StatusID,
                        Text = tweet.Text,
                        TweetIDs = tweet.TweetIDs,
                        User = user,
                        UserId = tweet.UserID,
                        Users = tweet.Users
                    }
                    );
            }
            return _statusFeed;
        }
    }
}