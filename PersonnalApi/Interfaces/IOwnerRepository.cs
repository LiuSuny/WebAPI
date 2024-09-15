using PersonnalApi.Models;

namespace PersonnalApi.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnerFromACountry(int countryId);
        bool CountryExists(int id);
    }
}
