using Film_Api.Model;
using Film_Api.Repository.DbContexts;
using System.Collections.Generic;
using System.Globalization;

namespace Film_Api.Repository
{
    public class Repository
    {
        private readonly MoviesDbContexts _context;
        public Repository(MoviesDbContexts context) {
            _context = context;
        }
        //En tant qu’utilisateur, je souhaite ajouter et retirer un film à/de mes favoris
        public FavoriteMovies AddMoviesToFav(int idFilm, int idUser)
        {
            UsersMovies movie = _context.UsersMovies.Where(x=> x.User_Movie_Id == idFilm && x.User_Id == idUser ).FirstOrDefault();
            bool isFavExist = _context.FavoriteMovies.Where(x => x.Movie_Id == idFilm ).FirstOrDefault() != null;
            if (movie != null && !isFavExist)
            {
                FavoriteMovies favMovies = new FavoriteMovies
                {
                    Movie_Id = movie.User_Movie_Id,
                    CreatedTime = DateTime.Now,
                };


                _context.FavoriteMovies.Add(favMovies);
                _context.SaveChanges();
                return favMovies;
            }
            if (isFavExist)
                return null;

            return null;
        }

        public FavoriteMovies RemoveMoviesFav(int idFilm, int idUser)
        {
         
            FavoriteMovies favMovies = _context.FavoriteMovies.Where(x => x.Movie_Id == idFilm).FirstOrDefault() ;
            if(favMovies != null)
            {
                _context.FavoriteMovies.Remove(favMovies);
                _context.SaveChanges();
                return favMovies;
            }
            return null;
        }

        //En tant qu’utilisateur, je souhaite lister mes films favoris triés par date de sortie ou
        //par note globale

        public List<UsersMovies> GetMoviesByDate(int userid)
        {
            List<UsersMovies> movies = (from usm in _context.UsersMovies
                                        join m in _context.Movies on usm.User_Id equals m.Id
                                        join u in _context.Users on usm.User_Id equals u.Id
                          join fm in _context.FavoriteMovies on usm.User_Movie_Id equals fm.Movie_Id
                          into oFavoriteMovies from ofm in oFavoriteMovies
                          orderby  m.Release_Date descending
                          where userid == usm.User_Id
                          select usm
                          ).ToList();

            return movies;
        }

//        En tant qu’utilisateur, je souhaite pouvoir différencier les films que j’ai vu de ceux
//que je n’ai pas vu et notifier quand j’ai vu un film
// En tant qu’utilisateur, je souhaite lister les films que j’ai vu et ceux que je n’ai pas vu

        public List<Movies> WatchedMoovies(int userid, bool isWatched)
        {
            List<Movies> movies = (from usm in _context.UsersMovies
                                        join m in _context.Movies on usm.User_Id equals m.Id
                                        join u in _context.Users on usm.User_Id equals u.Id
                                       
                                        where userid == usm.User_Id && usm.IsWatches == isWatched
                                        select m
                          ).ToList();

            return movies;
        }
    }
}