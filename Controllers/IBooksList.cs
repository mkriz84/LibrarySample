using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Controllers
{
    public interface IBooksList
    {
         List<BooksDeatil> books();
        string getbookById(int Id);


    }
}