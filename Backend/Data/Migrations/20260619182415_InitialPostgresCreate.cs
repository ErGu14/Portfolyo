using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgresCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AdSoyad = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdSoyad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Konu = table.Column<string>(type: "text", nullable: false),
                    Mesaj = table.Column<string>(type: "text", nullable: false),
                    OkunduMu = table.Column<bool>(type: "boolean", nullable: false),
                    GondermeTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecentTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentTechnologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: false),
                    Items = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Baslik = table.Column<string>(type: "text", nullable: false),
                    Kurum = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    AlmaTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AktifMi = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Baslik = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: true),
                    Teknolojiler = table.Column<string>(type: "text", nullable: false),
                    Resim = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AktifMi = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdSoyad = table.Column<string>(type: "text", nullable: false),
                    Unvan = table.Column<string>(type: "text", nullable: false),
                    Hakkimda = table.Column<string>(type: "text", nullable: false),
                    CvPath = table.Column<string>(type: "text", nullable: false),
                    ProfilFoto = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlatformAd = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdSoyad", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "Eray Gülüçmen", "d354e5e5-865f-4f42-b6b0-f1d3f1a8839e", "eray@mail.com", true, false, null, "ERAY@MAIL.COM", "ERAY@MAIL.COM", "AQAAAAIAAYagAAAAEM/z9aGPJEuG4CK/WRfdsD4QrrG+69XyiJjGFKXELWvOAnFUEAvgJv+IqKZycyRwjQ==", null, false, "7d99ecd6-9c3d-413d-93e6-2cfd5d1e6435", false, "eray@mail.com" });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "IconPath", "IsActive", "Title" },
                values: new object[] { 1, "Yazılımcı olmanın ötesinde, 15 yıllık köklü donanım bilgisiyle bilgisayarın çalışma prensibini donanım seviyesinde anlıyorum. Server optimizasyonları ve ağ mimarisi konularında yüksek tecrübeye sahibim.", "fas fa-server", true, "Sistem & Donanım" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AdSoyad", "Email", "GondermeTarihi", "Konu", "Mesaj", "OkunduMu" },
                values: new object[] { 1, "Hoca / Danışman", "hoca@universite.edu.tr", new DateTime(2026, 6, 19, 21, 24, 15, 212, DateTimeKind.Local).AddTicks(468), "Proje Değerlendirmesi", "Eray, projelerindeki mimari yaklaşımın ve temiz kod prensiplerine uyumun gerçekten çok başarılı. Portfolyon harika görünüyor, başarılarının devamını dilerim.", false });

            migrationBuilder.InsertData(
                table: "RecentTechnologies",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "C# & .NET 8" },
                    { 2, true, "Entity Framework Core" },
                    { 3, true, "Blazor WebAssembly" },
                    { 4, true, "MS SQL Server" },
                    { 5, true, "RESTful API Geliştirme" },
                    { 6, true, "JWT & Identity Auth" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "IconPath", "IsActive", "Items", "Title" },
                values: new object[,]
                {
                    { 1, "fas fa-database", true, "C# 12 / .NET 8\nASP.NET Core Web API\nEntity Framework Core\nMS SQL Server & T-SQL\nLINQ & Asynchronous Programming\nClean Architecture & SOLID\nJWT Authentication & Identity", "Backend & API" },
                    { 2, "fas fa-desktop", true, "Blazor WebAssembly / Server\nReact.js & Next.js\nHTML5, CSS3, JavaScript (ES6+)\nBootstrap 5 & Tailwind CSS\nUI/UX Prensipleri\nResponsive (Mobil Uyumlu) Tasarım\nDOM Manüpilasyonu & Animations", "Frontend & UI" },
                    { 3, "fas fa-tools", true, "Git & GitHub\nVisual Studio & VS Code\nPostman & Swagger (API Testing)\nSistem Mimarisi Kurulumu\nAğ (Network) Yapılandırması\nİleri Seviye Donanım Optimizasyonu\nAgile / Scrum Metodolojileri", "Araçlar & Diğer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "AktifMi", "AlmaTarihi", "Baslik", "Kurum", "Path", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "International Software Expertise", "Infotech Academy", "/pdfs/InfotechAcademy_InternationalSoftwareExpertise_2025.pdf", "1" },
                    { 2, true, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzmanlığı Eğitimi", "Mudanya Üniversitesi", "/pdfs/MudanyaUniversitesi_YazilimUzmanligi_2025.pdf", "1" },
                    { 3, true, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzmanlığı (MSCD)", "Infotech Academy", "/pdfs/InfotechAcademy_YazilimUzmanligiMSCD_2025.pdf", "1" },
                    { 4, true, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ReactJS ile Front-End Uygulamaları Geliştirme", "Infotech Academy", "/images/InfotechAcademy_ReactJSFrontEnd_2025.jpg", "1" },
                    { 5, true, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzmanlığı (MSCD)", "Infotech Academy", "/images/InfotechAcademy_YazilimUzmanligiMSCD_2025.jpg", "1" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Aciklama", "AktifMi", "Baslik", "EklemeTarihi", "Link", "Resim", "Teknolojiler", "UserId" },
                values: new object[,]
                {
                    { 1, "TikTok ajans yönetimi için geliştirilen devasa ölçekli bir portal. Kompleks veritabanı şemalarının tasarımı, rol bazlı yetkilendirme altyapısı ve gelişmiş raporlama özellikleri ile ajansın tüm operasyonel yükünü hafifleten bir backend mimarisi kurgulandı.", true, "Black Ajans Yönetim Portalı", new DateTime(2026, 6, 19, 21, 24, 15, 212, DateTimeKind.Local).AddTicks(281), "", "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", "C#, .NET 8 API, MSSQL, Identity", "1" },
                    { 2, "Yapay zeka algoritmalarıyla çalışan yenilikçi kıyafet deneme uygulamasının backend servisleri. Fotoğraf işleme kuyrukları (RabbitMQ), mikroservis mimarisi ve yüksek trafikli anlık bildirim altyapısı kodlandı.", true, "Sanal Kabin (Virtual Try-On)", new DateTime(2026, 6, 19, 21, 24, 15, 212, DateTimeKind.Local).AddTicks(305), "", "https://images.unsplash.com/photo-1526628953301-3e589a6a8b74?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", "Flutter, Python AI, RabbitMQ, .NET Core", "1" },
                    { 3, "Modern bir e-ticaret uygulamasının uçtan uca gelişimi. Sepet yönetimi, güvenli ödeme (Iyzico) entegrasyonu, sipariş takip durumu ve detaylı admin paneli ile baştan sona temiz kod (Clean Architecture) prensipleriyle yazıldı.", true, "KumanStore", new DateTime(2026, 6, 19, 21, 24, 15, 212, DateTimeKind.Local).AddTicks(307), "https://github.com/ErGu14/KumanStore", "https://images.unsplash.com/photo-1556742049-0cfed4f6a45d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", ".NET 8, Blazor WASM, Iyzico API, Clean Arch", "1" },
                    { 4, "Güvenli ve hızlı e-ödeme altyapısı sistemi. REST API üzerinden bakiye yönetimi, işlem geçmişi ve sanal POS simülasyonu özellikleri barındırır.", true, "KumanPay", new DateTime(2026, 6, 19, 21, 24, 15, 212, DateTimeKind.Local).AddTicks(309), "https://github.com/ErGu14/KumanPay", "https://images.unsplash.com/photo-1563013544-824ae1b704d3?ixlib=rb-4.0.3&auto=format&fit=crop&w=1200&q=80", ".NET 8, Web API, MSSQL", "1" }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "AdSoyad", "CvPath", "Hakkimda", "ProfilFoto", "Unvan", "UserId" },
                values: new object[] { 1, "Eray Gülüçmen", "/cv/Eray_Gulucmen_CV_TR.pdf", "Modern backend teknolojileri (.NET ekosistemi, C#) ile ölçeklenebilir yazılımlar geliştiren; aynı zamanda 15+ yıllık köklü donanım geçmişiyle sistem mimarisi, ağ temelleri ve ileri seviye bilgisayar optimizasyonu konularına tam hakim bir teknoloji adayıyım. Yazılım geliştirme vizyonumu, derin IT ve donanım yapılandırma bilgisiyle harmanlayarak, uçtan uca hızlı ve yenilikçi çözümler üretmeyi hedefliyorum. İstanbul Bilgi Üniversitesi'nde Bilgisayar Programcılığı okuyorum. En büyük hedefim Senior Full Stack Yazılımcı olmaktır.", "/images/foto.jpg", "Yazılım Geliştirici.,.NET Backend Uzmanı.,Sistem Mimarı.,Donanım Uzmanı.,Veritabanı Optimizasyon Uzmanı.,RESTful API Geliştiricisi.", "1" });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "IconPath", "Link", "PlatformAd", "UserId" },
                values: new object[,]
                {
                    { 1, "fab fa-linkedin", "https://linkedin.com/in/eray-gulucmen-704b0a32a", "LinkedIn", "1" },
                    { 2, "fab fa-github", "https://github.com/ErGu14", "GitHub", "1" },
                    { 3, "fas fa-briefcase", "https://bionluk.com/kumanstack", "Bionluk", "1" },
                    { 4, "fab fa-instagram", "https://instagram.com", "Instagram", "1" },
                    { 5, "fab fa-tiktok", "https://tiktok.com", "TikTok", "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UserId",
                table: "Certificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_UserId",
                table: "SiteSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UserId",
                table: "SocialMedias",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "RecentTechnologies");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
