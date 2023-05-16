using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Api.Model
{
    public class UsersMovies
    {
        public int User_Movie_Id { get; set; }    
        public int User_Id { get; set; }
      
        public bool IsWatches { get; set; }
        public virtual List<Users> Users { get; set; }

    }
}
