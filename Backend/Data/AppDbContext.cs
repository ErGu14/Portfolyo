using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RecentTechnology> RecentTechnologies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasMany(u => u.Certificates)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            builder.Entity<AppUser>()
                .HasMany(u => u.SocialMedias)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
            builder.Entity<AppUser>()
                .HasOne(u => u.SiteSettings)
                .WithOne(s => s.AppUser)
                .HasForeignKey<SiteSettings>(s => s.UserId);
            builder.Entity<AppUser>()
                .HasMany(u => u.Projects)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            var adminRoleId = "1";
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<AppUser>();
            var userId = "1";
            var user = new AppUser
            {
                Id = userId,
                AdSoyad = "Eray Gülüçmen",
                UserName = "eray@mail.com",
                NormalizedUserName = "ERAY@MAIL.COM",
                Email = "eray@mail.com",
                NormalizedEmail = "ERAY@MAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            
            user.PasswordHash = hasher.HashPassword(user, "Admin123!*");

            builder.Entity<AppUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });

            builder.Entity<SiteSettings>().HasData(new SiteSettings
            {
                Id = 1,
                AdSoyad = "Eray Gülüçmen",
                Unvan = "Yazılım Geliştirici.,.NET Backend Uzmanı.,Sistem Mimarı.,Donanım Uzmanı.,Veritabanı Optimizasyon Uzmanı.,RESTful API Geliştiricisi.",
                Hakkimda = "Modern backend teknolojileri (.NET ekosistemi, C#) ile ölçeklenebilir yazılımlar geliştiren; aynı zamanda 15+ yıllık köklü donanım geçmişiyle sistem mimarisi, ağ temelleri ve ileri seviye bilgisayar optimizasyonu konularına tam hakim bir teknoloji adayıyım. Yazılım geliştirme vizyonumu, derin IT ve donanım yapılandırma bilgisiyle harmanlayarak, uçtan uca hızlı ve yenilikçi çözümler üretmeyi hedefliyorum. İstanbul Bilgi Üniversitesi'nde Bilgisayar Programcılığı okuyorum. En büyük hedefim Senior Full Stack Yazılımcı olmaktır.",
                CvPath = "/cv/Eray_Gulucmen_CV_TR.pdf",
                ProfilFoto = "/images/foto.jpg",
                UserId = userId
            });

            builder.Entity<SocialMedia>().HasData(
                new SocialMedia { Id = 1, PlatformAd = "LinkedIn", Link = "https://linkedin.com/in/eray-gulucmen-704b0a32a", IconPath = "fab fa-linkedin", UserId = userId },
                new SocialMedia { Id = 2, PlatformAd = "GitHub", Link = "https://github.com/ErGu14", IconPath = "fab fa-github", UserId = userId },
                new SocialMedia { Id = 3, PlatformAd = "Bionluk", Link = "https://bionluk.com/kumanstack", IconPath = "fas fa-briefcase", UserId = userId },
                new SocialMedia { Id = 4, PlatformAd = "Instagram", Link = "https://instagram.com", IconPath = "fab fa-instagram", UserId = userId },
                new SocialMedia { Id = 5, PlatformAd = "TikTok", Link = "https://tiktok.com", IconPath = "fab fa-tiktok", UserId = userId }
            );

            builder.Entity<Project>().HasData(
                new Project { Id = 1, Baslik = "Black Ajans Yönetim Portalı", Aciklama = "TikTok ajans yönetimi için geliştirilen devasa ölçekli bir portal. Kompleks veritabanı şemalarının tasarımı, rol bazlı yetkilendirme altyapısı ve gelişmiş raporlama özellikleri ile ajansın tüm operasyonel yükünü hafifleten bir backend mimarisi kurgulandı.", Teknolojiler = "C#, .NET 8 API, MSSQL, Identity", Link = "", Resim = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", EklemeTarihi = DateTime.Now, AktifMi = true, UserId = userId },
                new Project { Id = 2, Baslik = "Sanal Kabin (Virtual Try-On)", Aciklama = "Yapay zeka algoritmalarıyla çalışan yenilikçi kıyafet deneme uygulamasının backend servisleri. Fotoğraf işleme kuyrukları (RabbitMQ), mikroservis mimarisi ve yüksek trafikli anlık bildirim altyapısı kodlandı.", Teknolojiler = "Flutter, Python AI, RabbitMQ, .NET Core", Link = "", Resim = "https://images.unsplash.com/photo-1526628953301-3e589a6a8b74?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", EklemeTarihi = DateTime.Now, AktifMi = true, UserId = userId },
                new Project { Id = 3, Baslik = "KumanStore", Aciklama = "Modern bir e-ticaret uygulamasının uçtan uca gelişimi. Sepet yönetimi, güvenli ödeme (Iyzico) entegrasyonu, sipariş takip durumu ve detaylı admin paneli ile baştan sona temiz kod (Clean Architecture) prensipleriyle yazıldı.", Teknolojiler = ".NET 8, Blazor WASM, Iyzico API, Clean Arch", Link = "https://github.com/ErGu14/KumanStore", Resim = "https://images.unsplash.com/photo-1556742049-0cfed4f6a45d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", EklemeTarihi = DateTime.Now, AktifMi = true, UserId = userId },
                new Project { Id = 4, Baslik = "KumanPay", Aciklama = "Güvenli ve hızlı e-ödeme altyapısı sistemi. REST API üzerinden bakiye yönetimi, işlem geçmişi ve sanal POS simülasyonu özellikleri barındırır.", Teknolojiler = ".NET 8, Web API, MSSQL", Link = "https://github.com/ErGu14/KumanPay", Resim = "https://images.unsplash.com/photo-1563013544-824ae1b704d3?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", EklemeTarihi = DateTime.Now, AktifMi = true, UserId = userId }
            );

            builder.Entity<Certificate>().HasData(
                new Certificate { Id = 1, Kurum = "Infotech Academy", Baslik = "International Software Expertise", AlmaTarihi = new DateTime(2025, 1, 10), Path = "/pdfs/InfotechAcademy_InternationalSoftwareExpertise_2025.pdf", AktifMi = true, UserId = userId },
                new Certificate { Id = 2, Kurum = "Mudanya Üniversitesi", Baslik = "Yazılım Uzmanlığı Eğitimi", AlmaTarihi = new DateTime(2025, 7, 2), Path = "/pdfs/MudanyaUniversitesi_YazilimUzmanligi_2025.pdf", AktifMi = true, UserId = userId },
                new Certificate { Id = 3, Kurum = "Infotech Academy", Baslik = "Yazılım Uzmanlığı (MSCD)", AlmaTarihi = new DateTime(2025, 1, 10), Path = "/pdfs/InfotechAcademy_YazilimUzmanligiMSCD_2025.pdf", AktifMi = true, UserId = userId },
                new Certificate { Id = 4, Kurum = "Infotech Academy", Baslik = "ReactJS ile Front-End Uygulamaları Geliştirme", AlmaTarihi = new DateTime(2025, 5, 2), Path = "/images/InfotechAcademy_ReactJSFrontEnd_2025.jpg", AktifMi = true, UserId = userId },
                new Certificate { Id = 5, Kurum = "Infotech Academy", Baslik = "Yazılım Uzmanlığı (MSCD)", AlmaTarihi = new DateTime(2025, 1, 10), Path = "/images/InfotechAcademy_YazilimUzmanligiMSCD_2025.jpg", AktifMi = true, UserId = userId }
            );

            builder.Entity<Message>().HasData(
                new Message { Id = 1, AdSoyad = "Hoca / Danışman", Email = "hoca@universite.edu.tr", Konu = "Proje Değerlendirmesi", Mesaj = "Eray, projelerindeki mimari yaklaşımın ve temiz kod prensiplerine uyumun gerçekten çok başarılı. Portfolyon harika görünüyor, başarılarının devamını dilerim.", OkunduMu = false, GondermeTarihi = DateTime.Now }
            );

            builder.Entity<RecentTechnology>().HasData(
                new RecentTechnology { Id = 1, Name = "C# & .NET 8", IsActive = true },
                new RecentTechnology { Id = 2, Name = "Entity Framework Core", IsActive = true },
                new RecentTechnology { Id = 3, Name = "Blazor WebAssembly", IsActive = true },
                new RecentTechnology { Id = 4, Name = "MS SQL Server", IsActive = true },
                new RecentTechnology { Id = 5, Name = "RESTful API Geliştirme", IsActive = true },
                new RecentTechnology { Id = 6, Name = "JWT & Identity Auth", IsActive = true }
            );

            builder.Entity<Skill>().HasData(
                new Skill { Id = 1, Title = "Backend & API", IconPath = "fas fa-database", Items = "C# 12 / .NET 8\nASP.NET Core Web API\nEntity Framework Core\nMS SQL Server & T-SQL\nLINQ & Asynchronous Programming\nClean Architecture & SOLID\nJWT Authentication & Identity", IsActive = true },
                new Skill { Id = 2, Title = "Frontend & UI", IconPath = "fas fa-desktop", Items = "Blazor WebAssembly / Server\nReact.js & Next.js\nHTML5, CSS3, JavaScript (ES6+)\nBootstrap 5 & Tailwind CSS\nUI/UX Prensipleri\nResponsive (Mobil Uyumlu) Tasarım\nDOM Manüpilasyonu & Animations", IsActive = true },
                new Skill { Id = 3, Title = "Araçlar & Diğer", IconPath = "fas fa-tools", Items = "Git & GitHub\nVisual Studio & VS Code\nPostman & Swagger (API Testing)\nSistem Mimarisi Kurulumu\nAğ (Network) Yapılandırması\nİleri Seviye Donanım Optimizasyonu\nAgile / Scrum Metodolojileri", IsActive = true }
            );

            builder.Entity<Feature>().HasData(
                new Feature { Id = 1, Title = "Sistem & Donanım", Description = "Yazılımcı olmanın ötesinde, 15 yıllık köklü donanım bilgisiyle bilgisayarın çalışma prensibini donanım seviyesinde anlıyorum. Server optimizasyonları ve ağ mimarisi konularında yüksek tecrübeye sahibim.", IconPath = "fas fa-server", IsActive = true }
            );
        }
    }
}
