using System.Collections.Generic;

namespace TwitterJam.Interfaces
{
    public interface ITwitterService
    {
        bool Authorise(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret);

        ITwitterStatusFeed FetchTimeLine();
    }
}