using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class UpdateModel : PageModel
    {


            [BindProperty]
            public Film film { get; set; }
            private readonly IFilmIRepository filmRep;
            public UpdateModel(IFilmIRepository bookRepository)
            {
                filmRep = bookRepository;
            }
            public void OnGet(int id)
            {
                film = filmRep.GetFilmById(id);
            Name = film.Name;
            Author = film.Author;
            Style = film.Style;
            Description = film.Description;
            Id = film.Id.ToString();
            }
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Author { get; set; }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Style { get; set; }

        [BindProperty]
        public string Description { get; set; }
        [HttpPost]
            public IActionResult OnPost()
            {
            film.Name = Name;
            film.Author = Author;
            film.Description = Description;
            film.Style = Style;
            film.Id = Convert.ToInt32(Id);
            filmRep.UpdateFilm(film);
            return RedirectToPage("/Films");
        }

    }
}
