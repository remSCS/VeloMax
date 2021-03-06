using System;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using ApplicationVeloMax.ViewModels;
using ApplicationVeloMax.Views.Commandes;
using ApplicationVeloMax.Views.Modeles;
using ApplicationVeloMax.Views.Pieces;
using ApplicationVeloMax.Views.Stock;
using ApplicationVeloMax.Views.Fidelios;
using ApplicationVeloMax.Views.Clients;
using ApplicationVeloMax.Views.Fournisseurs;
using ApplicationVeloMax.Views.Statistiques;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ApplicationVeloMax.Views
{
    public partial class AdminView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region ViewModels
        #region Modèles
        private ObservableCollection<Modele> _modeles;
        public ObservableCollection<Modele> Modeles
        {
            get { return _modeles; }
            set
            {
                _modeles = value;
                ModelesStock = new ObservableCollection<Modele>(Modele.Ensemble.FindAll(p => p.Quantite <= 2));
                PropertyChanged(this, new PropertyChangedEventArgs("Modeles"));
            }
        }

        private ObservableCollection<Modele> _modelesStock;
        public ObservableCollection<Modele> ModelesStock
        {
            get { return _modelesStock; }
            set
            {
                _modelesStock = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ModelesStock"));
            }
        }

        private Modele _selectedModele;
        public Modele SelectedModele
        {
            get { return _selectedModele; }
            set { _selectedModele = value; }
        }

        private string _searchModelText;

        public string SearchModelText
        {
            get { return _searchModelText; }
            set
            {
                _searchModelText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchModelText"));
                Modeles = new ObservableCollection<Modele>(Modele.ModelesThatMatch(SearchModelText));
            }
        }

        #endregion

        #region Adresses
        private ObservableCollection<Adresse> _adresses;
        public ObservableCollection<Adresse> Adresses
        {
            get { return _adresses; }
            set
            {
                _adresses = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Adresses"));
            }
        }
        #endregion

        #region Grandeurs
        private ObservableCollection<Grandeur> _grandeurs;
        public ObservableCollection<Grandeur> Grandeurs
        {
            get { return _grandeurs; }
            set
            {
                _grandeurs = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Grandeurs"));
            }
        }
        #endregion

        #region Lignes Produits
        private ObservableCollection<LigneProduit> _lignesProduits;
        public ObservableCollection<LigneProduit> LignesProduits
        {
            get { return _lignesProduits; }
            set
            {
                _lignesProduits = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LignesProduits"));
            }
        }
        #endregion

        #region Commandes
        private ObservableCollection<Commande> _commandes;
        public ObservableCollection<Commande> Commandes
        {
            get { return _commandes; }
            set
            {
                _commandes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Commandes"));
            }
        }

        private ObservableCollection<Commande> _commandesAnnul;
        public ObservableCollection<Commande> CommandesAnnul
        {
            get { return _commandesAnnul; }
            set
            {
                _commandesAnnul = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CommandesAnnul"));
            }
        }

        private ObservableCollection<Commande> _commandesPrep;
        public ObservableCollection<Commande> CommandesPrep
        {
            get { return _commandesPrep; }
            set
            {
                _commandesPrep = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CommandesPrep"));
            }
        }

        private ObservableCollection<Commande> _commandesDone;
        public ObservableCollection<Commande> CommandesDone
        {
            get { return _commandesDone; }
            set
            {
                _commandesDone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CommandesDone"));
            }
        }

        private Commande _selectedCommande = new Commande();
        public Commande SelectedCommande
        {
            get { return _selectedCommande; }
            set
            {
                _selectedCommande = value;
                if (SelectedCommande != null && CommandesPrep.Contains(SelectedCommande)) { cancelOrderButton.Visibility = Visibility.Visible; commandesModifierButton.Visibility = Visibility.Visible; setOrderDoneButton.Visibility = Visibility.Visible; }
                else { cancelOrderButton.Visibility = Visibility.Hidden; commandesModifierButton.Visibility = Visibility.Hidden; setOrderDoneButton.Visibility = Visibility.Hidden; }
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommande"));
            }
        }

        private Commande _selectedCommandeCancelled = new Commande();
        public Commande SelectedCommandeCancelled
        {
            get { return _selectedCommandeCancelled; }
            set
            {
                _selectedCommandeCancelled = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommandeCancelled"));
            }
        }

        private Commande _selectedCommandeToDo = new Commande();
        public Commande SelectedCommandeToDo
        {
            get { return _selectedCommandeToDo; }
            set
            {
                _selectedCommandeToDo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommandeToDo"));
            }
        }

        private Commande _selectedCommandeDone = new Commande();
        public Commande SelectedCommandeDone
        {
            get { return _selectedCommandeDone; }
            set
            {
                _selectedCommandeDone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommandeDone"));
            }
        }

        private string _searchCommandeText;

        public string SearchCommandeText
        {
            get { return _searchCommandeText; }
            set
            {
                _searchCommandeText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchCommandeText"));
                Commandes = new ObservableCollection<Commande>(Commande.CommandesThatMatch(SearchCommandeText));
            }
        }

        #endregion

        #region Pièces
        private ObservableCollection<PieceDetachee> _piecesDetachees;
        public ObservableCollection<PieceDetachee> PiecesDetachees
        {
            get { return _piecesDetachees; }
            set
            {
                _piecesDetachees = value;
                PiecesDetacheesStock = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble.FindAll(p => p.Quantite <= 2));
                PropertyChanged(this, new PropertyChangedEventArgs("PiecesDetachees"));
            }
        }

        private ObservableCollection<PieceDetachee> _piecesDetacheesStock;
        public ObservableCollection<PieceDetachee> PiecesDetacheesStock
        {
            get { return _piecesDetacheesStock; }
            set
            {
                _piecesDetacheesStock = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PiecesDetacheesStock"));
            }
        }

        private PieceDetachee _selectedPiece;
        public PieceDetachee SelectedPiece
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPiece"));
            }
        }

        private PieceDetachee _selectedPieceStock;
        public PieceDetachee SelectedPieceStock
        {
            get { return _selectedPieceStock; }
            set
            {
                _selectedPieceStock = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPieceStock"));
            }
        }

        private string _searchPieceText;

        public string SearchPieceText
        {
            get { return _searchPieceText; }
            set
            {
                _searchPieceText = value;
                PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.PiecesThatMatch(SearchPieceText));
            }
        }

        #endregion

        #region Fournisseurs
        private ObservableCollection<Fournisseur> _fournisseurs;
        public ObservableCollection<Fournisseur> Fournisseurs
        {
            get { return _fournisseurs; }
            set
            {
                _fournisseurs = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Fournisseurs"));
            }
        }

        private Fournisseur _selectedFournisseur;
        public Fournisseur SelectedFournisseur
        {
            get { return _selectedFournisseur; }
            set
            {
                _selectedFournisseur = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedFournisseur"));
            }
        }

        private string _searchFournisseursText;

        public string SearchFournisseursText
        {
            get { return _searchFournisseursText; }
            set
            {
                _searchFournisseursText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchFournisseursText"));
                Fournisseurs = new ObservableCollection<Fournisseur>(Fournisseur.FournisseursThatMatch(SearchFournisseursText));
            }
        }

        #endregion

        #region Fidelios
        private ObservableCollection<Fidelio> _fidelios;
        public ObservableCollection<Fidelio> Fidelios
        {
            get { return _fidelios; }
            set
            {
                _fidelios = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Fidelios"));
            }
        }

        private Fidelio _selectedFidelio;
        public Fidelio SelectedFidelio
        {
            get { return _selectedFidelio; }
            set { _selectedFidelio = value; }
        }
        #endregion

        #region Clients
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Clients"));
                ClientsParts = new ObservableCollection<ClientPart>(ClientPart.EnsembleParticuliers);
                ClientsPros = new ObservableCollection<ClientPro>(ClientPro.EnsemblePros);
            }
        }

        private ObservableCollection<ClientPart> _clientsParts;
        public ObservableCollection<ClientPart> ClientsParts
        {
            get { return _clientsParts; }
            set
            {
                _clientsParts = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClientsParts"));
            }
        }

        private ObservableCollection<ClientPro> _clientsPros;
        public ObservableCollection<ClientPro> ClientsPros
        {
            get { return _clientsPros; }
            set
            {
                _clientsPros = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClientsPros"));
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; }
        }

        private ObservableCollection<Client> _ensembleClients;

        public ObservableCollection<Client> EnsembleClients
        {
            get { return _ensembleClients; }
            set
            {
                _ensembleClients = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnsembleClients"));
            }

        }

        private string _searchParticulierText;

        public string SearchParticulierText
        {
            get { return _searchParticulierText; }
            set
            {
                _searchParticulierText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearchParticulierText"));
                ClientsParts = new ObservableCollection<ClientPart>(ClientPart.PartThatMatch(SearchParticulierText));
            }
        }

        private string _searhProText;

        public string SearhProText
        {
            get { return _searhProText; }
            set
            {
                _searhProText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SearhProText"));
                ClientsPros = new ObservableCollection<ClientPro>(ClientPro.ProThatMatch(SearhProText));
            }
        }


        #endregion
        #endregion

        public AdminView(string serverName, string nomdb, string login, string password)
        {
            InitializeComponent();
            displayMenu.Visibility = Visibility.Collapsed;
            string cs = $"SERVER={serverName};PORT=3306;DATABASE={nomdb};UID={login};PASSWORD={password}";
            new DataAccess(cs);
            //new DataAccess("SERVER= ;PORT=3306;DATABASE=VeloMax;UID=RemoteAdmin;PASSWORD=Password@123");
            //new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=RemoteUser;PASSWORD=Password@123");
            //new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=root;PASSWORD=root");

            RefreshProperties();
        }

        #region Commandes
        private void commandesModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommande)) new CommandeDetailView(SelectedCommande).ShowDialog();
            else MessageBox.Show("Veuillez sélectionner une commande", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            RefreshProperties();
        }

        private void commandesDoneModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeDone)) new CommandeDetailView(SelectedCommandeDone).ShowDialog();
            else MessageBox.Show("Veuillez sélectionner une commande", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            RefreshProperties();
        }

        private void commandesCancelledModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeCancelled)) new CommandeDetailView(SelectedCommandeCancelled).ShowDialog();
            else MessageBox.Show("Veuillez sélectionner une commande", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            RefreshProperties();
        }

        private void commandesToDoModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeToDo)) new CommandeDetailView(SelectedCommandeToDo).ShowDialog();
            else MessageBox.Show("Veuillez sélectionner une commande", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            RefreshProperties();
        }

        private void deleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCommande == null || !Commande.Ensemble.Contains(SelectedCommande)) MessageBox.Show("Veuillez sélectionner une commande à supprimer", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer définitivement cette commande ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    DataAccess.RemoveFromOrders(SelectedCommande);
                    Commandes = new ObservableCollection<Commande>(Commande.Ensemble);
                    CommandesAnnul = new ObservableCollection<Commande>(Commande.EnsembleAnnul);
                    CommandesPrep = new ObservableCollection<Commande>(Commande.EnsemblePrep);
                    CommandesDone = new ObservableCollection<Commande>(Commande.EnsembleDone);
                    MessageBox.Show("Commande supprimée", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            RefreshProperties();
        }

        private void cancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCommande == null || !Commande.Ensemble.Contains(SelectedCommande)) MessageBox.Show("Veuillez sélectionner une commande à supprimer", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir annuler et archiver cette commande ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    DataAccess.EditOrderStatus(SelectedCommande, 3);
                    Commandes = new ObservableCollection<Commande>(Commande.Ensemble);
                    CommandesAnnul = new ObservableCollection<Commande>(Commande.EnsembleAnnul);
                    CommandesPrep = new ObservableCollection<Commande>(Commande.EnsemblePrep);
                    CommandesDone = new ObservableCollection<Commande>(Commande.EnsembleDone);
                    MessageBox.Show("Commande annulée", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            RefreshProperties();
        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            new AddCommandeView().ShowDialog();
            RefreshProperties();
        }

        private void triVente_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Classementclients_DataGrid != null)
            {
                if (triVente_ComboBox.Text == "Nb. de ventes")
                {
                    SortDataGrid(Classementclients_DataGrid, 1);
                    Classementclients_DataGrid.Columns[2].Visibility = Visibility.Collapsed;
                    Classementclients_DataGrid.Columns[1].Visibility = Visibility.Visible;
                }
                else
                {
                    SortDataGrid(Classementclients_DataGrid, 2);
                    Classementclients_DataGrid.Columns[1].Visibility = Visibility.Collapsed;
                    Classementclients_DataGrid.Columns[2].Visibility = Visibility.Visible;
                }
            }
        }

        public static void SortDataGrid(DataGrid datagrid, int colidx, ListSortDirection direction = ListSortDirection.Descending)
        {
            var colonne = datagrid.Columns[colidx];
            datagrid.Items.SortDescriptions.Clear();
            datagrid.Items.SortDescriptions.Add(new SortDescription(colonne.SortMemberPath, direction));
            foreach (var col in datagrid.Columns)
            {
                col.SortDirection = null;
            }
            colonne.SortDirection = direction;
            datagrid.Items.Refresh();
        }

        private void setOrderDoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCommande == null || !Commande.Ensemble.Contains(SelectedCommande)) MessageBox.Show("Veuillez sélectionner une commande à supprimer", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir marquer cette commande comme terminée ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    DataAccess.EditOrderStatus(SelectedCommande, 2);
                    RefreshProperties();
                    MessageBox.Show("Commande déclarée terminée !", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            RefreshProperties();
        }

        private void Classementclients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ClientPro.EnsemblePros.Contains(SelectedClient)) new DetailClientPro((ClientPro)SelectedClient).ShowDialog();
            if (ClientPart.EnsembleParticuliers.Contains(SelectedClient)) new DetailClientPart((ClientPart)SelectedClient).ShowDialog();
        }
        #endregion

        #region Produits
        #region Modeles
        private void removeModeleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null || !Modeles.Contains(SelectedModele)) MessageBox.Show("Veuillez sélectionner un modèle à supprimer", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce modèle ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    DataAccess.RemoveFromModeles(SelectedModele);
                    Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
                    MessageBox.Show("Modele supprimé", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            RefreshProperties();
        }

        private void editModeleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null) MessageBox.Show("Veuillez sélectionner un modèle", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new EditModeleView(SelectedModele).ShowDialog();
                RefreshProperties();
            }
        }

        private void addModeleButton_Click(object sender, RoutedEventArgs e)
        {
            new AddModeleView().ShowDialog();
            RefreshProperties();
        }

        private void modeleDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedModele == null) MessageBox.Show("Veuillez sélectionner un modèle", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new detailPieceView(SelectedModele).ShowDialog();
                RefreshProperties();
            }
        }
        #endregion

        #region Pièces
        private void removePartButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece == null || !PiecesDetachees.Contains(SelectedPiece)) MessageBox.Show("Veuillez sélectionner une pièce à supprimer", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer cette pièce ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (!DataAccess.RemoveFromParts(SelectedPiece)) MessageBox.Show("Cette pièce est utilisée ailleurs !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
                        MessageBox.Show("Pièce supprimée", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            RefreshProperties();
        }

        private void editPieceButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece == null) MessageBox.Show("Veuillez sélectionner une pièce.");
            else
            {
                new EditPieceView(SelectedPiece).ShowDialog();
                RefreshProperties();
            }
        }

        private void addPartButton_Click(object sender, RoutedEventArgs e)
        {
            new AddPieceView().ShowDialog();
            RefreshProperties();
        }

        private void pieceDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedPiece == null) MessageBox.Show("Veuillez sélectionner une pièce", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new DetailPieceView(SelectedPiece).ShowDialog();
                RefreshProperties();
            }
        }
        #endregion
        #endregion

        #region Clients
        private void supprimerClientButtons_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient == null || !Clients.Contains(SelectedClient)) MessageBox.Show("Veuillez sélectionner un client à supprimer", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce client ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (DataAccess.RemoveFromClients(SelectedClient))
                    {
                        Clients = new ObservableCollection<Client>(Client.Ensemble);
                        MessageBox.Show("Client supprimé", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Impossible de supprimer un client ayant un historique de commande", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            RefreshProperties();
        }

        #region Fidelio
        private void removeFidelioButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFidelio == null || !Fidelios.Contains(SelectedFidelio)) MessageBox.Show("Veuillez sélectionner un type de compte Fidélio", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce type de compte Fidélio ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (DataAccess.RemoveFromFidelios(SelectedFidelio))
                    {
                        Fidelios = new ObservableCollection<Fidelio>(Fidelio.Ensemble);
                        MessageBox.Show("Fidélio supprimé", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Impossible de supprimer un programme Fidélio auquel des clients ont adhéré", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            RefreshProperties();
        }

        private void editFidelioButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFidelio == null) MessageBox.Show("Veuillez sélectionner un programme", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new EditFidelioView(SelectedFidelio).ShowDialog();
                RefreshProperties();
            }
        }

        private void addFidelioButton_Click(object sender, RoutedEventArgs e)
        {
            new AddFidelioView().ShowDialog();
            RefreshProperties();
        }

        private void FidelioClients_Click(object sender, MouseButtonEventArgs e) => new FidelioDetailClients(SelectedFidelio).ShowDialog();
        #endregion

        #region Particuliers
        private void editClientPartButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient == null) MessageBox.Show("Veuillez sélectionner un client", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new EditClientPartView((ClientPart)SelectedClient).ShowDialog();
                RefreshProperties();
            }
        }

        private void addClientPartClient_Click(object sender, RoutedEventArgs e)
        {
            new AddClientPartView().ShowDialog();
            RefreshProperties();
        }

        private void DetailPart_Click(object sender, MouseButtonEventArgs e) => new DetailClientPart((ClientPart)SelectedClient).ShowDialog();
        #endregion

        #region Profesionnels
        private void editClientProButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient == null) MessageBox.Show("Veuillez sélectionner un client", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new EditClientProView((ClientPro)SelectedClient).ShowDialog();
                RefreshProperties();
            }
        }

        private void addClientProButton_Click(object sender, RoutedEventArgs e)
        {
            new AddClientProView().ShowDialog();
            RefreshProperties();
        }

        private void DetailPro_Click(object sender, MouseButtonEventArgs e) => new DetailClientPro((ClientPro)SelectedClient).ShowDialog();
        #endregion
        #endregion

        #region Stocks
        private void AddQuantiteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.ModifyStockModele(SelectedModele, SelectedModele.Quantite + 1)) Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
        }

        private void DelQuantiteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.ModifyStockModele(SelectedModele, SelectedModele.Quantite - 1)) Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
        }

        private void AddQuantitePieceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.ModifyStockPiece(SelectedPiece, SelectedPiece.Quantite + 1)) PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
        }

        private void DelQuantitePieceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.ModifyStockPiece(SelectedPiece, SelectedPiece.Quantite - 1)) PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
        }

        private void PieceStockDetail_Click(object sender, RoutedEventArgs e) => new StockPieceFournisseurs(SelectedPieceStock).ShowDialog();
        #endregion

        #region Fournisseurs
        private void removeFournisseurButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFournisseur == null || !Fournisseurs.Contains(SelectedFournisseur)) MessageBox.Show("Veuillez sélectionner un fournisseur", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce fournisseur ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (DataAccess.RemoveFromFournisseurs(SelectedFournisseur))
                    {
                        Fournisseurs = new ObservableCollection<Fournisseur>(Fournisseur.Ensemble);
                        MessageBox.Show("Fournisseur supprimé", "Succès !", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Impossible de supprimer un fournisseur actif", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            RefreshProperties();
        }

        private void editFournisseurButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFournisseur == null) MessageBox.Show("Veuillez sélectioner un fournisseur à modifier", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new EditFournisseurView(SelectedFournisseur).ShowDialog();
                RefreshProperties();
            }
        }

        private void addFournisseurButton_Click(object sender, RoutedEventArgs e)
        {
            new AddFournisseurView().ShowDialog();
            RefreshProperties();
        }

        private void FournisseursDetail_Click(object sender, MouseButtonEventArgs e)
        {
            if (SelectedFournisseur == null) MessageBox.Show("Veuillez sélectionner un fournisseur", "Erreur sélection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                new DetailFournisseurView(SelectedFournisseur).ShowDialog();
                RefreshProperties();
            }
        }
        #endregion

        private bool CheckIfSelected(object input)
        {
            bool correct = false;
            if (input != null) correct = true;
            return correct;
        }

        private void RefreshProperties()
        {
            DataAccess.RefreshDBUsingSP();
            Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
            Adresses = new ObservableCollection<Adresse>(Adresse.Ensemble);
            Grandeurs = new ObservableCollection<Grandeur>(Grandeur.Ensemble);
            LignesProduits = new ObservableCollection<LigneProduit>(LigneProduit.Ensemble);
            Commandes = new ObservableCollection<Commande>(Commande.Ensemble);
            CommandesAnnul = new ObservableCollection<Commande>(Commande.EnsembleAnnul);
            CommandesPrep = new ObservableCollection<Commande>(Commande.EnsemblePrep);
            CommandesDone = new ObservableCollection<Commande>(Commande.EnsembleDone);
            PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
            Fournisseurs = new ObservableCollection<Fournisseur>(Fournisseur.Ensemble);
            Fidelios = new ObservableCollection<Fidelio>(Fidelio.Ensemble);
            Clients = new ObservableCollection<Client>(Client.Ensemble);
            SortDataGrid(Classementclients_DataGrid, 1);
            Classementclients_DataGrid.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.LeftAlt && displayMenu.Visibility == Visibility.Collapsed)
            {
                displayMenu.Visibility = Visibility.Visible;
            }
            else
            {
                if (e.SystemKey == Key.LeftAlt && displayMenu.Visibility == Visibility.Visible)
                    displayMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void Statistiques_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new StatistiquesView().ShowDialog();
        }

        private void almostexpiredFidelioMembers_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(ClientPart.ProgrammeFidelioBientotExpired(Convert.ToInt32(((MenuItem)sender).Tag.ToString())), Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("FidelioExport.json", json);
            System.Diagnostics.Process.Start("FidelioExport.json");
        }

        private void faiblePiece_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Create("ExportPiecesStockFaible.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PieceDetachee>));
                xmlSerializer.Serialize(fs, PieceDetachee.Ensemble.FindAll(p => p.Quantite <= Convert.ToInt32(((MenuItem)sender).Tag.ToString())));
                System.Diagnostics.Process.Start("ExportPiecesStockFaible.xml");
            }

        }

        private void faibleModele_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Create("ExportModeleStockFaible.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Modele>));
                xmlSerializer.Serialize(fs, Modele.Ensemble.FindAll(m => m.Quantite <= Convert.ToInt32(((MenuItem)sender).Tag.ToString())));
                System.Diagnostics.Process.Start("ExportModeleStockFaible.xml");
            }
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}