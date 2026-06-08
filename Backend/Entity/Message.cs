using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Konu { get; set; } = null!;
        public string Mesaj { get; set; } = null!;
        public bool OkunduMu { get; set; }
        public DateTime GondermeTarihi { get; set; } = DateTime.UtcNow;

    }
}
