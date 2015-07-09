using System;
using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;

namespace TwitterJam
{
    internal class Program
    {
        private static List<Status> GetMostRecent200HomeTimeLine(SingleUserAuthorizer authorizer)
        {
            var twitterContext = new TwitterContext(authorizer);

            var tweets = from tweet in twitterContext.Status
                where tweet.Type == StatusType.Home &&
                      tweet.Count == 200
                select tweet;

            return tweets.ToList();
        }

        private static void Main(string[] args)
        {
            var authorizer = new SingleUserAuthorizer
            {
                CredentialStore =
                    new SingleUserInMemoryCredentialStore
                    {
                        ConsumerKey =
                            "evRKMja4psyaHoevCVMPlCbHm",
                        ConsumerSecret =
                            "W72GjBqSZ5fQ6uVDMkMYpoDKfiqwAaOyLNMczZJKdKX3yk35Ev",
                        AccessToken =
                            "3366075040-AtwlMptYENBFVmdDtU8A08EuyoNuMRFAQmZTzzq",
                        AccessTokenSecret =
                            "ouBcNL2hawU7JUQPjrWJ1Ehai7sh3HiUUycLrXl2E2YB0"
                    }
            };

            GetMostRecent200HomeTimeLine(authorizer).ForEach(t =>
                Console.WriteLine(t.Text));
        }
    }
}