using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace TwitterJam
{
    class Program
    {
        static void Main(string[] args)
        {
           TwitterCredentials.SetCredentials("3366075040-QeUE25ewf9lzf7JlILxI01oGm9E8941oAEOLoM2", "ei8l2IzjXGmrPpL01hQnV41CZn2Gdol28FkLAsvxtca4u",
               "lO1Wvm0GejcIpMS3d4dzZvGNd ", "fuWWnbjhm37k2alOSky1MUwrm7JonDiqdVkc8wGUv4R3GdiEIg");

           var loggedUser = User.GetLoggedUser();

           var settings = loggedUser.GetAccountSettings();
        }
    }
}
