using Lokcshot.Bannwords.Models.Countries.Responses;

namespace Lokcshot.Bannwords.API.Core.Interfaces
{
    public interface ICountryService
    {

        Task<IEnumerable<CountryGetModel>> GetAllCountriesAsync();

    }
}
