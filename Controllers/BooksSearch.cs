using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Library.Controllers
{
    //BooksSearch  class inherits another BooksList
    //SOLID principles Separation consern  wew used Interface 
    public class BooksSearch : BooksList, IBooksSearch {

        IBooksList _booksList;
        public BooksSearch() { }
        public BooksSearch(IBooksList booksList) {
            _booksList = booksList;
        }
        public List<string> Search(int Id)
        {
            string fileLcatoin = ConfigurationManager.AppSettings["FileLocation"];
            // List<string> striglist = new List<string>();

            string selectedFileName = _booksList.getbookById(Id);

            string input = File.ReadAllText(fileLcatoin + selectedFileName);
            input.Replace('"', ' ');
            input.Replace(',', ' ');
            input.Replace('\'', ' ');
            input.Replace(':', ' ');
            string[] splits = Regex.Split(input, "[ \n\t\r\b]"); //Split the long string by spaces, \t and \n
       
            var striglist = splits.GroupBy(x => x)
                   .Where(x=>x.Key.ToString()!="")
                   .OrderByDescending(x => x.Count())
                   .Select(x => x.Key +"---------------- "+ x.Count()).Take(10)
                   .ToList();

            return striglist;
        }


    }


}