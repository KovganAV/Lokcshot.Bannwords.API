using Lokcshot.Bannwords.Data.DataBaseContext;
using Lokcshot.Bannwords.Data.Entities;
using Lokcshot.Bannwords.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokcshot.Bannwords.Data.Repositories
{
    public class CountryBannedWordsRepository : BaseRepository<CountryBannedWordsEntity>
    {
        public CountryBannedWordsRepository(ApplicationDbContext context) : base(context) { }


        //getting dbSet that contains banwords for this Country
        public async Task<CountryBannedWordsEntity> GetByCountryIdAsync(Guid countryId)
        {
            return await _dbSet.FirstOrDefaultAsync(cbw => cbw.CountryId == countryId);
        }

        public async Task<bool> FindWordAsync(CountryBannedWordsEntity countryBannedWordsEntity, string content)
        {
            return await Task.FromResult(countryBannedWordsEntity.BannedWords.Any(s => s == content));
        }

        //add one word for list BannedWords
        public async Task<CountryBannedWordsEntity> AddOneWordAsync(CountryBannedWordsEntity countryBannedWordsEntity, string content)
        {
            countryBannedWordsEntity.BannedWords.Add(content);
            await _context.SaveChangesAsync();
            return countryBannedWordsEntity;
        }

        //update one word from list BannedWords by index
        public async Task<CountryBannedWordsEntity> UpdateOneWodsAsync(CountryBannedWordsEntity countryBannedWordsEntity, BanwordRequestPutModel word)
        {
            countryBannedWordsEntity.BannedWords[word.Index] = word.Content;
            await _context.SaveChangesAsync();
            return countryBannedWordsEntity;
        }

        //remove one word from list BannedWords
        public async Task<CountryBannedWordsEntity> DeleteOneWordAsync(CountryBannedWordsEntity countryBannedWordsEntity, string content)
        {
            countryBannedWordsEntity.BannedWords.Remove(content);
            await _context.SaveChangesAsync();
            return countryBannedWordsEntity;
        }

    }
}
