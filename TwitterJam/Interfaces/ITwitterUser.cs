using System;

namespace TwitterJam.Interfaces
{
    public interface ITwitterUser
    {
        int Count { get; set; }
        DateTime CreatedAt { get; set; }
        long Cursor { get; set; }
        int FavoritesCount { get; set; }
        int FollowersCount { get; set; }
        bool Following { get; set; }
        bool FollowRequestSent { get; set; }
        int FriendsCount { get; set; }
        bool GeoEnabled { get; set; }
        string Location { get; set; }
        string Name { get; set; }
        bool Notifications { get; set; }
        int Page { get; set; }
        string ScreenName { get; set; }
        string Url { get; set; }
        ulong UserId { get; set; }
        string UserIdList { get; set; }
        string UserIdResponse { get; set; }
        bool Verified { get; set; }
    }
}