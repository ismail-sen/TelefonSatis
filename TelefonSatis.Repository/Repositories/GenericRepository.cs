using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;

namespace TelefonSatis.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        protected readonly TelefonSatisDB _db;

        public void Add(TEntity entity)
        {
           _db.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
