using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ApplicationVeloMax.Models;
using MySql.Data.MySqlClient;

namespace ApplicationVeloMax.Communication
{
    public class DataAccess
    {
        static private string _connectionString;
        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        static MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(_connectionString);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection Error : " + e.ToString());
            }
            return new MySqlConnection(_connectionString);
        }

        static public void GetAllGrandeurs()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from grandeur;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                List<Grandeur> grandeurs = new List<Grandeur>();
                foreach (DataRow i in dt.Rows)
                {
                    grandeurs.Add(new Grandeur()
                    {
                        Id = i.Field<int>("idGrandeur"),
                        Nom = i.Field<string>("nomGrandeur")
                    });
                }
            }
        }

        static public void GetAllLigneProduits()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from LigneProduit;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                List<LigneProduit> lignesProduits = new List<LigneProduit>();

                foreach (DataRow i in dt.Rows)
                {
                    lignesProduits.Add(new LigneProduit()
                    {
                        Id = i.Field<int>("idLigneProduit"),
                        Nom = i.Field<string>("nomLigneProduit")
                    });
                }
            }
        }

        static public void GetAllModels()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from modele;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                List<Modele> modeles = new List<Modele>();

                Console.WriteLine("NOmbre de grandeurs : " + Grandeur.ensembleGrandeurs.Count());

                foreach (DataRow i in dt.Rows)
                {
                    modeles.Add(new Modele(i.Field<int>("idGrandeur"), i.Field<int>("idLigneProduit"))
                    {
                        Id = i.Field<int>("idModele"),
                        Nom = i.Field<string>("nomModele"),
                        PrixUnitaire = i.Field<decimal>("prixUnitaireModele"),
                        Quantite = i.Field<int>("quantiteModele"),
                        DateE = i.Field<DateTime>("dateEModele"),
                        DateS = i.Field<DateTime>("dateSModele"),
                    });
                    Console.WriteLine();
                }

                foreach (var m in modeles) Console.WriteLine(m);
            }
        }
    }
}
