using Application.Data;
using AutoMapper;
using Domain.Model;

using Infrastructure.Contrat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GeneriqueEmpl<T> : IGenerique<T> where T : Comman 
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbSet;
        
        public GeneriqueEmpl(MyContext myContext )
        {
           this._context = myContext;
          this._dbSet= _context.Set<T>();
           
        }
        public void addOne(T item)
        {
          
            this._context.Add(item);
            this._context.SaveChanges();
        }

        

        public IReadOnlyList<T> getAll()
        {

            return this._dbSet.ToList();
        }

        public IReadOnlyList<T> getAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)

            {

                query = include(query);

            }
            return query.ToList();
        }

        public T getOne(int id)
        { 
            return this._dbSet.FirstOrDefault(x=>x.Id==id);
        }

        public void removeOne(int Id )
        {
            var entity = this._dbSet.FirstOrDefault( x=>x.Id==Id);
            this._dbSet.Remove(entity);
            this._context.SaveChanges();

        }

        //public void UpdateOne(T item)
        //{
        // this._context.Entry(item).State = EntityState.Modified;
        //    this._context.SaveChanges(); 
        //}

        public void UpdateOne(T item)
        {
            
            this._context.Update(item);
            this._context.SaveChanges();
        }
    }
}
