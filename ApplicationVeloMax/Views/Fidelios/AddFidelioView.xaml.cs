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
    /// Interaction logic for AddFidelioView.xaml
    /// </summary>
    public partial class AddFidelioView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Fidelio _fidelioToAdd;
        public Fidelio FidelioToAdd
        {
            get { return _fidelioToAdd; }
            set
            {
                _fidelioToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FidelioToAdd"));
            }
        }

        public AddFidelioView()
        {
            InitializeComponent();
            Fidelio toAdd = new Fidelio()
            {
                Id = DataAccess.GetHighestId("fidelio") + 1,
                Nom = "",
                Description = "",
                Cout = 0M,
                DureeJours = 0,
                Rabais = 0M
            };
            FidelioToAdd = toAdd;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int id = FidelioToAdd.Id;
            string nom = FidelioToAdd.Nom;
            string description = FidelioToAdd.Description;
            decimal cout = FidelioToAdd.Cout;
            decimal rabais = FidelioToAdd.Rabais;
            int duree = FidelioToAdd.DureeJours;
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
            if (!DataAccess.AddFidelio(FidelioToAdd)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Programme Fidelio ajouté !");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Fidelio.Ensemble.Remove(FidelioToAdd);
            this.Close();
        }
    }
}
