using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Library.Controllers
{
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	[RoutePrefix("api/books")]
    public class BooksController : ApiController
	{
		
		// SOLID Princaipal  Single repsonsibilty 

		IBooksMatchWord _iBooksMatchWord;        // only for Match the word
		IBooksSearch _iBooksSearch;              // only for Search the word
		IBooksList _iBooksList;                  // only for List Books list

		/*
		The following GET methods are expected on the api/books controller:

			1. GET api/books
				Returns a list of Ids & Titles for all the books in the Resources folder
				Titles should be the name of the filename, minus the extension.
				The Id should be unique.

			2. GET api/books/{Id}
				Returns a list of the most common 10 words (min 5 letters) and how many times they occur in the specified book.
				When parsing, whitespace, linefeeds and punctiation should be ignored, and words matched case-insensitively (e.g. "the" and "The" and "THE" will be returned as "The"=3)
				Words should be returned in capital case (e.g. Word), and the list should be sorted in decreasing incidence.

			3. GET api/books/1/{char}
				Returns a list of all words which start with the specified string (min 3 letters) and the number of times they occur within the specified book.
				Case matching should be insensitive.

		The logic for these calls should largely be encapsulated in other classes. This should make it easier to Unit Test those classes
		to validate the expected behaviour.
		*/

		public BooksController()
		{

			

		
		}
		public BooksController(IBooksMatchWord iBooksMatchWord,
				IBooksSearch iBooksSearch,
		        IBooksList iBooksList
			
			) {

			_iBooksMatchWord = iBooksMatchWord;
			_iBooksSearch = iBooksSearch;
			_iBooksList = iBooksList;

		}
		
		[Route("")]
		[HttpGet]	
		public List<BooksDeatil> books() {


			var Item = _iBooksList.books();

			return Item;
		}

		[Route("{Id=}")]
		[HttpGet]
	
		public List<string> booksSearch(int Id)
		{

			var Item = _iBooksSearch.Search(Id);

			return Item;
		}
		[Route("{Id=}/{query=}")]
		[HttpGet]
	
		public List<string> bookMatch(int Id,string query)
		{

			var Item = _iBooksMatchWord.MostCommonWords(Id, query);

			return Item;
		}

	}
}
