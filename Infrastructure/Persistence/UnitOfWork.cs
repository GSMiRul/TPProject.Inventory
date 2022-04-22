using Application.Common.Interfaces;
using Domain.Common.Interfaces;
using Infrastructure.Persistence;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Repository = new Repository<T>(context);
        }
        public IRepository<T> Repository { get; }

        public async Task Commit() =>
            await _context.SaveChangesAsync();

        public void Dispose() =>
            _context.Dispose();
    }
}
