using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Feature
	{

        public int FeatureId { get; set; }
        public string Header { get; set; }  //=> bu property Hello'ya karşılık geliyor
        public string Name { get; set; } //=> I am bölümüne karşılık gelen property
        public string Title { get; set; }

        //Sosyal medya ikonları için daha sonra bişey kuracağız sanırım bi footer tarzında bişey.

    }
}
