using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Web.Domain.Infrastructure
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
