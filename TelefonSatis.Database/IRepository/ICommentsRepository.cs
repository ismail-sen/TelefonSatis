using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Database.IRepository
{
    public interface ICommentsRepository : IGenericRepository<Comments>
    {
        int CommentCountWithProduct(int productId);//Ürüne göre yorum sayısı
        int CommentCountWithUser(int UserId);
    }
}
