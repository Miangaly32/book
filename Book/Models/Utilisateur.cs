using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Book.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}