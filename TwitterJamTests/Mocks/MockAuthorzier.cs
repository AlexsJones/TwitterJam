using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterJam.Interfaces;

namespace TwitterJamTests.Mocks
{
    public class MockContext : IDisposable
    {

        public void Dispose()
        {}
    }

    public class MockAuthorzier : ITwitterAuthorizer
    {
        public bool Authorise(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            return false;
        }

        public IDisposable FetchContext()
        {
            return new MockContext { 
            
            };
        }
    }
}
