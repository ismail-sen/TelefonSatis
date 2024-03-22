using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;

namespace TelefonSatis.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        protected readonly TelefonSatisDB _db;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TelefonSatisDB db)
        {
            _db = db;  
            _dbSet=_db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            //_db.Set<TEntity>().Add(entity);
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            //_db.Set<TEntity>().Remove(entity);
            _dbSet.Remove(entity);
        }

        public TEntity GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
#warning değiştirilebilir
            var varMi = _dbSet.Where(predicate).FirstOrDefault();
            if (varMi !=null)
            {
                return true;
            }
            return false;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

    }
}
