using _01_Framework.Infrastructure;
using MB.Domain.ArticleCateguryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCateguryRepository : BaseRepository<long, ArticleCategury>, IArticleCateguryRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleCateguryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }
    }
}
