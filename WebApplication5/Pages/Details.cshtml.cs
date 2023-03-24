using ClassLibrary1;
using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class DetailsModel : PageModel
    {
        public int ID;
        public Film film;
        public void OnGet(int id)
        {
            ID = id;
            film = new FilmRepository().GetFilmById(id);
        }
    }
}
