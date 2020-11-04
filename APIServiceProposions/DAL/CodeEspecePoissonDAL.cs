using APIServiceProposions.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                            Nom_Commun = (string)reader["nom_commun"],
                            Nom_Latin = (string)reader["nom_latin"],
                            Code_Taxon = (int)reader["code_taxon"],
                            Uri_Taxon = (string)reader["uri_taxon"],
                            Statut = (string)reader["statut"]
                        });
                    }
                }
            }
            return allpoissons;
        }

        public void InsertPoisson(CodeEspecePoisson poisson)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = sqlConnection.CreateCommand())
                {
                    sqlCmd.CommandText = "insert into dbo.CodeEspecePoisson values(@codetaxon, @code, @nomcommun, @nomlatin, @uritaxon, @statut)";
                    sqlCmd.Parameters.AddWithValue("@codetaxon", poisson.Code_Taxon);
                    sqlCmd.Parameters.AddWithValue("@code", poisson.Code);
                    sqlCmd.Parameters.AddWithValue("@nomcommun", poisson.Nom_Commun);
                    sqlCmd.Parameters.AddWithValue("@nomlatin", poisson.Nom_Latin);
                    sqlCmd.Parameters.AddWithValue("@uritaxon", poisson.Uri_Taxon);
                    sqlCmd.Parameters.AddWithValue("@statut", poisson.Statut);
                    try
                    {
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (InvalidCastException e)
                    {
                        throw new Exception("Problème d'ordre des valeurs attribuées aux collones : ", e);
                    }
                }
            }
        }

        public void UpdatePoissons(int id, CodeEspecePoisson poisson)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = sqlConnection.CreateCommand())
                {
                    sqlCmd.CommandText = "update dbo.CodeEspecePoisson set code = @code, nom_commun = @nomcommun, " +
                        "nom_latin = @nomlatin, uri_taxon = @uritaxon, statut = @statut " +
                        "where code_taxon = @id";
                    sqlCmd.Parameters.AddWithValue("@code", poisson.Code);
                    sqlCmd.Parameters.AddWithValue("@nomcommun", poisson.Nom_Commun);
                    sqlCmd.Parameters.AddWithValue("@nomlatin", poisson.Nom_Latin);
                    sqlCmd.Parameters.AddWithValue("@uritaxon", poisson.Uri_Taxon);
                    sqlCmd.Parameters.AddWithValue("@statut", poisson.Statut);
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePoisson(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = sqlConnection.CreateCommand())
                {
                    sqlCmd.CommandText = "delete from dbo.CodeEspecePoisson where code_taxon = @id";
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }
    }
}