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
using ApplicationVeloMax.Communication;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ApplicationVeloMax.Views
{
    public partial class AdminView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public AdminView()
        {
            InitializeComponent();

            //"SERVER=84.102.235.128;PORT=3306;DATABASE=VeloMax;UID=RemoteAdmin;PASSWORD=Password@123"
            new DataAccess("SERVER=localhost;PORT=3306;DATABASE=VeloMax;UID=RemoteAdmin;PASSWORD=Password@123");

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            DataAccess.RefreshDB();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //MessageBox.Show($"{elapsedMs}ms to get data from DB as localhost");

            Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
            Adresses = new ObservableCollection<Adresse>(Adresse.Ensemble);
            Grandeurs = new ObservableCollection<Grandeur>(Grandeur.Ensemble);
            LignesProduits = new ObservableCollection<LigneProduit>(LigneProduit.Ensemble);
            Commandes = new ObservableCollection<Commande>(Commande.Ensemble);
            PiecesDetachees = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
        }
    }
}