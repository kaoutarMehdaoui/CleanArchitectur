using Domain.Model;

using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contrat
{
    public interface IGenerique<T> where T : Comman 
    {
         IReadOnlyList<T> getAll();
        IReadOnlyList<T> getAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        void addOne(T item);
        void removeOne(int item);
        void UpdateOne(T item);
        T getOne(int item);
    }
}
