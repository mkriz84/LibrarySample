using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Library.Controllers
{
    //SOLID Principle   Separation consern  So Separate Interface 
    //BooksSearch  class inherits another BooksList
    public class BooksMatchWord : BooksList, IBooksMatchWord   {

        IBooksList _booksList;
        public BooksMatchWord() { }
        public BooksMatchWord(IBooksList booksList)
        {
            _booksList = booksList;
        }
        public List<string> MostCommonWords(int Id, string query)
        {
          

            List<string> striglist = new List<string>();

            string selectedFileName = _booksList.getbookById(Id);

            string fileLcatoin = ConfigurationManager.AppSettings["FileLocation"];
            string input = File.ReadAllText(fileLcatoin + selectedFileName);
            input.Replace('"', ' ');
            input.Replace(',', ' ');
            input.Replace('\'', ' ');
            input.Replace(':', ' ');

            string[] splits = Regex.Split(input, "[ \n\t\r]"); //Split the long string by spaces, \t and \n

            foreach (string str in splits)
            {
                if (Regex.IsMatch(str, "^^"+ query +".*?",RegexOptions.IgnoreCase)) 
                {
                    striglist.Add(str.TrimEnd(',','.',':','"',';'));
                  
                }
            }

            var striglists = striglist.GroupBy(x => x)
                  .Where(x => x.Key.ToString() != "")
                  .OrderByDescending(x => x.Count())
                  .Select(x => x.Key + "---------------- " + x.Count()).Take(10)
                  .ToList();

            return striglists;

           
        }

    }


}