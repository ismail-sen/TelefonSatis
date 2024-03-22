using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Database.IRepository
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        int UserCountWithRule(int ruleId);
        List<Users> UserListWithRule(int RuleId);
    }
}
