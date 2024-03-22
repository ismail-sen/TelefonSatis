using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Repositories
{
    public class RulesRepository : GenericRepository<Rules>, IRulesRepository
    {
        public RulesRepository(TelefonSatisDB db) : base(db)
        {
        }
    }
}
