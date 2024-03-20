using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFAboutRepository : GenericRepository<About>, IAboutRepository
	{
		//Herhangi bir class'ta GenericRepository'deki işlemlerin dışında farklı işlemler yapacaksak, DAL katmanımızdaki EntityFramework klasöründeki ilgili class'larda bu farklı operasyonları tanımlayabilir ve sadece o class'la ilgili işlemlerde kullanabiliriz. Ancak burada metodu dolduracağız, imzayı yine ilgili interface'de atmamız gerek!
	}
}
