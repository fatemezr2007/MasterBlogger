using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategury
{
    public interface IArticleCateguryApplication
    {
        List<ArticleCateguryViewModel> List();
        void Create(CreateArticleCategury command);
        void Rename(RenameArticleCategury command);
        RenameArticleCategury Get(long id);
        public void Remove(long id);
        public void Activate(long id);
    }
}
