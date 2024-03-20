using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T>
	{
		//Servislerimi her entity için ayrı ayrı yapabilirdim ancak servisleride generic oluşturmaya karar verdik.
		//Generic yapı kurgulamasaydık örneğin About class'ında bu metotlar şu şekilde imzalanırdı =>  void Add(About a);
		void TAdd(T t);
		void TDelete(T t);
		void TUpdate(T t);
		List<T> TGetList();
		T TGetById(int id);

		List<T> TGetListByFilter(string p);

	}
}
