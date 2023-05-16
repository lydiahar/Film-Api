using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Api.Model
{
    public class ScoreMovies
    {
        public int Movie_Id { get; set; }
        public int Score_Id { get; set;}
        public int Score_Total { get; set;}
        public virtual List<Movies> Movies { get; set; }
    }
}
