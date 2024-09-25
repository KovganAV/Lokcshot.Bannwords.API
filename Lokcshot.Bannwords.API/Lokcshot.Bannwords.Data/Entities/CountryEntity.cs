using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokcshot.Bannwords.Data.Entities
{
    internal class CountryEntity
    {
        public string Name { get; set; }

        public virtual CountryBannedWordsEntity? CountryBannedWords { get; set; }
    }
}
