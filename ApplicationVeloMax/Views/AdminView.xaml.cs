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
                if (SelectedCommande != null && CommandesPrep.Contains(SelectedCommande)) { cancelOrderButton.Visibility = Visibility.Visible; commandesModifierButton.Visibility = Visibility.Visible; }
                else { cancelOrderButton.Visibility = Visibility.Hidden; commandesModifierButton.Visibility = Visibility.Hidden; }
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
        #endregion
        #endregion

        public AdminView()
        {
            InitializeComponent();
            displayMenu.Visibility = Visibility.Collapsed;

            //new DataAccess("SERVER=84.102.235.128;PORT=3306;DATABASE=VeloMax;UID=RemoteAdmin;PASSWORD=Password@123");
            new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=RemoteUser;PASSWORD=Password@123");
            //new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=root;PASSWORD=root");

            RefreshProperties();
        }

        #region Commandes
        private void commandesModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommande)) new CommandeDetailView(SelectedCommande).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
            RefreshProperties();
        }

        private void commandesDoneModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeDone)) new CommandeDetailView(SelectedCommandeDone).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
            RefreshProperties();
        }

        private void commandesCancelledModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeCancelled)) new CommandeDetailView(SelectedCommandeCancelled).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
            RefreshProperties();
        }

        private void commandesToDoModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeToDo)) new CommandeDetailView(SelectedCommandeToDo).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
            RefreshProperties();
        }

        private void deleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCommande == null || !Commande.Ensemble.Contains(SelectedCommande)) MessageBox.Show("Veuillez sélectionner une commande à supprimer.");
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir défnitivement supprimer cette commande ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    DataAccess.RemoveFromOrders(SelectedCommande);
                    Commandes = new ObservableCollection<Commande>(Commande.Ensemble);
                    CommandesAnnul = new ObservableCollection<Commande>(Commande.EnsembleAnnul);
                    CommandesPrep = new ObservableCollection<Commande>(Commande.EnsemblePrep);
                    CommandesDone = new ObservableCollection<Commande>(Commande.EnsembleDone);
                    MessageBox.Show("Comande supprimée");
                }
            }
            RefreshProperties();
        }

        private void cancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCommande == null || !Commande.Ensemble.Contains(SelectedCommande)) MessageBox.Show("Veuillez sélectionner une commande à supprimer.");
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
                    MessageBox.Show("Commande annulée");
                }
            }
            RefreshProperties();
        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            new AddCommandeView().ShowDialog();
            RefreshProperties();
        }
        #endregion

        #region Produits
        #region Modeles
        private void removeModeleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null || !Modeles.Contains(SelectedModele)) MessageBox.Show("Veuillez sélectionner un modèle à supprimer.");
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce modèle ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    DataAccess.RemoveFromModeles(SelectedModele);
                    Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
                    MessageBox.Show("Modele supprimé");
                }
            }
            RefreshProperties();
        }

        private void editModeleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null) MessageBox.Show("Veuillez sélectionner un modèle.");
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
            if (SelectedModele == null) MessageBox.Show("Veuillez choisir un modèle");
            else
            {
                new DetailsModeleView(SelectedModele).ShowDialog();
                RefreshProperties();
            }
        }
        #endregion

        #region Pièces
        private void removePartButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece == null || !PiecesDetachees.Contains(SelectedPiece)) MessageBox.Show("Veuillez sélectionner une pièce à supprimer.");
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer cette pièce ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (!DataAccess.RemoveFromParts(SelectedPiece)) MessageBox.Show("Cette pièce est utilisée ailleurs !");
                    else
                    {
                        PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
                        MessageBox.Show("Pièce supprimé");
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
        #endregion
        #endregion

        #region Clients
        private void supprimerClientButtons_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient == null || !Clients.Contains(SelectedClient)) MessageBox.Show("Veuillez sélectionner un client à supprimer.");
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce client ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (DataAccess.RemoveFromClients(SelectedClient))
                    {
                        Clients = new ObservableCollection<Client>(Client.Ensemble);
                        MessageBox.Show("Client supprimé");
                    }
                    else MessageBox.Show("Impossible de supprimer un client ayant un historique de commande.");
                }
            }
            RefreshProperties();
        }

        #region Fidelio
        private void removeFidelioButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFidelio == null || !Fidelios.Contains(SelectedFidelio)) MessageBox.Show("Veuillez sélectionner un type de compte Fidélio.");
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer ce type de compte Fidélio ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (DataAccess.RemoveFromFidelios(SelectedFidelio))
                    {
                        Fidelios = new ObservableCollection<Fidelio>(Fidelio.Ensemble);
                        MessageBox.Show("Fidélio supprimé");
                    }
                    else MessageBox.Show("Impossible de supprimer un client ayant un historique de commande. Voulez vous migrer les clients ayant ce type de compte ? (à faire)");
                }
            }
            RefreshProperties();
        }

        private void editFidelioButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFidelio == null) MessageBox.Show("Veuillez sélectionner un programme.");
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
            if (SelectedClient == null) MessageBox.Show("Veuillez sélectionner un client.");
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
            if (SelectedClient == null) MessageBox.Show("Veuillez sélectionner un client.");
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
            if (SelectedFournisseur == null || !Fournisseurs.Contains(SelectedFournisseur)) MessageBox.Show("Veuillez sélectionner un fournisseur.");
            else
            {
                MessageBoxResult res = MessageBox.Show("Etes vous certain de vouloir supprimer fournisseur ?", "Vérification", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    if (DataAccess.RemoveFromFournisseurs(SelectedFournisseur))
                    {
                        Fournisseurs = new ObservableCollection<Fournisseur>(Fournisseur.Ensemble);
                        MessageBox.Show("Founrisseur supprimé");
                    }
                    else MessageBox.Show("Impossible de supprimer un fournisseur actif.");
                }
            }
            RefreshProperties();
        }

        private void editFournisseurButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFournisseur == null) MessageBox.Show("Veuillez sélectioner un fournisseur à modifider.");
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

        private void FournisseursDetail_Click(object sender, MouseButtonEventArgs e)
        {
            if (SelectedFournisseur == null) MessageBox.Show("Veuillez sélectionner un fournisseur !");
            else
            {
                new DetailFournisseurView(SelectedFournisseur).ShowDialog();
                RefreshProperties();
            }
        }
    }
}