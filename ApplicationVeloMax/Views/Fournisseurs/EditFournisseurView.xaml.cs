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

namespace ApplicationVeloMax.Views.Fournisseurs
{
    /// <summary>
    /// Interaction logic for EditFournisseurView.xaml
    /// </summary>
    public partial class EditFournisseurView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private ObservableCollection<Libelle> _libelles;
        public ObservableCollection<Libelle> Libelles
        {
            get { return _libelles; }
            set
            {
                _libelles = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Libelles"));
            }
        }

        public EditFournisseurView(Fournisseur _input)
        {
            InitializeComponent();
            SelectedFournisseur = _input;
            Libelles = new ObservableCollection<Libelle>(Libelle.Ensemble);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DataAccess.FullyEditFournisseur(SelectedFournisseur.Siret,
                SelectedFournisseur.LibelleFournisseur.Id, SelectedFournisseur.Nom,
                SelectedFournisseur.ContactFournisseur.Nom, SelectedFournisseur.ContactFournisseur.Prenom,
                SelectedFournisseur.ContactFournisseur.Tel, SelectedFournisseur.ContactFournisseur.Email,
                SelectedFournisseur.AdresseFournisseur.Ligne1, SelectedFournisseur.AdresseFournisseur.Ligne2,
                SelectedFournisseur.AdresseFournisseur.CodePostal, SelectedFournisseur.AdresseFournisseur.Ville,
                SelectedFournisseur.AdresseFournisseur.Province, SelectedFournisseur.AdresseFournisseur.Pays)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Fournisseur modifié!");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
