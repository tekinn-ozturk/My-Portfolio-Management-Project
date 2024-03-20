using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		public void Delete(T t)
		{
			using var c = new Context(); //Context'e bağlanarak yeni bir context örneğini burada oluşturduk ki entityframework core metotlarına ulaşalım.
			c.Remove(t); // Silme işlemi gerçekleştirildi ancak veritabanında kaydedilmedi.
			c.SaveChanges(); // Silme işlemi veritabanına kaydedildi.
		}

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context())
			{
				return c.Set<T>().Where(filter).ToList();
            /* Set<T>() metodu, DbContext sınıfındaki T türündeki varlıkları temsil eden bir DbSet<T> örneği döndürür. Bu örneği kullanarak LINQ sorgusu oluşturulur ve filtrelenmiş varlıkların bir listesi döndürülür.*/


			}

        }

        public T GetById(int id)
		{
			using var c = new Context();
			return c.Set<T>().Find(id);

			//Normalde bu c.Set<T>'ye table derdik hatırla.

		}

		public List<T> GetList()
		{
			using var c = new Context();
			 return c.Set<T>().ToList();

		}

		public void Insert(T t)
		{
			using var c = new Context();
			c.Add(t);
			c.SaveChanges();
		}

		public void Update(T t)
		{
			using var c = new Context();
			c.Update(t);
			c.SaveChanges();
		}
	}
}
