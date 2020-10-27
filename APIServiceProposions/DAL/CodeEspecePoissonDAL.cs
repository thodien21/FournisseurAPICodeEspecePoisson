using APIServiceProposions.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIServiceProposions.DAL
{
    public class CodeEspecePoissonDAL
    {
        public static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TutorialDB;Integrated Security=True";

        public List<CodeEspecePoisson> GetAllPoisson()
        {
            var allpoissons = new List<CodeEspecePoisson>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = sqlConnection.CreateCommand())
                {
                    sqlCmd.CommandText = "select * from dbo.CodeEspecePoisson";
                    var reader = sqlCmd.ExecuteReader();
                    while(reader.Read())
                    {
                        allpoissons.Add(new CodeEspecePoisson()
                        {
                            Code = (string)reader["code"],
                            Code_Taxon = (int)reader["code_taxon"],
                            Nom_Commun = (string)reader["nom_commun"],
                            Nom_Latin = (string)reader["nom_latin"],
                            Statut = (string)reader["statut"],
                            Uri_Taxon = (string)reader["uri_taxon"],
                        });
                    }
                }
            }
            return allpoissons;
        }
    }
}