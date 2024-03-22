using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(TelefonSatisDB db) : base(db)
        {
        }
    }
}
