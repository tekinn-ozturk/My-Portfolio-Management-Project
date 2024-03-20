using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUserWriterRole: IdentityRole<int>
    {
        //IdenitityRole classında bulunan TKey tipindeki Id property'sine burada kullanılacak ancak tipi int olacak.
    }
}
