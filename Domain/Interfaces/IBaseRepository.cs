using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Interfaces
{
   public interface IBaseRepository<T>
    {
        IQueryable<T> Get();
        T Update(T entity);
        bool Add(T entity);
    }
}
