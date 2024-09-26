using AutoMapper;
using Lokcshot.Bannwords.Models.Banwords.Requests;
using Lokcshot.Bannwords.Models.Countries.Responses;
using Lokcshot.Bannwords.Models.Banwords.Responses;
using Lokcshot.Bannwords.API.Core.Interfaces;
using Lokcshot.Bannwords.Data.Entities;
using Lokcshot.Bannwords.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Lokcshot.Bannwords.API.Core.Service
{
    public class CountryBannedWordsService : ICountryBannedWordsService
    {

        private readonly CountryBannedWordsRepository _bannedWordsRepository;
        private readonly IMapper _mapper;

        public CountryBannedWordsService(CountryBannedWordsRepository bannedWordsRepository, IMapper mapper)
        {
            _bannedWordsRepository = bannedWordsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryBannedWordsEntity>> GetAllAsync()
        {

            return await _bannedWordsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<BanwordGetModel>> GetByCountryIdAsync(Guid countryId)
        {

            var currentEntity = await _bannedWordsRepository.GetByCountryIdAsync(countryId);

            if (currentEntity == null)
            {
                return null;
            }

            var currentList = currentEntity.BannedWords;
            List<BanwordGetModel> banwordGetModels = new List<BanwordGetModel>();

            for (var i = 0; i < currentList.Count(); i++)
            {
                banwordGetModels.Add(new BanwordGetModel { Content = currentList[i] });
            }

            return banwordGetModels;

        }

        public async Task<bool> AddAsync(Lokcshot.Bannwords.Models.Banwords.Requests.BanwordRequestModel countryBannedWords, Guid countryId)
        {

            var current = _bannedWordsRepository.GetByCountryIdAsync(countryId).Result;

            if (current == null)
            {
                current = new CountryBannedWordsEntity();
                current.CountryId = countryId;
                await _bannedWordsRepository.AddAsync(current);
            }

            if (_bannedWordsRepository.FindWordAsync(current, countryBannedWords.Content).Result == true)
            {
                return false;
            }

            await _bannedWordsRepository.AddOneWordAsync(current, countryBannedWords.Content);

            return true;
        }

        public async Task<bool> UpdateAsync(BanwordRequestPutModel newWord, Guid countryId)
        {

            var current = await _bannedWordsRepository.GetByCountryIdAsync(countryId);

            if (current == null)
            {
                return false;
            }

            if (_bannedWordsRepository.FindWordAsync(current, newWord.Content).Result == true)
            {
                return false;
            }

            await _bannedWordsRepository.UpdateOneWodsAsync(current, newWord);

            return true;

        }

        public async Task<bool> DeleteAsync(BanwordRequestModel banword, Guid countryId)
        {

            var current = await _bannedWordsRepository.GetByCountryIdAsync(countryId);

            if (current == null)
            {
                return false;
            }

            await _bannedWordsRepository.DeleteOneWordAsync(current, banword.Content);

            return true;

        }
    }
}
