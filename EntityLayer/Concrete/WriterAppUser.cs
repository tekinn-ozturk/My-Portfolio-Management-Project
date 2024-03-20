using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterAppUser : IdentityUser<int>
    //IdentityUser classında bulunan TKey tipindeki Id property'sine burada kullanılacak ancak tipi int olacak.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}
