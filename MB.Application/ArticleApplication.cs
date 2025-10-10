using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.ShortDescription, command.Image,
                command.Content, command.ArticleCateguryId);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var artile = _articleRepository.Get(command.Id);
            artile.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCateguryId);
            _unitOfWork.CommitTran();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCateguryId = article.ArticleCateguryId
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }
    }
}
