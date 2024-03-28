using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.StoredProcedures
{
	public class ProjectStoredProcedures
	{
		TelefonSatisDB _db;
        public ProjectStoredProcedures(TelefonSatisDB db)
        {
				_db = db;
        }
        public string Sp_ProductListWithCategory()
		{
			try
			{
				string sql = @"
							
							create proc sp_ProductListWithCategory
							as 
							begin

							select 
							p.ProductsId,p.ProductName,p.Price,p.Stock,
							c.CategoriesId,c.CategoryName
							from 
										Products	as p
							inner join  Categories	as c on p.CategoryId=c.CategoriesId

							end
							";
				var list =_db.Database.ExecuteSqlRaw(sql);
				return "sp_ProductListWithCategory başarılı bir şekilde oluştu";

			}
			catch (Exception ex)
			{
				return ex.Message;
			}

		}
	}
}
