using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Film film { get; set; }
        private readonly IFilmIRepository filmRep;
        public DeleteModel(IFilmIRepository bookRepository)
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
            filmRep.DeleteFilm(Convert.ToInt32(Id));
            return RedirectToPage("/Films"); 
        }
    }
}
