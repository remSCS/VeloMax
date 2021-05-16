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

namespace ApplicationVeloMax.Views.Clients
{
    /// <summary>
    /// Interaction logic for AddClientPartView.xaml
    /// </summary>
    public partial class AddClientPartView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClientPart _clientToAdd;
        public ClientPart ClientToAdd
        {
            get { return _clientToAdd; }
            set
            {
                _clientToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClientToAdd"));
            }
        }

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

        public AddClientPartView()
        {
            InitializeComponent();
            Fidelios = new ObservableCollection<Fidelio>(Fidelio.Ensemble);
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
            ClientPart clientPartToAdd = new ClientPart(adresseToAdd.Id, contactToAdd.Id, -1)
            {
                Id = DataAccess.GetHighestId("client") + 1,
                DateAdherance = DateTime.Today,
                DateDebutFidelio = DateTime.Today
            };
            ClientToAdd = clientPartToAdd;
            fidelioCB.IsChecked = false;
            SetStatusUnchecked();
        }

        private void SetStatusUnchecked()
        {
            if (ClientToAdd.FidelioClient != null) { ClientToAdd.FidelioClient = null; ClientToAdd.DateDebutFidelio = DateTime.Today; }
            fidelioCombo.Visibility = Visibility.Hidden;
            dateLabel.Visibility = Visibility.Hidden;
            dateFidelioPicker.Visibility = Visibility.Hidden;
        }

        private void SetStatusChecked()
        {
            if (ClientToAdd.FidelioClient == null) { ClientToAdd.DateDebutFidelio = DateTime.Today; }
            fidelioCombo.Visibility = Visibility.Visible;
            dateLabel.Visibility = Visibility.Visible;
            dateFidelioPicker.Visibility = Visibility.Visible;
        }

        private void fidelioCB_Checked(object sender, RoutedEventArgs e) => SetStatusChecked();

        private void fidelioCB_Unchecked(object sender, RoutedEventArgs e) => SetStatusUnchecked();

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientToAdd.DateAdherance = (DateTime)dateAdhePicker.SelectedDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }

            Adresse matchingA = Adresse.Ensemble.Find(a => a.ToString() == ClientToAdd.AdresseClient.ToString());
            Contact matchingC = Contact.Ensemble.Find(c => c.ToString() == ClientToAdd.ContactClient.ToString());
            if (matchingA != null)
            {
                Adresse.Ensemble.Remove(ClientToAdd.AdresseClient);
                ClientToAdd.AdresseClient = matchingA;
            }
            if (matchingC != null)
            {
                Contact.Ensemble.Remove(ClientToAdd.ContactClient);
                ClientToAdd.ContactClient = matchingC;
            }
            int idF;
            if (ClientToAdd.FidelioClient == null) idF = -1;
            else idF = ClientToAdd.FidelioClient.Id;
            if (!DataAccess.AddClientPart(ClientToAdd, idF)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Client ajouté !");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Adresse.Ensemble.Remove(ClientToAdd.AdresseClient);
            Contact.Ensemble.Remove(ClientToAdd.ContactClient);
            Client.Ensemble.Remove(ClientToAdd);
            ClientPart.EnsembleParticuliers.Remove(ClientToAdd);
            this.Close();
        }
    }
}
