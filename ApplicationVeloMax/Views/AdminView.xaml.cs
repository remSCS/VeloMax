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
            set { _selectedModele = value;}
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

        private Commande _selectedCommande = new Commande();
        public Commande SelectedCommande
        {
            get { return _selectedCommande; }
            set
            {
                _selectedCommande = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommande"));
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
            PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
            Fournisseurs = new ObservableCollection<Fournisseur>(Fournisseur.Ensemble);
            Fidelios = new ObservableCollection<Fidelio>(Fidelio.Ensemble);
            Clients = new ObservableCollection<Client>(Client.Ensemble);
        }

        private void commandesDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new CommandeDetailView(SelectedCommande).ShowDialog();

        private void commandesModifierButton_Click(object sender, RoutedEventArgs e) => new CommandeDetailView(SelectedCommande).ShowDialog();

        private void removeModeleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null || !Modeles.Contains(SelectedModele)) MessageBox.Show("Veuillez sélectionner un modèle à supprimer.");
            else
            {
                List<Modele> toRemove = new List<Modele>() { SelectedModele };
                DataAccess.RemoveFromModeles(toRemove);
                Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
                MessageBox.Show("Modele supprimé");
            }
        }
    }
}