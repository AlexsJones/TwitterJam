using System.Collections.Generic;

namespace TwitterJam.Interfaces
{
    public interface ITwitterService<T>
    {
        void Authorise(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret);

        List<T> FetchTimeline();
    }
}