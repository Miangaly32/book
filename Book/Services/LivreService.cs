using System;
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
        string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog = book; Server=PBIO-2540";

        //To View all employees details    
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

                    livre.Titre = rdr["Titre"].ToString();

                    lstLivre.Add(livre);
                }
                con.Close();
            }
            return lstLivre;
        }
    }
}