using MB.Domain.ArticleCateguryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class ArticleCateguryMapping : IEntityTypeConfiguration<ArticleCategury>
    {
        public void Configure(EntityTypeBuilder<ArticleCategury> builder)
        {
            builder.ToTable("ArticleCateguries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.IsDeleted);

            builder.HasMany(x => x.Articles).WithOne(x => x.ArticleCategury).HasForeignKey(x => x.ArticleCateguryId);
        }
    }
}
