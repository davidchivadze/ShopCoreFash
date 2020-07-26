using Database.Interfaces;

using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private DataContext _database;
        protected DataContext Database
        {
            get
            {
                return _database = _database ?? new DataContext();
            }
        }

        public bool Add(T entity)
        {
            try
            {
                Database.Set<T>().Add(entity);
                Database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IQueryable<T> Get()
        {
            return Database.Set<T>();
        }

        public T Update(T entity)
        {
            try
            {
                Database.Set<T>().Update(entity);
                Database.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Database.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

