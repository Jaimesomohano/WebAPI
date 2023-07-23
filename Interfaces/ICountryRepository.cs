using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int id);
        ICollection<Owner> GetOwnerByCountry(int id);
        bool CountryExists(int id);
    }
}
