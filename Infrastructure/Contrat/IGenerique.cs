using Domain.Model;
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
        void addOne(T item);
        void removeOne(T item);
        void UpdateOne(T item);
        T getOne(int item);
    }
}
