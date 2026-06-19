# 1. Aşama: Çalışma Zamanı (Runtime) İmajı
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Render web servisleri genellikle 80 veya 8080 portunu dinler
USER app
WORKDIR /app
EXPOSE 8080

# 2. Aşama: Derleme (Build) İmajı ve Restore İşlemi
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Çözüm içerisindeki sadece Backend'e ait katmanların proje (.csproj) dosyalarını kopyalıyoruz.
# Amacımız projedeki değişiklikler olmadan (sadece paket güncellemelerinde) bu katmanın önbelleğe alınmasıdır.
COPY ["Backend/PortfolioBackend/PortfolioBackend.csproj", "Backend/PortfolioBackend/"]
COPY ["Backend/Businness/Businness.csproj", "Backend/Businness/"]
COPY ["Backend/Data/Data.csproj", "Backend/Data/"]
COPY ["Backend/Entity/Entity.csproj", "Backend/Entity/"]
COPY ["Backend/Service/Service.csproj", "Backend/Service/"]

# Sadece Backend projesinin restore (paket indirme) işlemini çalıştırıyoruz (Frontend dahil edilmez)
RUN dotnet restore "Backend/PortfolioBackend/PortfolioBackend.csproj"

# Tüm Backend klasöründeki kaynak kodlarını içeri kopyalıyoruz
COPY Backend/ Backend/

# Klasör dizinini Backend ana projesinin içine ayarlayıp derliyoruz
WORKDIR "/src/Backend/PortfolioBackend"
RUN dotnet build "PortfolioBackend.csproj" -c Release -o /app/build

# 3. Aşama: Publish (Yayın) Dosyalarını Oluşturma
FROM build AS publish
RUN dotnet publish "PortfolioBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Aşama: Son imajın hazırlanması (Hafif ASP.NET imajına publish dosyalarının aktarılması)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Uygulamanın başlayacağı DLL dosyası
ENTRYPOINT ["dotnet", "PortfolioBackend.dll"]
