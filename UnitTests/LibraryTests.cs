using NUnit.Framework;
using System.Linq;
using Library.Controllers;
using Moq;

namespace Library.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        IBooksMatchWord _iBooksMatchWord;
        IBooksSearch _iBooksSearch;
        IBooksList _iBooksList;
        private  BooksController _controller;
        private Mock<IBooksMatchWord> _mockBooksMatchWordRepository;
        private Mock<IBooksSearch> _mockiBooksSearchRepository;
        private Mock<IBooksList> _mockiBooksListRepository;


        private const string SAMPLE_TEXT = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate 
                velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public LibraryTests() { }

        [SetUp]
        public void Setup()
        {

            _mockBooksMatchWordRepository = new Mock<IBooksMatchWord>();
            _mockiBooksSearchRepository = new Mock<IBooksSearch>();
            _mockiBooksListRepository = new Mock<IBooksList>();
            _controller = new BooksController(_mockBooksMatchWordRepository.Object, _mockiBooksSearchRepository.Object, _mockiBooksListRepository.Object);

   
       

        }

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
            int id = 1;
            string txt = "dolor";
            _mockBooksMatchWordRepository.Setup(x => x.MostCommonWords(id, txt))
           .Returns(SAMPLE_TEXT.Split(' ').ToList());

            var item = _controller.bookMatch(id, txt);
           Assert.AreEqual(_mockBooksMatchWordRepository.Object.MostCommonWords(id, txt).Count, item.Count);
        }

        [Test]
        public void SearchTest()
        {
            int Id = 1;
           _mockiBooksSearchRepository.Setup(x => x.Search(Id))
            .Returns(SAMPLE_TEXT.Split(' ').ToList());

            var Item = _controller.booksSearch(Id);
            Assert.AreEqual(_mockiBooksSearchRepository.Object.Search(Id).Count, Item.Count);
        }

               
    }
}