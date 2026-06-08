using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string? Aciklama { get; set; }
        public string Teknolojiler { get; set; }
        public string? Resim { get; set; }
        public string? Link { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
