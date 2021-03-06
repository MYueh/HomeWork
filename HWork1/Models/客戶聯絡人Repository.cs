using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.ModelBinding;

	
namespace HWork1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {            
            return base.All().Where(p=>p.是否已刪除==false);
        }
        public IQueryable<客戶聯絡人> 取得前五筆資料()
        {
            return this.All().Take(5);
        }
        public IQueryable<客戶聯絡人> Email重覆判斷(string mail)
        {
            return this.All().Where(p=>p.Email == mail );             
        }
        public IQueryable<客戶聯絡人> Email重覆判斷(string mail, int id)
        {   
            return this.All().Where(p=>p.Email == mail && p.Id != id);
        }
        
        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        
        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
        }
        public override void Add(客戶聯絡人 entity)
        {
            base.Add(entity);
        }        
	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}