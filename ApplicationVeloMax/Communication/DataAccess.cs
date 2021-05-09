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

        static public void GetAllAdresses()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from adresse;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Adresse()
                    {
                        Id = i.Field<int>("idAdresse"),
                        Ligne1 = i.Field<string>("ligne1Adresse"),
                        Ligne2 = i.Field<string>("ligne2Adresse"),
                        Ville = i.Field<string>("villeAdresse"),
                        CodePostal = i.Field<string>("codePostalAdresse"),
                        Province = i.Field<string>("provinceAdresse"),
                        Pays = i.Field<string>("paysAdresse") };
                } 
            }
        }

        static public void GetAllContacts()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from contact;", connexion);
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

        static public void GetAllLibelles()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from libelle;", connexion);
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

        static public void GetAllFidelios()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from fidelio;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Fidelio()
                    {
                        Id = i.Field<int>("idFidelio"),
                        Nom = i.Field<string>("nomFidelio"),
                        Description = i.Field<string>("descriptionFidelio"),
                        Cout = i.Field<decimal>("coutFidelio"),
                        Rabais = i.Field<decimal>("rabaisFidelio"),
                        DureeJours = i.Field<int>("dureeJoursFidelio")
                    };
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

                Console.WriteLine("NOmbre de grandeurs : " + Grandeur.Ensemble.Count());

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

        static public void GetAllPiecesDetachees()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from piecedetachee;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new PieceDetachee()
                    {
                        Id = i.Field<int>("idPiece"),
                        Reference = i.Field<string>("refPiece"),
                        Nom = i.Field<string>("nomPiece"),
                        Description = i.Field<string>("descriptionPiece"),
                        DateE = i.Field<DateTime>("dateEPiece"),
                        DateS = i.Field<DateTime>("dateSPiece"),
                        Quantite = i.Field<int>("quantitePiece")
                    };
                }
            }
        }

        static public void GetAllFournisseurs()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from fournisseur;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Fournisseur(i.Field<int>("idContact"), i.Field<int>("idAdresse"), i.Field<int>("idLibelle"))
                    {
                        Siret = i.Field<int>("idPiece"),
                        Nom = i.Field<string>("refPiece")
                    };
                }
            }
        }

        static public void GetAllClientsPart()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from clientpart;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new ClientPart(i.Field<int>("idFidelio"))
                    {
                        Id = i.Field<int>("idClientPart"),
                        DateDebutFidelio = i.Field<DateTime>("dateDebutFidelio")
                    };
                }
            }
        }

        static public void GetAllClientsPro()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from clientpro;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new ClientPro()
                    {
                        Id = i.Field<int>("idClientPro"),
                        NomEntreprise = i.Field<string>("nomEntreprise"),
                        Remise = i.Field<decimal>("remise")
                    };
                }
            }
        }

        static public void GetAllClients()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from client;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Client(i.Field<int>("idAdresse"),
                        i.Field<int>("idContact"),
                        i.Field<int>("idClientPart"),
                        i.Field<int>("idClientPro"))
                    {
                        Id = i.Field<int>("idClient")
                    };
                }
            }
        }

        static public void GetAllFournisseursPieces()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from fournisseurpiece;", connexion);
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

        static public void GetAllCompositions()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from composition;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Composition(i.Field<int>("idModele"), i.Field<int>("idPieceDetachee"));
                }
            }
        }

        static public void GetAllCommandes()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from commande;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Commande(i.Field<int>("idAdresse"), i.Field<int>("idClient"))
                    {
                        Id = i.Field<int>("idCommande"),
                        DateE = i.Field<DateTime>("dateECommande"),
                        DateS = i.Field<DateTime>("dateSCommande")
                    };
                }
            }
        }

        static public void GetAllComposCommandesPieces()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from compocommandepieces;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new CompoCommandePieces(i.Field<int>("idCommande"), i.Field<int>("idPiece"))
                    {
                        Quantite = i.Field<int>("quantite")
                    };
                }
            }
        }

        static public void GetAllComposCommandesVelos()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("select * from compocommandevelo;", connexion);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new CompoCommandeVelo(i.Field<int>("idCommande"), i.Field<int>("idModele"))
                    {
                        Quantite = i.Field<int>("quantite")
                    };
                }
            }
        }

        static public void RefreshDB()
        {
            //DataAccess.GetAllAdresses();
            GetAdressesUsingSP();
            GetAllContacts();
            GetAllLibelles();
            GetAllGrandeurs();
            GetAllLigneProduits();
            GetAllFidelios();
            GetAllModels();
            GetAllPiecesDetachees();
            GetAllFournisseurs();
            GetAllClientsPart();
            GetAllClientsPro();
            GetAllClients();
            GetAllFournisseursPieces();
            GetAllCompositions();
            GetAllCommandes();
            GetAllComposCommandesPieces();
            GetAllComposCommandesVelos();
        }

        static public void GetAdressesUsingSP()
        {
            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand("GetAdresses", connexion) { CommandType = CommandType.StoredProcedure };
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    new Adresse()
                    {
                        Id = i.Field<int>("idAdresse"),
                        Ligne1 = i.Field<string>("ligne1Adresse"),
                        Ligne2 = i.Field<string>("ligne2Adresse"),
                        Ville = i.Field<string>("villeAdresse"),
                        CodePostal = i.Field<string>("codePostalAdresse"),
                        Province = i.Field<string>("provinceAdresse"),
                        Pays = i.Field<string>("paysAdresse")
                    };
                }
            }
        }
    }
}
