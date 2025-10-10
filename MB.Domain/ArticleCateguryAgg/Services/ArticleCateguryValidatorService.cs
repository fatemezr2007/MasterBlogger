namespace MB.Domain.ArticleCateguryAgg.Services
{
    public class ArticleCateguryValidatorService : IArticleCateguryValidatorService
    {
        private readonly IArticleCateguryRepository articleCateguryRepository;
        public ArticleCateguryValidatorService(IArticleCateguryRepository articleCateguryRepository)
        {
            this.articleCateguryRepository = articleCateguryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (articleCateguryRepository.Exists(x => x.Title == title))
                throw new DuplicateWaitObjectException("This record already exists in database");
        }
    }
}
