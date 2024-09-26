using Lokcshot.Bannwords.API.Core.Interfaces;
using Lokcshot.Bannwords.Models.Countries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Lokcshot.Bannwords.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryGetModel>>> GetAllCountries()
        {

            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);

        }

    }
}
