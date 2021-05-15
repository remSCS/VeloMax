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

namespace ApplicationVeloMax.Views.Fidelios
{
    /// <summary>
    /// Interaction logic for EditFidelioView.xaml
    /// </summary>
    public partial class EditFidelioView : Window, INotifyPropertyChanged
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


        public EditFidelioView(Fidelio _input)
        {
            InitializeComponent();
            SelectedFidelio = _input;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            int id = SelectedFidelio.Id;
            string nom = SelectedFidelio.Nom;
            string description = SelectedFidelio.Description;
            decimal cout = SelectedFidelio.Cout;
            decimal rabais = SelectedFidelio.Rabais;
            int duree = SelectedFidelio.DureeJours;
            try
            {
                id = Convert.ToInt32(idTb.Text);
                nom = nomTb.Text;
                description = descTb.Text;
                cout = Convert.ToDecimal(coutTb.Text);
                rabais = Convert.ToDecimal(rabaisTb.Text);
                duree = Convert.ToInt32(dureeTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }
            if (!DataAccess.FullyEditFidelio(id, nom, description, cout, rabais, duree)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Modifications effectuées");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
