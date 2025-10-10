using _01_Framework.Infrastructure;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCateguryRepository articleCateguryRepository;
        private readonly IArticleCateguryValidatorService articleCateguryValidatorService;
        public ArticleCateguryApplication(IArticleCateguryRepository articleCateguryRepository,
            IArticleCateguryValidatorService articleCateguryValidatorService, IUnitOfWork unitOfWork)
        {
            this.articleCateguryRepository = articleCateguryRepository;
            this.articleCateguryValidatorService = articleCateguryValidatorService;
            _unitOfWork = unitOfWork;
        }
        public void Create(CreateArticleCategury command)
        {
            _unitOfWork.BeginTran();
            var articleCategury = new ArticleCategury(command.Title, articleCateguryValidatorService);
            articleCateguryRepository.Create(articleCategury);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var articleCategury = articleCateguryRepository.Get(id);
            articleCategury.Remove();
            _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategury = articleCateguryRepository.Get(id);
            articleCategury.Activate();
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategury command)
        {
            _unitOfWork.BeginTran();
            var articleCategury = articleCateguryRepository.Get(command.Id);
            articleCategury.Rename(command.Title);
            _unitOfWork.CommitTran();
        }
    }
}
