using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCateguryAgg.Exseptions
{
    public class DuplecatedRecordExseption : Exception
    {
        public DuplecatedRecordExseption()
        {
        }

        public DuplecatedRecordExseption(string message) : base(message)
        {
        }
    }
}
