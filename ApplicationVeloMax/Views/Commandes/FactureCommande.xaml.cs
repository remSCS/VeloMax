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
    /// Logique d'interaction pour FactureCommande.xaml
    /// </summary>
    public partial class FactureCommande : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Commande _commandeFacture;
        public Commande CommandeFacture
        {
            get { return _commandeFacture; }
            set
            {
                _commandeFacture = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CommandeFacture"));
            }
        }

        public FactureCommande(Commande commandeFacture)
        {
            InitializeComponent();
            CommandeFacture = commandeFacture;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

     
    }
}
