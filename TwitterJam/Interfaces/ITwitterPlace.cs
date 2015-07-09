namespace TwitterJam.Interfaces
{
    public interface ITwitterPlace
    {
        string Country { get; set; }
        string CountryCode { get; set; }
        string FullName { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        string PlaceType { get; set; }
    }
}