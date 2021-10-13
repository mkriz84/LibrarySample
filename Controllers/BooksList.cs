using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Library.Controllers
{

    public class BooksDeatil
    {
        public int id { get; set; }
        public string bookName { get; set; }

    }

    public class BooksList : IBooksList {


        public static Dictionary<int, string> Books = new Dictionary<int, string>(); 
        public List<BooksDeatil> booksList { get; set; }
        public List<BooksDeatil> books() {

            List < BooksDeatil > booklist  = new List<BooksDeatil>();
            string fileLcatoin = ConfigurationManager.AppSettings["FileLocation"];

            string[] filePaths = Directory.GetFiles(fileLcatoin, "*.txt",
                                         SearchOption.AllDirectories);
          
            foreach (string file in filePaths) {
                BooksDeatil booksDeatil = new BooksDeatil();
                string[] filePathsItem = file.Split('\\');
                booksDeatil.bookName = filePathsItem[filePathsItem.Length-1].Replace('.', '-');
                booksDeatil.id = Library.Utilitty.Registartion.Instance.Id;
                Books.Add(booksDeatil.id, booksDeatil.bookName.Replace('-', '.'));
                booklist.Add(booksDeatil);
            }

            booksList = booklist;
            return booklist;
        }


        public  string getbookById(int Id)
        {

          

            string[] filePaths = Directory.GetFiles(@"C:\AG\Test\LibrarySample\Resources\", "*.txt",
                                         SearchOption.AllDirectories);
             string Selectedfile="";
            foreach (string file in filePaths)
            {
                BooksDeatil booksDeatil = new BooksDeatil();
                string[] filePathsItem = file.Split('\\');
                    if (Books.TryGetValue(Id, out string SelectedFile)) {
                    Selectedfile = SelectedFile;
                }
            
            }

          
            return Selectedfile;
        }


    }


}