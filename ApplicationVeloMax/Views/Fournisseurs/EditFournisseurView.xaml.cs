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

namespace ApplicationVeloMax.Views.Fournisseurs
{
    /// <summary>
    /// Interaction logic for EditFournisseurView.xaml
    /// </summary>
    public partial class EditFournisseurView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClientPart _selectedClient;
        public ClientPart SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedClient"));
            }
        }

        public EditFournisseurView()
        {
            InitializeComponent();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
