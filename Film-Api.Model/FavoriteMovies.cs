using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Api.Model
{
    public class FavoriteMovies
    {
        public int Fav_Movie_Id { get; set; }
        public int Movie_Id { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual List<Movies> Movies { get; set; }
    }
}
