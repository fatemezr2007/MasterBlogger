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
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Activate(long id)
        {
            var article = _articleRepository.Get(id);
            article.Activate();
            //_articleRepository.Save();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image,
                command.Content, command.ArticleCateguryId);
            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var artile = _articleRepository.Get(command.Id);
            artile.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCateguryId);
            //_articleRepository.Save();
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
            var article = _articleRepository.Get(id);
            article.Remove();
            //_articleRepository.Save();
        }
    }
}
