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
    /// Interaction logic for AddFournisseurView.xaml
    /// </summary>
    public partial class AddFournisseurView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Fournisseur _fournisseurToAdd;
        public Fournisseur FournisseurToAdd
        {
            get { return _fournisseurToAdd; }
            set
            {
                _fournisseurToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FournisseurToAdd"));
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
    
        public AddFournisseurView()
        {
            InitializeComponent();
            Libelles = new ObservableCollection<Libelle>(Libelle.Ensemble);
            Contact contactToAdd = new Contact()
            {
                Id = DataAccess.GetHighestId("contact") + 1,
                Nom = "",
                Prenom = "",
                Email = "",
                Tel = ""
            };
            Adresse adresseToAdd = new Adresse()
            {
                Id = DataAccess.GetHighestId("adresse") + 1,
                Ligne1 = "",
                Ligne2 = "",
                CodePostal = "",
                Ville = "",
                Pays = "",
                Province = ""
            };
            Fournisseur fournisseurToAdd = new Fournisseur(contactToAdd.Id, adresseToAdd.Id, -1)
            {
                Siret = 0,
                Nom = ""
            };
            FournisseurToAdd = fournisseurToAdd;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (FournisseurToAdd.LibelleFournisseur == null) MessageBox.Show("Veuillez sélectionner un libellé.");
            else
            {
                var found = Fournisseur.Ensemble.FindAll(f => f.Siret == FournisseurToAdd.Siret);
                if (found.Count > 1) MessageBox.Show("Impossible de créer un fournisseur avec un siret déjà existant.");
                else
                {
                    Adresse matchingA = Adresse.Ensemble.Find(a => a.ToString() == FournisseurToAdd.AdresseFournisseur.ToString());
                    Contact matchingC = Contact.Ensemble.Find(c => c.ToString() == FournisseurToAdd.ContactFournisseur.ToString());
                    if (matchingA != null)
                    {
                        Adresse.Ensemble.Remove(FournisseurToAdd.AdresseFournisseur);
                        FournisseurToAdd.AdresseFournisseur = matchingA;
                    }
                    if (matchingC != null)
                    {
                        Contact.Ensemble.Remove(FournisseurToAdd.ContactFournisseur);
                        FournisseurToAdd.ContactFournisseur = matchingC;
                    }

                    if (!DataAccess.AddFournisseur(FournisseurToAdd)) MessageBox.Show("Modification impossible.");
                    else
                    {
                        MessageBox.Show("Fournisseur ajouté !");
                        this.Close();
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Adresse.Ensemble.Remove(FournisseurToAdd.AdresseFournisseur);
            Contact.Ensemble.Remove(FournisseurToAdd.ContactFournisseur);
            Fournisseur.Ensemble.Remove(FournisseurToAdd);
            this.Close();
        }
    }
}
