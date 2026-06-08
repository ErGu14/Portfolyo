using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SiteSettings
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;
        public string Hakkimda { get; set; } = null!;
        public string CvPath { get; set; }
        public string? ProfilFoto { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
       
    }
}
