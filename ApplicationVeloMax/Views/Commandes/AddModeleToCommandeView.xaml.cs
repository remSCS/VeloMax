using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using ApplicationVeloMax.Views.Modeles;
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
    /// Interaction logic for AddModeleToCommandeView.xaml
    /// </summary>
    public partial class AddModeleToCommandeView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Modele> _modeles;
        public ObservableCollection<Modele> Modeles
        {
            get { return _modeles; }
            set
            {
                _modeles = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Modeles"));
            }
        }

        private Modele _selectedModele;
        public Modele SelectedModele
        {
            get { return _selectedModele; }
            set
            {
                _selectedModele = value;
                QteToAdd = 0;
                if(qteTb != null) qteTb.Text = "0";
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedModele"));
            }
        }

        private int _qteToAdd = 0;
        public int QteToAdd
        {
            get { return _qteToAdd; }
            set
            {
                _qteToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedModele"));
            }
        }

        public Commande SelectedCommande { get; set; }

        public AddModeleToCommandeView(Commande _input)
        {
            InitializeComponent();
            SelectedCommande = _input;
            Modeles = new ObservableCollection<Modele>(Modele.Ensemble);
        }

        private void modeleDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailsModeleView(SelectedModele).ShowDialog();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null) MessageBox.Show("Veuillez sélectionner un modèle à ajouter !");
            else
            {
                if (QteToAdd == 0) MessageBox.Show("Veuillez indiquer une quantité à ajouter !");
                else
                {
                    //DataAccess.AddPieceCompositionCommande(SelectedCommande, SelectedModele, QteToAdd);
                    
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
