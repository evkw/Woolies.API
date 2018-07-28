namespace Woolies.Abstractions.Configuration
{
    public interface IWooliesTestConfiguration
    {
        string BaseApi { get; set; }
        string Token { get; set; }
    }
}
