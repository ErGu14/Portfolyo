using Data.Abstract;
using Data.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Service.Abstract;
using Service.Concrete;

using Service.Mapping;

namespace Service
{
    public static class ServiceExtensions
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            
            services.AddAutoMapper(m => m.AddProfile<MapProfile>());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<ISiteSettingsService, SiteSettingsManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<IRecentTechnologyService, RecentTechnologyManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<IFeatureService, FeatureManager>();

            
        }
    }
}
