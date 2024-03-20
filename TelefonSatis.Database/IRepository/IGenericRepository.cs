using System;
using System.Collections.Generic;
using System.Linq;
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

        IQueryable<TEntity> GetAll();

        TEntity Get(int Id);

        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Add(TEntity entity);


        //void Add(TEntity product);
        //void Update(TEntity product);
        //void Delete(TEntity product);
        //void List(TEntity product);



    }
}
