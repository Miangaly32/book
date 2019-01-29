using Book.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Book.Services
{
    public class GenreService
    {
        string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog = book; Server=LAPTOP-5NOD3C0F";

        //To View all books details    
        public IEnumerable<Genre> GetAllGenres()
        {
            List<Genre> lstGenre = new List<Genre>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from genre", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Genre genre = new Genre();
                    genre.Id = (int)rdr["Id"];
                    genre.Designation = rdr["designation"].ToString();

                    lstGenre.Add(genre);
                }
                con.Close();
            }
            return lstGenre;
        }
       /* public Genre GetGenreById(int id)
        {
            Genre genre = new Genre();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Genre where id=" + id, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    genre.Id = (int)rdr["Id"];
                    genre.Designation = rdr["designation"].ToString();
                }
                con.Close();
            }
            return genre;
        }*/
    }
}