﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using ApplicationVeloMax.Models;

namespace ApplicationVeloMax
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Basic Initialization
            MySqlConnection cnn = null;
            try
            {
                string cs = "SERVER=84.102.235.128;PORT=3306;DATABASE=velomax;UID=RemoteAdmin;PASSWORD=Password@123";
                cnn = new MySqlConnection(cs);
                cnn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection Error : " + e.ToString());
                return;
            }
            MessageBox.Show("Connected successfully");
            #endregion

            GetAllGrandeurs(cnn);
            GetAllLigneProduits(cnn);
            GetAllModels(cnn);
            cnn.Close();
        }



        static void sqlRequest(MySqlConnection cnn, string request, List<MySqlParameter> parameters = null)
        {
            var cmd = new MySqlCommand(request, cnn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // Récupère les données
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string data = "";
                    if (!reader.IsDBNull(i))
                    {
                        data = reader.GetString(i);
                    }
                    Console.WriteLine(data);
                    if (i != reader.FieldCount) Console.Write(" ; ");
                    else Console.WriteLine();
                }
            }

            Console.WriteLine("Done");

            reader.Close();
            cmd.Dispose();
        }

        static void GetAllGrandeurs(MySqlConnection connexion)
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
            MessageBox.Show("Grandeur done");
        }

        static void GetAllLigneProduits(MySqlConnection connexion) 
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
            MessageBox.Show("Ligne Produit done");
        }

        static void GetAllModels(MySqlConnection connexion)
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
