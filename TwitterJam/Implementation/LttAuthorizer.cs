using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttAuthorizer : ITwitterAuthorizer
    {
        private SingleUserAuthorizer _auth = null;

        public IDisposable FetchContext()
        {
            if (_auth == null)
            {
                throw new Exception("Not Authorized");
            }
            return new TwitterContext(_auth);
        }

        public bool Authorise(string consumerKey, string consumerSecret,
            string accessToken, string accessTokenSecret)
        {
            _auth = new SingleUserAuthorizer
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
            return true;
        }
    }
}
