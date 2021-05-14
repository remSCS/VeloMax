using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ApplicationVeloMax.Models;
using MySql.Data.MySqlClient;

namespace ApplicationVeloMax.ViewModels
{
    public class DataAccess
    {
        static private string _connectionString;
        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        static private MySqlConnection GetConnection() => new MySqlConnection(_connectionString);

        static private MySqlCommand GetCorrectCommand(string param)
        {
            using (var connexion = GetConnection())
            {
                MySqlCommand com = new MySqlCommand("GetAllFromTable", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@tableName", MySqlDbType.VarChar).Value = param;
                return com;
            }
        }

        #region Getting data using SQL Stored Procedures
        static public void GetAllAdressesUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("adresse");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    string l2 = null;
                    string p = null;
                    if (DBNull.Value.Equals(i["ligne2Adresse"])) l2 = "";
                    else l2 = i.Field<string>("ligne2Adresse");
                    if (DBNull.Value.Equals(i["provinceAdresse"])) p = "";
                    else p = i.Field<string>("provinceAdresse");

                    new Adresse()
                    {
                        Id = i.Field<int>("idAdresse"),
                        Ligne1 = i.Field<string>("ligne1Adresse"),
                        Ligne2 = l2,
                        Ville = i.Field<string>("villeAdresse"),
                        CodePostal = i.Field<string>("codePostalAdresse"),
                        Province = p,
                        Pays = i.Field<string>("paysAdresse")
                    };
                }
            }
        }

        static public void GetAllContactsUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("contact");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Contact()
                    {
                        Id = i.Field<int>("idContact"),
                        Nom = i.Field<string>("nomContact"),
                        Prenom = i.Field<string>("prenomContact"),
                        Email = i.Field<string>("emailContact"),
                        Tel = i.Field<string>("telContact")
                    };
                }
            }
        }

        static public void GetAllLibellesUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("libelle");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Libelle()
                    {
                        Id = i.Field<int>("idLibelle"),
                        Nom = i.Field<string>("nomLibelle")
                    };
                }
            }
        }

        static public void GetAllGrandeursUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("grandeur");
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

        static public void GetAllLigneProduitsUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("ligneproduit");
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

        static public void GetAllFideliosUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("fidelio");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Fidelio()
                    {
                        Id = i.Field<int>("idFidelio"),
                        Nom = i.Field<string>("nomFidelio"),
                        Description = i.Field<string>("descriptionFidelioo"),
                        Cout = i.Field<decimal>("coutFidelio"),
                        Rabais = i.Field<decimal>("rabaisFidelio"),
                        DureeJours = i.Field<int>("dureeJoursFidelio")
                    };
                }
            }
        }

        static public void GetAllPiecesDetacheesUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("piecedetachee");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    DateTime dateS = new DateTime();
                    if (!DBNull.Value.Equals(i["dateSPiece"])) dateS = i.Field<DateTime>("dateSPiece");
                    new PieceDetachee()
                    {
                        Id = i.Field<int>("idPiece"),
                        Reference = i.Field<string>("refPiece"),
                        Nom = i.Field<string>("nomPiece"),
                        Description = i.Field<string>("descriptionPiece"),
                        DateE = i.Field<DateTime>("dateEPiece"),
                        DateS = dateS,
                        Quantite = i.Field<int>("quantitePiece")
                    };
                }
            }
        }

        static public void GetAllModelsUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("modele");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                List<Modele> modeles = new List<Modele>();

                foreach (DataRow i in dt.Rows)
                {
                    DateTime dateS = new DateTime();
                    if (!DBNull.Value.Equals(i["dateSModele"])) dateS = i.Field<DateTime>("dateSModele");
                    modeles.Add(new Modele(i.Field<int>("idGrandeur"), i.Field<int>("idLigneProduit"))
                    {
                        Id = i.Field<int>("idModele"),
                        Nom = i.Field<string>("nomModele"),
                        PrixUnitaire = i.Field<decimal>("prixUnitaireModele"),
                        Quantite = i.Field<int>("quantiteModele"),
                        DateE = i.Field<DateTime>("dateEModele"),
                        DateS = dateS
                    });
                    Console.WriteLine();
                }
            }

            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("composition");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                    Modele.Ensemble.Find(m => m.Id == i.Field<int>("idModele")).PiecesComposition.Add(PieceDetachee.Ensemble.Find(p => p.Id == i.Field<int>("idPieceDetachee")));
            }
        }

        static public void GetAllFournisseursUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("fournisseur");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Fournisseur(i.Field<int>("idContact"), i.Field<int>("idAdresse"), i.Field<int>("idLibelle"))
                    {
                        Siret = i.Field<int>("siretFournisseur"),
                        Nom = i.Field<string>("nomFournisseur")
                    };
                }
            }
        }

        static public void GetAllClientsPartsUsingSp()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("clientpart natural join client");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    DateTime dateA = new DateTime();
                    if (!DBNull.Value.Equals(i["dateAdheranceClient"])) dateA = i.Field<DateTime>("dateAdheranceClient");
                    int idF = 0;
                    DateTime dF = new DateTime();
                    if (!DBNull.Value.Equals(i["idFidelio"]))
                    {
                        idF = i.Field<int>("idFidelio");
                        dF = i.Field<DateTime>("dateDebutFidelio");
                    }
                    new ClientPart(
                        i.Field<int>("idAdresse"),
                        i.Field<int>("idContact"),
                        idF, dF)
                    {
                        Id = i.Field<int>("idClient"),
                        DateAdherance = dateA
                    };
                }
            }
        }

        static public void GetAllClientsProsUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("clientpro natural join client");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    DateTime dateA = new DateTime();
                    if (!DBNull.Value.Equals(i["dateAdheranceClient"])) dateA = i.Field<DateTime>("dateAdheranceClient");
                    new ClientPro(i.Field<int>("idAdresse"), i.Field<int>("idContact"))
                    {
                        Id = i.Field<int>("idClient"),
                        NomEntreprise = i.Field<string>("nomEntreprise"),
                        Remise = i.Field<decimal>("remise"),
                        DateAdherance = dateA
                    };
                }
            }
        }

        static public void GetAllClientsUsingSP()
        {
            GetAllClientsPartsUsingSp();
            GetAllClientsProsUsingSP();
        }

        static public void GetAllFournisseursPiecesUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("fournisseurpiece");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new FournisseurPiece(i.Field<int>("idPiece"), i.Field<int>("idFournisseur"))
                    {
                        Prix = i.Field<decimal>("prixPiece"),
                        Delai = i.Field<int>("delaiPiece"),
                        NumCatalogue = i.Field<string>("numCatalogue")
                    };
                }
            }
        }

        static public void GetAllCommandesUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("commande natural join statut");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    DateTime dateS = new DateTime();
                    if (!DBNull.Value.Equals(i["dateSCommande"])) dateS = i.Field<DateTime>("dateSCommande");
                    new Commande(i.Field<int>("idAdresse"), i.Field<int>("idClient"))
                    {
                        Id = i.Field<int>("idCommande"),
                        DateE = i.Field<DateTime>("dateECommande"),
                        DateS = dateS,
                        Statut = i.Field<string>("nomStatut")
                    };
                }
            }

            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("compocommandepiece");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                    for(int j = 0; j < i.Field<int>("quantite"); j++)
                        Commande.Ensemble.Find(c => c.Id == i.Field<int>("idCommande")).PiecesCommande.Add(PieceDetachee.Ensemble.Find(p => p.Id == i.Field<int>("idPiece")));
            }

            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("compocommandevelo");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                    for (int j = 0; j < i.Field<int>("quantite"); j++)
                        Commande.Ensemble.Find(c => c.Id == i.Field<int>("idCommande")).ModelesCommande.Add(Modele.Ensemble.Find(m => m.Id == i.Field<int>("idModele")));
            }
        }
        #endregion

        #region Removing data from server
        static public bool RemoveFromModeles(Modele toRemove)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveModele", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toRemove.Id;
                var reader = com.ExecuteReader();
                connexion.Close();
            }
            Modele.Ensemble.Clear();
            GetAllModelsUsingSP();
            return true;
        }

        static public bool RemoveFromClients(Client toRemove)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Commande.Ensemble.Exists(c => c.ClientCommande.Id == toRemove.Id) == false)
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("RemoveClient", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toRemove.Id;
                    var reader = com.ExecuteReader();
                    connexion.Close();
                    Client.Ensemble.Clear();
                    ClientPart.EnsembleParticuliers.Clear();
                    ClientPro.EnsemblePros.Clear();
                    GetAllClientsUsingSP();
                }
                else toReturn = false;
            }
            return toReturn;
        }
        #endregion

        static public bool ModifyStockModele(Modele toModify, int newStock)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("UpdateStockModele", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toModify.Id;
                com.Parameters.Add("@qte", MySqlDbType.Int64).Value = newStock;
                var reader = com.ExecuteReader();
                connexion.Close();
                Modele.Ensemble.Clear();
                GetAllModelsUsingSP();
            }
            return toReturn;
        }

        static public bool ModifyStockPiece(PieceDetachee toModify, int newStock)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("UpdateStockPiece", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toModify.Id;
                com.Parameters.Add("@qte", MySqlDbType.Int64).Value = newStock;
                var reader = com.ExecuteReader();
                connexion.Close();
                PieceDetachee.Ensemble.Clear();
                GetAllPiecesDetacheesUsingSP();
            }
            return toReturn;
        }

        static public void RefreshDBUsingSP()
        {
            GetAllAdressesUsingSP();
            GetAllContactsUsingSP();
            GetAllLibellesUsingSP();
            GetAllGrandeursUsingSP();
            GetAllLigneProduitsUsingSP();
            GetAllFideliosUsingSP();
            GetAllModelsUsingSP();
            GetAllPiecesDetacheesUsingSP();
            GetAllFournisseursUsingSP();
            GetAllClientsUsingSP();
            GetAllFournisseursPiecesUsingSP();
            GetAllCommandesUsingSP();
        }
    }
}