using Lokcshot.Bannwords.Models.Banwords.Requests;
using Lokcshot.Bannwords.Models.Banwords.Responses;
using Lokcshot.Bannwords.Data.Entities;

namespace Lokcshot.Bannwords.API.Core.Interfaces
{
    public interface ICountryBannedWordsService
    {
        Task<IEnumerable<CountryBannedWordsEntity>> GetAllAsync();
        
        Task<IEnumerable<Lokcshot.Bannwords.Models.Banwords.Responses.BanwordGetModel>> GetByCountryIdAsync(Guid countryId);

        Task<bool> AddAsync(Lokcshot.Bannwords.Models.Banwords.Requests.BanwordRequestModel countryBannedWord, Guid countryId);

        Task<bool> UpdateAsync(BanwordRequestPutModel newWord, Guid countryId);

        Task<bool> DeleteAsync(BanwordRequestModel banword, Guid countryId);
    }
}
