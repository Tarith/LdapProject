using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageTestSite2.Models
{
    public class ProfileViewModel
    {
        public string UniqueIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public ICollection<string> MemberOf { get; set; }
    }
}
