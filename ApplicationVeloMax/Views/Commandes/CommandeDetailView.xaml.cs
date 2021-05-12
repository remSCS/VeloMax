using ApplicationVeloMax.Models;
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

namespace ApplicationVeloMax.Views.Commandes
{
    /// <summary>
    /// Logique d'interaction pour CommandeDetailView.xaml
    /// </summary>
    public partial class CommandeDetailView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Commande _selectedCommande =new Commande();
        public Commande SelectedCommande
        {
            get { return _selectedCommande; }
            set
            {
                _selectedCommande = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommande"));
               
            }
        }

        public CommandeDetailView(Commande _inputCommande)
        {
            InitializeComponent();

            SelectedCommande = _inputCommande;
        }
    }
}
