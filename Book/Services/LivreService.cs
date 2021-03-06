﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Book.Models;

namespace Book.Services
{
    public class LivreService
    {
        string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog = book; Server=LAPTOP-5NOD3C0F";

        //To View all books details    
        public IEnumerable<Livre> GetAllLivres()
        {
            List<Livre> lstLivre = new List<Livre>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from livre order by DateSortie desc", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Livre livre = new Livre();
                    livre.Id = (int)rdr["Id"];
                    livre.Titre = rdr["Titre"].ToString();
                    livre.image = rdr["image"].ToString();

                    lstLivre.Add(livre);
                }
                con.Close();
            }
            return lstLivre;
        }

        public List<Livre> Search(Livre livre)
        {
            List<Livre> lstLivre = new List<Livre>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from livre join auteur on livre.idauteur=auteur.id join genre on livre.idgenre= genre.id where titre like '%" + livre.Titre + "%' or description like '%" + livre.Titre + "%'  or auteur.nom like '%" + livre.Auteur.Nom + "%' ", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Livre liv = new Livre();
                    liv.Id = (int)rdr["Id"];
                    liv.Titre = rdr["Titre"].ToString();
                    liv.image = rdr["image"].ToString();

                    lstLivre.Add(liv);
                }
                con.Close();
            }
            return lstLivre;
        }

        public List<Livre> SearchMulticritere(Livre livre)
        {
            List<Livre> lstLivre = new List<Livre>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //check if idgenre ou idauteur null
                String sql = "select * from livre ";// where titre like '%" + livre.Titre + "%' and idauteur = "+livre.Auteur.Id+" and idgenre = "+livre.Genre.Id;
                
                if (livre.Titre != ""){
                    sql += "where titre like '%" + livre.Titre + "%'";
                }

                if (livre.Genre!=null)
                {
                    if (livre.Titre != "")
                        sql += "and idgenre = " + livre.Genre.Id;
                    else
                        sql += "where idgenre = " + livre.Genre.Id;
                }

                if (livre.Auteur!=null)
                {
                    if (livre.Genre != null || livre.Titre != "")
                        sql += "and idauteur = " + livre.Auteur.Id;
                    else if(livre.Genre == null)
                        sql += "where idauteur = " + livre.Auteur.Id;
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Livre liv = new Livre();
                    liv.Id = (int)rdr["Id"];
                    liv.Titre = rdr["Titre"].ToString();
                    liv.image = rdr["image"].ToString();

                    lstLivre.Add(liv);
                }
                con.Close();
            }
            return lstLivre;
        }
    }
}