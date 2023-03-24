using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ISearchFilm _bookSearchService;
        private readonly IFilmIRepository _bookRepository;
        public IEnumerable<Film> Films;
        public SearchModel(IFilmIRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _bookSearchService = new FilmSearchService(bookRepository);
            Films = _bookRepository.GetAllFilm();
        }
        [HttpPost]
        public void OnPost(string myInput)
        {
            MyFunction(myInput);
        }
        private void MyFunction(string input)
        {
            Films = _bookSearchService.SearchFilms(input);
        }
    }
}
