using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Repositories
{
    public class UsersRepositroy : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepositroy(TelefonSatisDB db) : base(db)
        {
        }

        public int UserCountWithRule(int ruleId)
        {
            var getirUrunler = _db.Users.Where(k => k.RuleId == ruleId);
            return getirUrunler.Count();
        }

        public List<Users> UserListWithRule(int RuleId)
        {
            throw new NotImplementedException();
        }
    }
}
