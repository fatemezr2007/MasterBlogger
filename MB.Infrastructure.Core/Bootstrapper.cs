using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategury;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCateguryAgg;
using MB.Domain.ArticleCateguryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using MB.Infrastructure.Query;
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
            services.AddTransient<IArticleCateguryValidatorService, ArticleCateguryValidatorService>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MasterBlogger")));
        }
    }
}
