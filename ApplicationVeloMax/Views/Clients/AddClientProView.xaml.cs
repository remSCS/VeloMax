using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddClientProView.xaml
    /// </summary>
    public partial class AddClientProView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClientPro _clientToAdd;
        public ClientPro ClientToAdd
        {
            get { return _clientToAdd; }
            set
            {
                _clientToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClientToAdd"));
            }
        }

        public AddClientProView()
        {
            InitializeComponent();
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

            ClientPro clientProToAdd = new ClientPro(adresseToAdd.Id, contactToAdd.Id)
            {
                Id = DataAccess.GetHighestId("client") + 1,
                NomEntreprise = "",
                Remise = 0M,
                DateAdherance = DateTime.Today
            };
            ClientToAdd = clientProToAdd;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientToAdd.DateAdherance = (DateTime)dateAdhePicker.SelectedDate;
                ClientToAdd.Remise = Convert.ToDecimal(remiseTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }

            Adresse matchingA = Adresse.Ensemble.Find(a => a.ToString() == ClientToAdd.AdresseClient.ToString());
            Contact matchingC = Contact.Ensemble.Find(c => c.ToString() == ClientToAdd.ContactClient.ToString());
            if(matchingA != null)
            {
                Adresse.Ensemble.Remove(ClientToAdd.AdresseClient);
                ClientToAdd.AdresseClient = matchingA;
            }
            if(matchingC != null)
            {
                Contact.Ensemble.Remove(ClientToAdd.ContactClient);
                ClientToAdd.ContactClient = matchingC;
            }
            if (!DataAccess.AddClientPro(ClientToAdd)) MessageBox.Show("Modification impossible.");
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
            ClientPro.EnsemblePros.Remove(ClientToAdd);
            this.Close();
        }
    }
}
