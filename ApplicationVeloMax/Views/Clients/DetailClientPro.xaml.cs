using ApplicationVeloMax.Models;
using ApplicationVeloMax.Views.Commandes;
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
    /// Logique d'interaction pour DetailClientPro.xaml
    /// </summary>
    public partial class DetailClientPro : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClientPro _clientPro;
        public ClientPro ClientPro
        {
            get { return _clientPro; }
            set
            {
                _clientPro = value;
                Commandes = new ObservableCollection<Commande>(Commande.Ensemble.FindAll(c => c.ClientCommande.Id == _clientPro.Id));
                PropertyChanged(this, new PropertyChangedEventArgs("ClientPro"));
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

        private Commande _selectedCommande;
        public Commande SelectedCommande
        {
            get
            {
                return _selectedCommande;
            }
            set
            {
                _selectedCommande = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommande"));
            }
        }
        public DetailClientPro(ClientPro pro)
        {
            InitializeComponent();
            ClientPro = pro;
            nbMoyen_Lbl.Content = Commande.NbArticlesMoyen(ClientPro);
            totalMoyen_Lbl.Content = Decimal.Round(Commande.PrixMoyen(ClientPro),2) + " €";
            totalcumul_Lbl.Content= Decimal.Round(Commande.MontantTotalCumul(ClientPro), 2) + " €";
        }

        private void DetailCommande_Click(object sender, MouseButtonEventArgs e)
        {
            new CommandeDetailView(SelectedCommande).Show();
        }
    }
}
