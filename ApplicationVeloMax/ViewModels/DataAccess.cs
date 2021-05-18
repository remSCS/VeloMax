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

        static public bool TestConnectionString(string co,string nomdb,string id, string pw)
        {
            try
            {
                MySqlConnection c = new MySqlConnection($"SERVER ={ co }; PORT = 3306; DATABASE = {nomdb}; UID ={ id}; PASSWORD ={ pw}");
                c.Open();
            }
            catch(MySqlException e)
            {
                StringBuilder messageErreur = new StringBuilder(200);
                messageErreur.Append($"Votre tentative de connexion a échoué pour l'utilisateur \'{id}\' au serveur MySQL à {co}:3306:");
                messageErreur.Append(Environment.NewLine);
                messageErreur.Append($"Accès refusé pour l'utilisateur \'{id}\'@\'{co}\'");
                messageErreur.Append(Environment.NewLine);
                messageErreur.Append(Environment.NewLine);
                messageErreur.Append("\t\u2022 Vérifiez si le serveur est démarré");
                messageErreur.Append(Environment.NewLine);
                messageErreur.Append("\t\u2022 Vérifiez l'identifiant de l'utilisateur");
                messageErreur.Append(Environment.NewLine);
                messageErreur.Append("\t\u2022 Vérifiez le mot de passe");
                MessageBox.Show(messageErreur.ToString(),"Erreur de connexion", MessageBoxButton.OK,MessageBoxImage.Error);
                //MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }

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
                        Description = i.Field<string>("descriptionFidelio"),
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
                        Quantite = i.Field<int>("quantitePiece"),
                        PrixVente = i.Field<decimal>("prixVentePiece")
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
                        idF)
                    {
                        Id = i.Field<int>("idClient"),
                        DateAdherance = dateA,
                        DateDebutFidelio = dF
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
                MySqlCommand com = GetCorrectCommand("commande");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                {
                    DateTime dateS = new DateTime();
                    if (!DBNull.Value.Equals(i["dateSCommande"])) dateS = i.Field<DateTime>("dateSCommande");
                    int s = i.Field<int>("idStatut");
                    string str = "";
                    if (s == 1) str = "En cours de préparation";
                    if (s == 2) str = "Terminée";
                    if (s == 3) str = "Annulée";
                    new Commande(i.Field<int>("idAdresse"), i.Field<int>("idClient"), i.Field<int>("idStatut"))
                    {
                        Id = i.Field<int>("idCommande"),
                        DateE = i.Field<DateTime>("dateECommande"),
                        DateS = dateS,
                        Statut = str
                    };
                }
                Console.WriteLine(Commande.EnsembleAnnul);
            }

            using (var connexion = GetConnection())
            {
                DataTable dt = new DataTable();
                MySqlCommand com = GetCorrectCommand("compocommandepiece");
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);

                foreach (DataRow i in dt.Rows)
                    for (int j = 0; j < i.Field<int>("quantite"); j++)
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
            Console.WriteLine(Commande.EnsembleAnnul);
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
                try { com.ExecuteReader(); }
                catch { return false; }
            }
            Modele.Ensemble.Clear();
            GetAllModelsUsingSP();
            return true;
        }

        static public bool RemoveFromParts(PieceDetachee toRemove)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemovePiece", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toRemove.Id;
                try { com.ExecuteReader(); }
                catch { return false; }
            }
            PieceDetachee.Ensemble.Clear();
            GetAllPiecesDetacheesUsingSP();
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
                    try { com.ExecuteReader(); }
                    catch { return false; }
                    Client.Ensemble.Clear();
                    ClientPart.EnsembleParticuliers.Clear();
                    ClientPro.EnsemblePros.Clear();
                    GetAllClientsUsingSP();
                }
                else toReturn = false;
            }
            return toReturn;
        }

        static public bool RemoveFromOrders(Commande toRemove)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Commande.Ensemble.Exists(c => c.Id == toRemove.Id) == true)
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("RemoveCommande", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toRemove.Id;
                    try { com.ExecuteReader(); }
                    catch { return false; }
                    Commande.ClearEnsembles();
                    GetAllCommandesUsingSP();
                }
                else toReturn = false;
            }
            return toReturn;
        }

        static public bool RemoveFromFidelios(Fidelio toRemove)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveFidelio", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toRemove.Id;
                try { com.ExecuteReader(); }
                catch { return false; }
            }
            Fidelio.Ensemble.Clear();
            GetAllFideliosUsingSP();
            return true;
        }

        static public bool RemoveFromFournisseurs(Fournisseur toRemove)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveFournisseur", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@srt", MySqlDbType.Int64).Value = toRemove.Siret;
                try { com.ExecuteReader(); }
                catch { return false; }
            }
            Fournisseur.Ensemble.Clear();
            GetAllFournisseursUsingSP();
            return true;
        }

        static public bool RemoveFromFournisseurPiece(FournisseurPiece toRemove)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveFournisseurPiece", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idP", MySqlDbType.Int64).Value = toRemove.PieceDetacheeFournisseur.Id;
                com.Parameters.Add("@idF", MySqlDbType.Int64).Value = toRemove.FournisseurPieceDetachee.Siret;
                try { com.ExecuteReader(); }
                catch { return false; }
            }
            FournisseurPiece.Ensemble.Clear();
            GetAllFournisseursPiecesUsingSP();
            return true;
        }

        static public bool RemoveFromComposition(Modele mToRemove, PieceDetachee pToRemove)
        {
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveComposition", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idM", MySqlDbType.Int64).Value = mToRemove.Id;
                com.Parameters.Add("@idP", MySqlDbType.Int64).Value = pToRemove.Id;
                try { com.ExecuteReader(); }
                catch { return false; }
            }
            RefreshDBUsingSP();
            return true;
        }
        #endregion

        #region Editing data from server
        static public bool ModifyStockModele(Modele toModify, int newStock)
        {
            bool toReturn = true;
            if (newStock < 0) return false;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("UpdateStockModele", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toModify.Id;
                com.Parameters.Add("@qte", MySqlDbType.Int64).Value = newStock;
                var reader = com.ExecuteReader();
                Modele.Ensemble.Clear();
                GetAllModelsUsingSP();
            }
            return toReturn;
        }

        static public bool ModifyStockPiece(PieceDetachee toModify, int newStock)
        {
            bool toReturn = true;
            if (newStock < 0) return false;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("UpdateStockPiece", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@id", MySqlDbType.Int64).Value = toModify.Id;
                com.Parameters.Add("@qte", MySqlDbType.Int64).Value = newStock;
                var reader = com.ExecuteReader();
                PieceDetachee.Ensemble.Clear();
                GetAllPiecesDetacheesUsingSP();
            }
            return toReturn;
        }

        static public bool EditOrderStatus(Commande toRemove, int newStatusId)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Commande.Ensemble.Exists(c => c.Id == toRemove.Id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("UpdateCommandeStatut", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toRemove.Id;
                    com.Parameters.Add("@stat", MySqlDbType.Int64).Value = newStatusId;
                    com.ExecuteReader();
                    Commande.ClearEnsembles();
                    GetAllCommandesUsingSP();
                }
                else toReturn = false;
            }
            return toReturn;
        }

        static public bool FullyEditModele(int id, string nom, Grandeur grandeur, decimal prixUnitaire, LigneProduit ligneproduit, DateTime dateE, DateTime dateS)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Modele.Ensemble.Exists(m => m.Id == id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("EditModele", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                    com.Parameters.Add("@idG", MySqlDbType.Int64).Value = Grandeur.Ensemble.Find(g => g.Id == grandeur.Id).Id;
                    com.Parameters.Add("@prix", MySqlDbType.Decimal).Value = prixUnitaire;
                    com.Parameters.Add("@idL", MySqlDbType.Int64).Value = LigneProduit.Ensemble.Find(l => l.Id == ligneproduit.Id).Id;
                    com.Parameters.Add("@de", MySqlDbType.Date).Value = dateE;
                    com.Parameters.Add("@ds", MySqlDbType.Date).Value = dateS;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    Modele.Ensemble.Clear();
                    GetAllModelsUsingSP();
                }
            }
            return toReturn;
        }

        static public bool FullyEditPiece(int id, string reference, string nom, string description, DateTime dateE, DateTime dateS, decimal prix)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (PieceDetachee.Ensemble.Exists(p => p.Id == id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("EditPiece", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                    com.Parameters.Add("@ref", MySqlDbType.VarChar).Value = reference;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                    com.Parameters.Add("@d", MySqlDbType.VarChar).Value = description;
                    com.Parameters.Add("@de", MySqlDbType.Date).Value = dateE;
                    com.Parameters.Add("@ds", MySqlDbType.Date).Value = dateS;
                    com.Parameters.Add("@prix", MySqlDbType.Decimal).Value = prix;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    PieceDetachee.Ensemble.Clear();
                    GetAllPiecesDetacheesUsingSP();
                }
            }
            return toReturn;
        }

        static public bool FullyEditFidelio(int id, string nom, string description, decimal cout, decimal rabais, int duree)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Fidelio.Ensemble.Exists(m => m.Id == id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("EditFidelio", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                    com.Parameters.Add("@d", MySqlDbType.VarChar).Value = description;
                    com.Parameters.Add("@cout", MySqlDbType.Decimal).Value = cout;
                    com.Parameters.Add("@rabais", MySqlDbType.Decimal).Value = rabais;
                    com.Parameters.Add("@duree", MySqlDbType.Int64).Value = duree;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool FullyEditClientPart(int id, DateTime adherance, string nom, string prenom, string tel, string mail, string l1, string l2, string cp, string ville, string province, string pays, int idFidelio, DateTime dateFidelio)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Client.Ensemble.Exists(c => c.Id == id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("EditClientPart", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = ClientPart.Ensemble.Find(c => c.Id == id).ContactClient.Id;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = ClientPart.Ensemble.Find(c => c.Id == id).AdresseClient.Id;
                    com.Parameters.Add("@idF", MySqlDbType.Int64).Value = idFidelio;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                    com.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
                    com.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel;
                    com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = l1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = l2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = cp;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = pays;
                    com.Parameters.Add("@adherance", MySqlDbType.Date).Value = adherance;
                    com.Parameters.Add("@df", MySqlDbType.Date).Value = dateFidelio;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool FullyEditClientPro(int id, DateTime adherance, string nom, string prenom, string tel, string mail, string l1, string l2, string cp, string ville, string province, string pays, string entreprise, decimal remise)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Client.Ensemble.Exists(c => c.Id == id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("EditClientPro", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = ClientPart.Ensemble.Find(c => c.Id == id).ContactClient.Id;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = ClientPart.Ensemble.Find(c => c.Id == id).AdresseClient.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                    com.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
                    com.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel;
                    com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = l1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = l2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = cp;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = pays;
                    com.Parameters.Add("@adherance", MySqlDbType.Date).Value = adherance;
                    com.Parameters.Add("@entreprise", MySqlDbType.VarChar).Value = entreprise;
                    com.Parameters.Add("@rem", MySqlDbType.Decimal).Value = remise;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool FullyEditFournisseur(int siret, int idLibelle, string nomFournisseur, string nom, string prenom, string tel, string mail, string l1, string l2, string cp, string ville, string province, string pays)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Fournisseur.Ensemble.Exists(f => f.Siret == siret))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("EditFournisseur", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@siret", MySqlDbType.Int64).Value = siret;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = Fournisseur.Ensemble.Find(f => f.Siret == siret).ContactFournisseur.Id;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = Fournisseur.Ensemble.Find(f => f.Siret == siret).AdresseFournisseur.Id;
                    com.Parameters.Add("@idL", MySqlDbType.Int64).Value = Fournisseur.Ensemble.Find(f => f.Siret == siret).LibelleFournisseur.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                    com.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
                    com.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel;
                    com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = l1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = l2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = cp;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = pays;
                    com.Parameters.Add("@nomF", MySqlDbType.VarChar).Value = nomFournisseur;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }
       
        static public bool AddModeleCompositionCommande(Commande selCom, Modele selMod, int quantity)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("AddModeleToCommande", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idC", MySqlDbType.Int64).Value = selCom.Id;
                com.Parameters.Add("@idM", MySqlDbType.Int64).Value = selMod.Id;
                com.Parameters.Add("@qte", MySqlDbType.Int64).Value = quantity;
                try { com.ExecuteReader(); }
                catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
            }
            RefreshDBUsingSP();
            return toReturn;
        }

        static public bool AddPieceCompositionCommande(Commande selCom, PieceDetachee selPart, int quantity)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("AddPieceToCommande", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idC", MySqlDbType.Int64).Value = selCom.Id;
                com.Parameters.Add("@idP", MySqlDbType.Int64).Value = selPart.Id;
                com.Parameters.Add("@qte", MySqlDbType.Int64).Value = quantity;
                try { com.ExecuteReader(); }
                catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
            }
            RefreshDBUsingSP();
            return toReturn;
        }

        static public bool RemoveModeleCompositionCommande(Commande selCom, Modele selMod)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveOneModeleFromCommande", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idC", MySqlDbType.Int64).Value = selCom.Id;
                com.Parameters.Add("@idM", MySqlDbType.Int64).Value = selMod.Id;
                try { com.ExecuteReader(); }
                catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
            }
            RefreshDBUsingSP();
            return toReturn;
        }

        static public bool RemovePieceCompositionCommande(Commande selCom, PieceDetachee selPart)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("RemoveOnePieceFromCommande", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idC", MySqlDbType.Int64).Value = selCom.Id;
                com.Parameters.Add("@idP", MySqlDbType.Int64).Value = selPart.Id;
                try { com.ExecuteReader(); }
                catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
            }
            RefreshDBUsingSP();
            return toReturn;
        }
        #endregion

        #region Adding data to server
        static public bool AddPiece(PieceDetachee toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (PieceDetachee.Ensemble.Exists(p => p.Id == toAdd.Id) == true)
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreatePiece", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toAdd.Id;
                    com.Parameters.Add("@ref", MySqlDbType.VarChar).Value = toAdd.Reference;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = toAdd.Nom;
                    com.Parameters.Add("@d", MySqlDbType.VarChar).Value = toAdd.Description;
                    com.Parameters.Add("@de", MySqlDbType.Date).Value = toAdd.DateE;
                    com.Parameters.Add("@ds", MySqlDbType.Date).Value = toAdd.DateS;
                    com.Parameters.Add("@qte", MySqlDbType.Int64).Value = toAdd.Quantite;
                    com.Parameters.Add("@prix", MySqlDbType.Decimal).Value = toAdd.PrixVente;
                    try { com.ExecuteReader(); }
                    catch { return false; }
                    RefreshDBUsingSP();
                }
                else toReturn = false;
            }
            return toReturn;
        }

        static public bool AddModele(Modele toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Modele.Ensemble.Exists(p => p.Id == toAdd.Id) == true)
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreateModele", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toAdd.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = toAdd.Nom;
                    com.Parameters.Add("@idG", MySqlDbType.Int64).Value = toAdd.GrandeurModele.Id;
                    com.Parameters.Add("@idL", MySqlDbType.Int64).Value = toAdd.LigneProduitModele.Id;
                    com.Parameters.Add("@prix", MySqlDbType.Decimal).Value = toAdd.PrixUnitaire;
                    com.Parameters.Add("@de", MySqlDbType.Date).Value = toAdd.DateE;
                    com.Parameters.Add("@ds", MySqlDbType.Date).Value = toAdd.DateS;
                    com.Parameters.Add("@qte", MySqlDbType.Int64).Value = toAdd.Quantite;
                    try { com.ExecuteReader(); }
                    catch { return false; }
                    RefreshDBUsingSP();
                }
                else toReturn = false;
            }
            return toReturn;
        }

        static public bool AddFidelio(Fidelio toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Fidelio.Ensemble.Exists(m => m.Id == toAdd.Id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreateFidelio", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toAdd.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = toAdd.Nom;
                    com.Parameters.Add("@d", MySqlDbType.VarChar).Value = toAdd.Description;
                    com.Parameters.Add("@cout", MySqlDbType.Decimal).Value = toAdd.Cout;
                    com.Parameters.Add("@rabais", MySqlDbType.Decimal).Value = toAdd.Rabais;
                    com.Parameters.Add("@duree", MySqlDbType.Int64).Value = toAdd.DureeJours;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool AddClientPro(ClientPro toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Client.Ensemble.Exists(c => c.Id == toAdd.Id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreateClientPro", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toAdd.Id;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = toAdd.ContactClient.Id;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = toAdd.AdresseClient.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = toAdd.ContactClient.Nom;
                    com.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = toAdd.ContactClient.Prenom;
                    com.Parameters.Add("@tel", MySqlDbType.VarChar).Value = toAdd.ContactClient.Tel;
                    com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = toAdd.ContactClient.Email;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Ligne1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Ligne2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = toAdd.AdresseClient.CodePostal;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Pays;
                    com.Parameters.Add("@adherance", MySqlDbType.Date).Value = toAdd.DateAdherance;
                    com.Parameters.Add("@entreprise", MySqlDbType.VarChar).Value = toAdd.NomEntreprise;
                    com.Parameters.Add("@rem", MySqlDbType.Decimal).Value = toAdd.Remise;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool AddClientPart(ClientPart toAdd, int idFidelio)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Client.Ensemble.Exists(c => c.Id == toAdd.Id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreateClientPart", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toAdd.Id;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = toAdd.ContactClient.Id;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = toAdd.AdresseClient.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = toAdd.ContactClient.Nom;
                    com.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = toAdd.ContactClient.Prenom;
                    com.Parameters.Add("@tel", MySqlDbType.VarChar).Value = toAdd.ContactClient.Tel;
                    com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = toAdd.ContactClient.Email;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Ligne1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Ligne2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = toAdd.AdresseClient.CodePostal;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = toAdd.AdresseClient.Pays;
                    com.Parameters.Add("@adherance", MySqlDbType.Date).Value = toAdd.DateAdherance;
                    com.Parameters.Add("@idF", MySqlDbType.Int64).Value = idFidelio;
                    com.Parameters.Add("@df", MySqlDbType.Date).Value = toAdd.DateDebutFidelio;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool AddFournisseur(Fournisseur toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Fournisseur.Ensemble.Exists(c => c.Siret == toAdd.Siret))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreateFournisseur", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@siret", MySqlDbType.Int64).Value = toAdd.Siret;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = toAdd.ContactFournisseur.Id;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = toAdd.AdresseFournisseur.Id;
                    com.Parameters.Add("@idL", MySqlDbType.Int64).Value = toAdd.LibelleFournisseur.Id;
                    com.Parameters.Add("@nom", MySqlDbType.VarChar).Value = toAdd.ContactFournisseur.Nom;
                    com.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = toAdd.ContactFournisseur.Prenom;
                    com.Parameters.Add("@tel", MySqlDbType.VarChar).Value = toAdd.ContactFournisseur.Tel;
                    com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = toAdd.ContactFournisseur.Email;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = toAdd.AdresseFournisseur.Ligne1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = toAdd.AdresseFournisseur.Ligne2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = toAdd.AdresseFournisseur.CodePostal;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = toAdd.AdresseFournisseur.Ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = toAdd.AdresseFournisseur.Province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = toAdd.AdresseFournisseur.Pays;
                    com.Parameters.Add("@nomF", MySqlDbType.VarChar).Value = toAdd.Nom;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool AddCommande(Commande toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                if (Commande.Ensemble.Exists(c => c.Id == toAdd.Id))
                {
                    connexion.Open();
                    MySqlCommand com = new MySqlCommand("CreateCommande", connexion) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.Add("@id", MySqlDbType.Int64).Value = toAdd.Id;
                    com.Parameters.Add("@dE", MySqlDbType.Date).Value = toAdd.DateE;
                    com.Parameters.Add("@dS", MySqlDbType.Date).Value = toAdd.DateS;
                    com.Parameters.Add("@idC", MySqlDbType.Int64).Value = toAdd.ClientCommande.Id;
                    com.Parameters.Add("@idS", MySqlDbType.Int64).Value = 1;
                    com.Parameters.Add("@idA", MySqlDbType.Int64).Value = toAdd.AdresseLivraison.Id;
                    com.Parameters.Add("@l1", MySqlDbType.VarChar).Value = toAdd.AdresseLivraison.Ligne1;
                    com.Parameters.Add("@l2", MySqlDbType.VarChar).Value = toAdd.AdresseLivraison.Ligne2;
                    com.Parameters.Add("@cp", MySqlDbType.VarChar).Value = toAdd.AdresseLivraison.CodePostal;
                    com.Parameters.Add("@ville", MySqlDbType.VarChar).Value = toAdd.AdresseLivraison.Ville;
                    com.Parameters.Add("@province", MySqlDbType.VarChar).Value = toAdd.AdresseLivraison.Province;
                    com.Parameters.Add("@pays", MySqlDbType.VarChar).Value = toAdd.AdresseLivraison.Pays;
                    try { com.ExecuteReader(); }
                    catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                    RefreshDBUsingSP();
                }
            }
            return toReturn;
        }

        static public bool AddFournisseurPiece(FournisseurPiece toAdd)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("CreateFournisseurPiece", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idF", MySqlDbType.Int64).Value = toAdd.FournisseurPieceDetachee.Siret;
                com.Parameters.Add("@idP", MySqlDbType.Int64).Value = toAdd.PieceDetacheeFournisseur.Id;
                com.Parameters.Add("@prix", MySqlDbType.Decimal).Value = toAdd.Prix;
                com.Parameters.Add("@delai", MySqlDbType.Int64).Value = toAdd.Delai;
                com.Parameters.Add("@noC", MySqlDbType.VarChar).Value = toAdd.NumCatalogue;
                try { com.ExecuteReader(); }
                catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                RefreshDBUsingSP();

            }
            return toReturn;
        }

        static public bool AddCompositionPieceModele(Modele toAdd, PieceDetachee piece)
        {
            bool toReturn = true;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("CreateComposition", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@idM", MySqlDbType.Int64).Value = toAdd.Id;
                com.Parameters.Add("@idP", MySqlDbType.Int64).Value = piece.Id;
                try { com.ExecuteReader(); }
                catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
            }
            RefreshDBUsingSP();
            return toReturn;
        }
        #endregion

        static public void RefreshDBUsingSP()
        {
            Adresse.Ensemble.Clear();
            Client.Ensemble.Clear();
            ClientPart.EnsembleParticuliers.Clear();
            ClientPro.EnsemblePros.Clear();
            Commande.ClearEnsembles();
            Contact.Ensemble.Clear();
            Fidelio.Ensemble.Clear();
            Fournisseur.Ensemble.Clear();
            FournisseurPiece.Ensemble.Clear();
            Grandeur.Ensemble.Clear();
            Libelle.Ensemble.Clear();
            LigneProduit.Ensemble.Clear();
            Modele.Ensemble.Clear();
            PieceDetachee.Ensemble.Clear();

            GetAllAdressesUsingSP();
            GetAllContactsUsingSP();
            GetAllLibellesUsingSP();
            GetAllGrandeursUsingSP();
            GetAllLigneProduitsUsingSP();
            GetAllFideliosUsingSP();
            GetAllPiecesDetacheesUsingSP();
            GetAllModelsUsingSP();
            GetAllFournisseursUsingSP();
            GetAllClientsUsingSP();
            GetAllFournisseursPiecesUsingSP();
            GetAllCommandesUsingSP();
        }

        static public int GetHighestId(string tableName)
        {
            int toReturn = 0;
            using (var connexion = GetConnection())
            {
                connexion.Open();
                MySqlCommand com = new MySqlCommand("HighestId", connexion) { CommandType = CommandType.StoredProcedure };
                com.Parameters.Add("@tableName", MySqlDbType.VarChar).Value = tableName;
                var returnedParameter = com.Parameters.Add("@n", MySqlDbType.Int64);
                returnedParameter.Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                toReturn = Convert.ToInt32(returnedParameter.Value);
            }
            return toReturn;
        }
    }
}