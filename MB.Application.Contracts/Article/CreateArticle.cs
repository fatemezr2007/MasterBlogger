﻿namespace MB.Application.Contracts.Article
{
    public class CreateArticle()
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public long ArticleCateguryId { get; set; }
    }
}
