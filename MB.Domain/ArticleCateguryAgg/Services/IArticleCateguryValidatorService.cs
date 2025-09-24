using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCateguryAgg.Services
{
    public interface IArticleCateguryValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string title);
    }
}
