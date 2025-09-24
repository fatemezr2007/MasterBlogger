using MB.Domain.ArticleCateguryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCateguryRepository : IArticleCateguryRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleCateguryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Add(ArticleCategury entity)
        {
            _context.ArticleCateguries.Add(entity);
            Save();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCateguries.Any(x => x.Title == title);
        }

        public ArticleCategury Get(long id)
        {
            return _context.ArticleCateguries.FirstOrDefault(x => x.Id == id)!;
        }

        public List<ArticleCategury> GetAll()
        {
            return _context.ArticleCateguries.OrderByDescending(x => x.Id).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
