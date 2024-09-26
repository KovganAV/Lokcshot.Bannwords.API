using AutoMapper;
using Lokcshot.Bannwords.Models.Banwords.Requests;
using Lokcshot.Bannwords.Models.Banwords.Responses;
using Lokcshot.Bannwords.Models.Countries.Responses;
using Lokcshot.Bannwords.API.Core.Interfaces;
using Lokcshot.Bannwords.Data.Entities;
using Lokcshot.Bannwords.Data.Repositories;
using Lokcshot.Bannwords.Data.DataBaseContext;
using Lokcshot.Bannwords.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Lokcshot.Bannwords.API.Core.Service
{
    public class CountryServise : ICountryService
    {

        private readonly IMapper _mapper;
        private readonly BaseRepository<CountryEntity> _countryRepository;

        public CountryServise(BaseRepository<CountryEntity> repository, IMapper mapper)
        {
            _countryRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryGetModel>> GetAllCountriesAsync()
        {
            var countryEntities = await _countryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryEntity>, IEnumerable<CountryGetModel>>(countryEntities);
        }

    }
}
