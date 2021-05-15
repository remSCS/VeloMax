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
                PropertyChanged(this, new PropertyChangedEventArgs("Modeles"));
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
                if(SelectedCommande != null && CommandesPrep.Contains(SelectedCommande)) cancelOrderButton.Visibility = Visibility.Visible;
                else cancelOrderButton.Visibility = Visibility.Hidden;
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
                PropertyChanged(this, new PropertyChangedEventArgs("PiecesDetachees"));
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

            //new DataAccess("SERVER=84.102.235.128;PORT=3306;DATABASE=VeloMax;UID=RemoteAdmin;PASSWORD=Password@123");
            new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=RemoteUser;PASSWORD=Password@123");
            //new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=root;PASSWORD=root");

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //DataAccess.RefreshDBUsingSP();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //MessageBox.Show($"{elapsedMs}ms to get data from DB as localhost");

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

        #region Détails Commande
        private void commandesModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommande)) new CommandeDetailView(SelectedCommande).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
        }

        private void commandesDoneModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeDone)) new CommandeDetailView(SelectedCommandeDone).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
        }

        private void commandesCancelledModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeCancelled)) new CommandeDetailView(SelectedCommandeCancelled).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
        }

        private void commandesToDoModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelected(SelectedCommandeToDo)) new CommandeDetailView(SelectedCommandeToDo).ShowDialog();
            else MessageBox.Show("Veuillez choisir une commande");
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
                    MessageBox.Show("Modele supprimé");
                }
            }
        }

        private void cancelOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

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
        }

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
        }

        #region Stocks
        private void AddQuantiteButton_Click(object sender, RoutedEventArgs e)
        {

            if (DataAccess.ModifyStockModele(SelectedModele, SelectedModele.Quantite + 1))
            {
                Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
            }
        }

        private void DelQuantiteButton_Click(object sender, RoutedEventArgs e)
        {

            if (DataAccess.ModifyStockModele(SelectedModele, SelectedModele.Quantite - 1))
            {
                Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
            }
        }

        private void AddQuantitePieceButton_Click(object sender, RoutedEventArgs e)
        {

            if (DataAccess.ModifyStockPiece(SelectedPiece, SelectedPiece.Quantite + 1))
            {
                PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
            }
        }

        private void DelQuantitePieceButton_Click(object sender, RoutedEventArgs e)
        {

            if (DataAccess.ModifyStockPiece(SelectedPiece, SelectedPiece.Quantite - 1))
            {
                PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
            }
        }
        #endregion

        private bool CheckIfSelected(object input)
        {
            bool correct = false;
            if (input != null) correct = true;
            return correct;
        }
    }
}