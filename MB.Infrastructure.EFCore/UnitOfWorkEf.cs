using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;
        public UnitOfWorkEf(MasterBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
