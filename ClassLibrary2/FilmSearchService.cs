using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ClassLibrary2
{
    public class FilmSearchService : ISearchFilm
    {
        private readonly IFilmIRepository _bookRepository;
        public FilmSearchService(IFilmIRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Film> SearchFilms(string query)
        {
            string[] words = query.ToLower().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            List<Film> books = _bookRepository.GetAllFilm().
                Where(book => words.Any(word => book.Name.ToLower().Contains(word) ||
                 book.Author.ToLower().Contains(word) ||
                 book.Style.ToLower().Contains(word) ||
                 book.Description.ToLower().Contains(word)  
                 )).ToList();

            return books;
        }
    }
}
