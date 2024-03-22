using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Repositories
{
    public class CommentsRepository : GenericRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(TelefonSatisDB db) : base(db)
        {
        }

        public int CommentCountWithProduct(int productId)
        {
            var getirUrunler = _db.Comments.Where(k => k.ProductId == productId);
            return getirUrunler.Count();
        }
        public int CommentCountWithUser(int UserId)
        {
            var getirUrunler = _db.Comments.Where(k => k.UserId == UserId);
            return getirUrunler.Count();
        }
    }
}
