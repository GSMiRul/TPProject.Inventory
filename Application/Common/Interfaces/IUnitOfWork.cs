using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork<T>: IDisposable where T : class, IEntity
    {
        IRepository<T> Repository { get; }
        Task Commit();
    }
}
