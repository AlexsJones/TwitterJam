using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterJam.Interfaces
{
    public interface ITwitterAuthorizer
    {
        bool Authorise(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret);

        IDisposable FetchContext();
    }
}
