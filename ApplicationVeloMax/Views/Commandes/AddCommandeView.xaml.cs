using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using ApplicationVeloMax.Views.Clients;
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

namespace ApplicationVeloMax.Views.Commandes
{
    /// <summary>
    /// Interaction logic for AddCommandeView.xaml
    /// </summary>
    public partial class AddCommandeView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private Commande _commandeToAdd;
        public Commande CommandeToAdd
        {
            get { return _commandeToAdd; }
            set
            {
                _commandeToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CommandeToAdd"));
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                if(CommandeToAdd != null) CommandeToAdd.ClientCommande = SelectedClient;
                if(SelectedClient != null)
                {
                    useCb.IsChecked = true;
                    SetStatusChecked();
                }
                else
                {
                    useCb.IsChecked = false;
                    SetStatusUnchecked();
                }
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedClient"));
            }
        }

        private Adresse _adresseToAdd;
        public Adresse AdresseToAdd
        {
            get { return _adresseToAdd; }
            set
            {
                _adresseToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedClient"));
            }
        }

        public AddCommandeView()
        {
            InitializeComponent();
            SelectedClient = null;

            ClientsParts = new ObservableCollection<ClientPart>(ClientPart.EnsembleParticuliers);
            ClientsPros = new ObservableCollection<ClientPro>(ClientPro.EnsemblePros);

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
            AdresseToAdd = adresseToAdd;

            Commande commandeToAdd = new Commande(AdresseToAdd.Id, -1, 1)
            {
                Id = DataAccess.GetHighestId("commande") + 1,
                DateE = DateTime.Today,
                DateS = DateTime.Today
            };
            CommandeToAdd = commandeToAdd;
            dueDate.DisplayDateStart = DateTime.Today;
        }

        private void useCb_Checked(object sender, RoutedEventArgs e) => SetStatusChecked();

        private void useCb_Unchecked(object sender, RoutedEventArgs e) => SetStatusUnchecked();

        private void SetStatusUnchecked()
        {
            if (CommandeToAdd != null && CommandeToAdd.ClientCommande != null) CommandeToAdd.AdresseLivraison = AdresseToAdd;
            adresseInputSp.Visibility = Visibility.Visible;
            adresseLblSp.Visibility = Visibility.Visible;
        }

        private void SetStatusChecked()
        {
            if (SelectedClient != null) CommandeToAdd.AdresseLivraison = CommandeToAdd.ClientCommande.AdresseClient;
            adresseInputSp.Visibility = Visibility.Hidden;
            adresseLblSp.Visibility = Visibility.Hidden;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Adresse.Ensemble.Remove(AdresseToAdd);
            Commande.Ensemble.Remove(CommandeToAdd);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommandeToAdd.ClientCommande == null) MessageBox.Show("Veuillez choisir un client !");
            if (!DataAccess.AddCommande(CommandeToAdd)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Client ajouté !");
                this.Close();
            }
        }

        private void DataGridRowPart_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new DetailClientPro((ClientPro)SelectedClient).ShowDialog();
        }

        private void DataGridRowPro_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new DetailClientPro((ClientPro)SelectedClient).ShowDialog();
        }

        private void DataGridPro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGridPro.SelectedItem != null)
            {
                SelectedClient = (Client)DataGridPro.SelectedItem;
                DataGridPart.SelectedItem = null;
            }
        }

        private void DataGridPart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPart.SelectedItem != null)
            {
                SelectedClient = (Client)DataGridPart.SelectedItem;
                DataGridPro.SelectedItem = null;
            }
        }
    }
}