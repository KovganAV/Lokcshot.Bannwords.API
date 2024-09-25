using Lokcshot.Bannwords.Models.Banwords.Requests;
using Lokcshot.Bannwords.Models.Banwords.Responses;
using Lokcshot.Bannwords.Data.Entities;

namespace Lokcshot.Bannwords.API.Core.Interfaces
{
    public interface ICountryService
    {

        Task<IEnumerable<CountryGetModel>> GetAllCountriesAsync();

    }
}
