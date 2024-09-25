using Lokcshot.Bannwords.API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lokcshot.Bannwords.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryBannedWordsController : ControllerBase
    {
        private readonly ICountryBannedWordsService _bannedWordsServise;

        public CountryBannedWordsController(ICountryBannedWordsService bannedWordsService)
        {
            _bannedWordsServise = bannedWordsService;
        }

        [HttpGet("{countryId}")]
        public async Task<ActionResult<IEnumerable<BanwordGetModel>>> GetCountryBannedWords(Guid countryId)
        {

            var countryBannedWords = await _bannedWordsServise.GetByCountryIdAsync(countryId);

            if (countryBannedWords == null)
            {
                return NotFound();
            }

            return Ok(countryBannedWords);

        }

        [HttpPost("{countryId}")]
        public async Task<IActionResult> PostCountryBannedWords(BanwordRequestModel word, Guid countryId)
        {

            var result = await _bannedWordsServise.AddAsync(word, countryId);

            if (result == false)
            {
                return BadRequest("Its contains");
            }

            return Ok();

        }

        [HttpPut("{countryId}")]
        public async Task<IActionResult> UpdateCountryBannedWords(BanwordRequestPutModel newWord, Guid countryId)
        {

            var result = await _bannedWordsServise.UpdateAsync(newWord, countryId);

            if (result == false)
            {
                return BadRequest("Its contains");
            }

            return Ok();

        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> DeleteCountryBannedWords(BanwordRequestModel banword, Guid countryId)
        {

            await _bannedWordsServise.DeleteAsync(banword, countryId);
            return NoContent();

        }
    }
}
