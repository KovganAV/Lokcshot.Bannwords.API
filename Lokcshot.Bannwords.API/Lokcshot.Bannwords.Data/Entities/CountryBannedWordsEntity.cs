using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokcshot.Bannwords.Data.Entities
{
    internal class CountryBannedWordsEntity
    {
        public List<string>? BannedWords { get; set; } = new List<string>();
        public Guid CountryId { get; set; }
        public virtual CountryEntity? Country { get; set; }

    }
}
