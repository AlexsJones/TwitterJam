using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttPlace : ITwitterPlace
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string FullName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlaceType { get; set; }
    }
}