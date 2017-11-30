using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface ITownService
    {
        Town Create(string townName, string countryName);

        Town ByName(string name);
    }
}
