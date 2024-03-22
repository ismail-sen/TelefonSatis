using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //interface=> imza
        //Repository kuralları
        //Insert,Update,Delete, List (CRUD)=> bütün tablolarda bu işlemler gerçekleşir. Her tabloda ayrı ayrı kodlamak yerine bu yapıları Repository denilen bir sayfada kalıtım verecek şekilde kodlanır , istenilen class tablolarına kalıtım verilerek bu kodlar yeniden kodlanmadan işlemlerin gerçekleşmesi sağlanır
        //

       

        TEntity GetById(int Id);

        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Add(TEntity entity);


        //void Add(TEntity product);
        //void Update(TEntity product);
        //void Delete(TEntity product);
        //void List(TEntity product);

        //En son haliyke kodlanacak Reposiitory nesneleri aşağıdaki gibi olmalıdır
        //IQueryable,IEnumarable liste olarak data getirir
        //IQueryable=> sorgu ile getirir
        //IEnumarable=> Numara ile sorgu getirir
        IQueryable<TEntity> GetAll();//Hepsini sorgusuz olarak list getir
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity,bool>> predicate);//Bir koşula bağlı list getir
        //
        bool Any(Expression<Func<TEntity, bool>> predicate);//sorgu ile işlemda data varsa true, yoksa false getirir

        TEntity Find(Expression<Func<TEntity, bool>> predicate);//Sorgu ile tek nesne getirir.




    }
}
