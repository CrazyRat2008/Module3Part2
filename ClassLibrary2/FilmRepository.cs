using ClassLibrary2;
using System.Text.Json;
using System.Web.Mvc;

namespace ClassLibrary1
{
    [Serializable]
    public class FilmRepository : IFilmIRepository
    {
        
      public  List<Film> Films { get; set; }
        public FilmRepository()
        {
            Films = new List<Film>
        {
            new Film {Id=1, Name = "Margarita", Author = "Tequila, lime juice, triple sec", Style = "A classic tequila cocktail" , Description ="4123412"},
            new Film {Id=2, Name = "Manhattan", Author = "Whiskey, sweet vermouth, bitters", Style = "A classic whiskey cocktail", Description ="4123412" },
            new Film {Id=3, Name = "Gin and Tonic", Author = "Gin, tonic water, lime", Style = "A refreshing gin cocktail", Description ="4123412" }
        };
        }
        public void AddFilm(Film f)
        {
            f.Id = Films.Max(x => x.Id) + 1;
            Films.Add(f);
            using (FileStream fs = new FileStream("films.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync<List<Film>>(fs, Films);
            }
        }

        public void DeleteFilm(int id)
        {
            var f = Films.FirstOrDefault(x => x.Id == id);
            if (f != null)
                Films.Remove(f);
            using (FileStream fs = new FileStream("films.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync<List<Film>>(fs, Films);
            }
        }

        public List<Film> GetAllFilm()
        {
            using (FileStream fs = new FileStream("films.json", FileMode.Open))
            { 
                try
                {
                Films = JsonSerializer.Deserialize<List<Film>>(fs);
                }
                catch
                {
                    Films = new List<Film>
        {
            new Film {Id=1, Name = "Margarita", Author = "Tequila, lime juice, triple sec", Style = "A classic tequila cocktail" , Description ="4123412"},
            new Film {Id=2, Name = "Manhattan", Author = "Whiskey, sweet vermouth, bitters", Style = "A classic whiskey cocktail", Description ="4123412" },
            new Film {Id=3, Name = "Gin and Tonic", Author = "Gin, tonic water, lime", Style = "A refreshing gin cocktail", Description ="4123412" }
        };
                    JsonSerializer.Serialize<List<Film>>(fs, Films);
                }

            }
            return Films;
        }

        public Film GetFilmById(int id)
        {
            return Films.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public void UpdateFilm(Film f)
        {
            var existingFilm = Films.FirstOrDefault(x => x.Id == f.Id);
            Films.Remove(existingFilm);
            Films.Add(f);
            //if (existingFilm != null)
            //{
            //    f.Name = existingFilm.Name;
            //    f.Author = existingFilm.Author;
            //    f.Style = existingFilm.Style;
            //    f.Description = existingFilm.Description;
            //}
            using (FileStream fs = new FileStream("films.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync<List<Film>>(fs, Films);
            }
        }
    }
}
