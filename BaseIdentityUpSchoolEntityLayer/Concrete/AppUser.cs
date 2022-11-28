using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseIdentityUpSchoolEntityLayer.Concrete
{
    //Key 'in otomatik artan olması için buraya paraetre olarak int verilir.
    public class AppUser: IdentityUser<int>
    {
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
    }
}
