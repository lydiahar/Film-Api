using Film_Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Api.Repository.DbContexts
{
    public class MoviesDbContexts :  DbContext
    {
        public virtual DbSet<Movies> Movies { get; set;}
        public virtual DbSet<UsersMovies> UsersMovies { get; set;}
        public virtual DbSet<FavoriteMovies> FavoriteMovies { get; set;}
        public virtual DbSet<ScoreMovies> ScoreMovies { get; set;}
        public virtual DbSet<Users> Users { get; set;}

     
    }

}
