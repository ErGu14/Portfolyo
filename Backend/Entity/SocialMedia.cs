using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string PlatformAd { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string IconPath { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
