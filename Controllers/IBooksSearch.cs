using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Controllers
{
    public interface IBooksSearch
    {
        List<string> Search(int Id);


    }
}