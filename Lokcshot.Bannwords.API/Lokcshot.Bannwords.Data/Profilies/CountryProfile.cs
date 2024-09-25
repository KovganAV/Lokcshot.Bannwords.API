using Lokcshot.Bannwords.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lokcshot.Bannwords.Data.Profilies
{
    public class CountryProfile : Profile
    {

        public CountryProfile()
        {
            CreateMap<CountryEntity, CountryGetModel>();
        }

    }
}
