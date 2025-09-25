using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCateguryAgg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore
{
    public class MasterBloggerContext:DbContext
    {
        public DbSet<ArticleCategury> ArticleCateguries { get; set; }
        public DbSet<Article> Articles { get; set; }

        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCateguryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
