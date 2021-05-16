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
    /// Interaction logic for EditClientPart.xaml
    /// </summary>
    public partial class EditClientPartView : Window, INotifyPropertyChanged
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

        public EditClientPartView(ClientPart _input)
        {
            InitializeComponent();
            SelectedClient = _input;
            Fidelios = new ObservableCollection<Fidelio>(Fidelio.Ensemble);
            dateAdhePicker.DisplayDateEnd = DateTime.Today;
            if (SelectedClient.FidelioClient == null) { fidelioCB.IsChecked = false; SetStatusUnchecked(); }
            else { fidelioCB.IsChecked = true; SetStatusChecked(); }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int id = SelectedClient.Id;
            DateTime adherance = SelectedClient.DateAdherance;

            string l1 = SelectedClient.AdresseClient.Ligne1;
            string l2 = SelectedClient.AdresseClient.Ligne2;
            string cp = SelectedClient.AdresseClient.CodePostal;
            string ville = SelectedClient.AdresseClient.Ville;
            string province = SelectedClient.AdresseClient.Province;
            string pays = SelectedClient.AdresseClient.Pays;

            string nom = SelectedClient.ContactClient.Nom;
            string prenom = SelectedClient.ContactClient.Prenom;
            string tel = SelectedClient.ContactClient.Tel;
            string mail = SelectedClient.ContactClient.Email;

            int idFidelio = -1;
            DateTime dateFidelio = DateTime.MinValue;
            if (fidelioCB.IsChecked == true)
            {
                idFidelio = SelectedClient.FidelioClient.Id;
                dateFidelio = SelectedClient.DateDebutFidelio;
            }

            try
            {
                adherance = (DateTime)dateAdhePicker.SelectedDate;

                l1 = l1TB.Text;
                l2 = l2TB.Text;
                cp = cpTB.Text;
                ville = villeTB.Text;
                province = provTB.Text;
                pays = paysTB.Text;

                nom = nomTb.Text;
                prenom = prenomTb.Text;
                tel = telTb.Text;
                mail = mailTb.Text;

                if (fidelioCB.IsChecked == true)
                {
                    idFidelio = ((Fidelio)fidelioCombo.SelectedItem).Id;
                    dateFidelio = (DateTime)dateFidelioPicker.SelectedDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }

            if (!DataAccess.FullyEditClientPart(id, adherance, nom, prenom, tel, mail, l1, l2, cp, ville, province, pays, idFidelio, dateFidelio)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Modifications effectuées");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();

        private void fidelioCB_Checked(object sender, RoutedEventArgs e)
        {
            SetStatusChecked();
            SelectedClient = SelectedClient;
        }

        private void fidelioCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SetStatusUnchecked();
            SelectedClient = SelectedClient;
        }

        private void SetStatusUnchecked()
        {
            if (SelectedClient.FidelioClient != null) { SelectedClient.FidelioClient = null; SelectedClient.DateDebutFidelio = DateTime.Today; }
            fidelioCombo.Visibility = Visibility.Hidden;
            dateLabel.Visibility = Visibility.Hidden;
            dateFidelioPicker.Visibility = Visibility.Hidden;
        }

        private void SetStatusChecked()
        {
            if (SelectedClient.FidelioClient == null) { SelectedClient.DateDebutFidelio = DateTime.Today; }
            fidelioCombo.Visibility = Visibility.Visible;
            dateLabel.Visibility = Visibility.Visible;
            dateFidelioPicker.Visibility = Visibility.Visible;
        }
    }
}
