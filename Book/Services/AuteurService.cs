using Book.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Book.Services
{
    public class AuteurService
    {
        string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog = book; Server=LAPTOP-5NOD3C0F";

        //To View all books details    
        public IEnumerable<Auteur> GetAllAuteurs()
        {
            List<Auteur> lstAuteur = new List<Auteur>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Auteur", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Auteur Auteur = new Auteur();
                    Auteur.Id = (int)rdr["Id"];
                    Auteur.Nom = rdr["nom"].ToString();
                    Auteur.Prenom = rdr["prenom"].ToString();

                    lstAuteur.Add(Auteur);
                }
                con.Close();
            }
            return lstAuteur;
        }

        /*public Auteur GetAuteurById(int id)
        {
            Auteur auteur = new Auteur();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Auteur where id="+id, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    auteur.Id = (int)rdr["Id"];
                    auteur.Nom = rdr["nom"].ToString();
                    auteur.Prenom = rdr["prenom"].ToString();
                }
                con.Close();
            }
            return auteur;
        }*/
    }
}