using NUnit.Framework;
using System.Linq;
using Library.Controllers;
namespace Library.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        IBooksMatchWord _iBooksMatchWord;
        IBooksSearch _iBooksSearch;
        IBooksList _iBooksList;
        private readonly BooksController _controller;

        private const string SAMPLE_TEXT = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate 
                velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public LibraryTests(IBooksMatchWord iBooksMatchWord,
                IBooksSearch iBooksSearch,
                IBooksList iBooksList)
        {

            _iBooksMatchWord = iBooksMatchWord;
            _iBooksSearch = iBooksSearch;
            _iBooksList = iBooksList;

        }
        [Test]
        public void MostCommonWordsTest()
        {

            var item = _controller.books();
            Assert.Greater(item.Count,0);
        }

        [Test]
        public void SearchTest()
        {
            int Id = 1;
            var Item = _controller.booksSearch(Id);
            Assert.IsNotNull(Item);
        }

        [Test]
        public void booksTest()
        {
            int Id = 1;
            string query = "exe";
            var Item = _controller.bookMatch(Id, query);
            Assert.IsNotNull(Item);
        }
        
    }
}