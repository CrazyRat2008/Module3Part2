using ClassLibrary2; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class FilmsModel : PageModel
    {
        public IEnumerable<Film> films;
        private readonly IFilmIRepository filmsRepository;

        public FilmsModel(IFilmIRepository filmsRepository)
        {
            this.filmsRepository = filmsRepository;
        }
        public void OnGet()
        {
            films = filmsRepository.GetAllFilm();
        }
    }
}
