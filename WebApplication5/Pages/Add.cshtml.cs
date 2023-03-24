using ClassLibrary1;
using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class AddModel : PageModel
    {
        private readonly IFilmIRepository _filmRepository;

        public AddModel(IFilmIRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        public string Style { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var film = new Film
            {
                Name = Name,
                Author = Author,
                Style = Style,
                Description = Description
            };

            _filmRepository.AddFilm(film);

            return RedirectToPage("/Films");
        }
    }
}
