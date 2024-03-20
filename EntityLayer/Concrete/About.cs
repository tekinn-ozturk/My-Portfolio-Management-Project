using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class About
	{
        
        public int AboutId { get; set; }
        public string Title { get; set; } // Hello! I am Walter
        public string Description { get; set; } //Paragraf
        public string Age { get; set; } // yaş , email . phone gibi özelliklerin hepsini dinamik hale getirdik.
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; } // Görselimizin dosya yolunu string olarak tutacağız.
    }
}
