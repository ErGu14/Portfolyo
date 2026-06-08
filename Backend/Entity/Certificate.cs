using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string Kurum { get; set; }
        public string Path { get; set; }
        public DateTime AlmaTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
