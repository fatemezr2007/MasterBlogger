using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCateguryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCateguryAgg
{
    public class ArticleCategury : DomainBase<long>
    {
        public string Title { get; private set; }
        public ICollection<Article> Articles { get; set; }
        public bool IsDeleted { get; private set; }

        protected ArticleCategury()
        {
        }

        public ArticleCategury(string title, IArticleCateguryValidatorService validatorService)
        {
            GurdAgainsEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);

            Title = title;
            Articles = new List<Article>();
            IsDeleted = false;
        }

        public void GurdAgainsEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Rename(string title)
        {
            GurdAgainsEmptyTitle(title);

            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
