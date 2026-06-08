using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AppUser : IdentityUser
    {
        public string AdSoyad { get; set; } = null!;

        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
        public SiteSettings SiteSettings { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
