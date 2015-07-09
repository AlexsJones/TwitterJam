using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttUser : ITwitterUser
    {
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Cursor { get; set; }
        public int FavoritesCount { get; set; }
        public int FollowersCount { get; set; }
        public bool Following { get; set; }
        public bool FollowRequestSent { get; set; }
        public int FriendsCount { get; set; }
        public bool GeoEnabled { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public bool Notifications { get; set; }
        public int Page { get; set; }
        public string ScreenName { get; set; }
        public string Url { get; set; }
        public ulong UserId { get; set; }
        public string UserIdList { get; set; }
        public string UserIdResponse { get; set; }
        public bool Verified { get; set; }
    }
}
