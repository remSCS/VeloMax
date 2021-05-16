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
    /// Interaction logic for EditClientProView.xaml
    /// </summary>
    public partial class EditClientProView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ClientPro _selectedClient;
        public ClientPro SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedClient"));
            }
        }

        public EditClientProView(ClientPro _input)
        {
            InitializeComponent();
            SelectedClient = _input;
            dateAdhePicker.DisplayDateEnd = DateTime.Today;
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

            string entreprise = SelectedClient.NomEntreprise;
            decimal remise = SelectedClient.Remise;
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

                entreprise = entrepriseTb.Text;
                remise = Convert.ToDecimal(remiseTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }

            if (!DataAccess.FullyEditClientPro(id, adherance, nom, prenom, tel, mail, l1, l2, cp, ville, province, pays, entreprise, remise)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Modifications effectuées");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
