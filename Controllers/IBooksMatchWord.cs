using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Controllers
{
    public interface IBooksMatchWord
    {

        List<string> MostCommonWords(int Id, string query);




    }
}