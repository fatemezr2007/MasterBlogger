using MB.Application.Contracts.ArticleCategury;
using MB.Domain.ArticleCateguryAgg;
using MB.Domain.ArticleCateguryAgg.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleCateguryApplication : IArticleCateguryApplication
    {
        private readonly IArticleCateguryRepository articleCateguryRepository;
        private readonly IArticleCateguryValidatorService articleCateguryValidatorService;
        public ArticleCateguryApplication(IArticleCateguryRepository articleCateguryRepository, IArticleCateguryValidatorService articleCateguryValidatorService)
        {
            this.articleCateguryRepository = articleCateguryRepository;
            this.articleCateguryValidatorService = articleCateguryValidatorService;
        }
        public void Create(CreateArticleCategury command)
        {
            var articleCategury = new ArticleCategury(command.Title, articleCateguryValidatorService);
            articleCateguryRepository.Create(articleCategury);
        }

        public RenameArticleCategury Get(long id)
        {
            var articlecategury = articleCateguryRepository.Get(id);
            return new RenameArticleCategury
            {
                Id = articlecategury.Id,
                Title = articlecategury.Title
            };
        }

        public List<ArticleCateguryViewModel> List()
        {
            var articleCateguries = articleCateguryRepository.GetAll();
            return (from articleCategury in articleCateguries
                    select new ArticleCateguryViewModel
                    {
                        Id = articleCategury.Id,
                        Title = articleCategury.Title,
                        CreationDate = articleCategury.CreationDate.ToString(CultureInfo.InvariantCulture),
                        IsDeleted = articleCategury.IsDeleted
                    }).OrderByDescending(x => x.Id).ToList();
        }

        public void Remove(long id)
        {
            var articleCategury = articleCateguryRepository.Get(id);
            articleCategury.Remove();
            //articleCateguryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategury = articleCateguryRepository.Get(id);
            articleCategury.Activate();
            //articleCateguryRepository.Save();
        }

        public void Rename(RenameArticleCategury command)
        {
            var articleCategury = articleCateguryRepository.Get(command.Id);
            articleCategury.Rename(command.Title);

            //articleCateguryRepository.Save();
        }
    }
}
