using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Domain
{
    public class DomainBase<T>
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }

        public DomainBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
