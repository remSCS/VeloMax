using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ApplicationVeloMax.Views.Modeles
{
    /// <summary>
    /// Interaction logic for AddModeleView.xaml
    /// </summary>
    public partial class AddModeleView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Modele _modele;
        public Modele Modele
        {
            get { return _modele; }
            set
            {
                _modele = value;
                if (dateSTb.SelectedDate < dateETb.SelectedDate) dateSTb.SelectedDate = dateETb.SelectedDate;
                dateETb.DisplayDateEnd = DateTime.Today;
                dateSTb.DisplayDateStart = Modele.DateE;
                PropertyChanged(this, new PropertyChangedEventArgs("Modele"));
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

        public AddModeleView()
        {
            InitializeComponent();
            Modele toAdd = new Modele()
            {
                Id = DataAccess.GetHighestId("modele") + 1,
                Nom = "",
                Quantite = 0,
                PrixUnitaire = 0,
                DateE = DateTime.Today,
                DateS = DateTime.Today
            };
            Modele = toAdd;
            Grandeurs = new ObservableCollection<Grandeur>(Grandeur.Ensemble);
            LignesProduits = new ObservableCollection<LigneProduit>(LigneProduit.Ensemble);
        }

        private void addModeleButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Modele.Id;
            string nom = Modele.Nom;
            Grandeur grandeur = Modele.GrandeurModele;
            decimal prix = Modele.PrixUnitaire;
            LigneProduit ligne = Modele.LigneProduitModele;
            DateTime de = Modele.DateE;
            DateTime ds = Modele.DateS;

            try
            {
                nom = nomTb.Text;
                grandeur = (Grandeur)grandeurTb.SelectedItem;
                prix = Convert.ToDecimal(prixTb.Text);
                ligne = (LigneProduit)ligneTb.SelectedItem;
                de = DateTime.Parse(dateETb.Text);
                ds = DateTime.Parse(dateSTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }

            if (grandeur == null || ligne == null) MessageBox.Show("Modification impossible.");
            else
            {
                Modele toAdd = new Modele(grandeur.Id, ligne.Id)
                {
                    Id = Modele.Id,
                    Nom = nom,
                    PrixUnitaire = prix,
                    Quantite = 0,
                    DateE = de,
                    DateS = ds
                };

                if (!DataAccess.AddModele(toAdd)) MessageBox.Show("Modification impossible.");

                else
                {
                    MessageBox.Show("Modifications effectuées");
                    this.Close();
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();

        private void dateETb_SelectedDateChanged(object sender, SelectionChangedEventArgs e) => Modele = Modele;
    }
}
