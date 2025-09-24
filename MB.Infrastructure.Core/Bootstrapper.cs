using MB.Application;
using MB.Application.Contracts.ArticleCategury;
using MB.Domain.ArticleCateguryAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void config(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IArticleCateguryApplication, ArticleCateguryApplication>();
            services.AddTransient<IArticleCateguryRepository, ArticleCateguryRepository>();
            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MasterBlogger")));
        }
    }
}
