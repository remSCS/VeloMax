using ApplicationVeloMax.Models;
using ApplicationVeloMax.Views.Clients;
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

namespace ApplicationVeloMax.Views.Fidelios
{
    /// <summary>
    /// Logique d'interaction pour FidelioDetailClients.xaml
    /// </summary>

    public partial class FidelioDetailClients : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Fidelio _selectedFidelio;
        public Fidelio SelectedFidelio
        {
            get { return _selectedFidelio; }
            set
            {
                _selectedFidelio = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedFidelio"));
            }
        }

        private ClientPart clientPart;
        public ClientPart ClientPart
        {
            get { return clientPart; }
            set
            {
                clientPart = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClientPart"));
            }
        }

        private void DetailClient_Click(object sender, MouseButtonEventArgs e)
        {
            new DetailClientPart(ClientPart).ShowDialog();
        }

        public FidelioDetailClients(Fidelio fid)
        {
            InitializeComponent();
            SelectedFidelio = fid;
        }
    }
}
