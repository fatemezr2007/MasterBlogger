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
