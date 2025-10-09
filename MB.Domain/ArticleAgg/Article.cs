using MB.Domain.ArticleCateguryAgg;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCateguryId { get; private set; }
        public ArticleCategury ArticleCategury { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        protected Article()
        {
        }

        private static void Validate(string title, long articleCateguryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

            if (articleCateguryId == 0)
                throw new ArgumentOutOfRangeException();
        }

        public Article(string title, string shortDescription, string image, string content, long articleCateguryId)
        {
            Validate(title, articleCateguryId);
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            ArticleCateguryId = articleCateguryId;
            Comments = new List<Comment>();
        }

        public void Edit(string title, string shortDescription, string image, string content, long articleCateguryId)
        {
            Validate(title, articleCateguryId);
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCateguryId = articleCateguryId;
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
