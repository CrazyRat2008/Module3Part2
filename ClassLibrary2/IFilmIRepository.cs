 

namespace ClassLibrary2
{
    public interface IFilmIRepository
    {
            List<Film> GetAllFilm();
            Film GetFilmById(int id);
            void AddFilm(Film f);
            void UpdateFilm(Film f);
            void DeleteFilm(int id); 
    
    }
}
