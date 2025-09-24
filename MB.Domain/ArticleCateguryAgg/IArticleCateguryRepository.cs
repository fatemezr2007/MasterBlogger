using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCateguryAgg
{
    public interface IArticleCateguryRepository
    {
        List<ArticleCategury> GetAll();
        void Add(ArticleCategury entity);
        ArticleCategury Get(long id);
        void Save();
        bool Exists(string title);
    }
}
