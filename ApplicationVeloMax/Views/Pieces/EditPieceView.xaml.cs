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

namespace ApplicationVeloMax.Views.Pieces
{
    /// <summary>
    /// Interaction logic for EditPieceView.xaml
    /// </summary>
    public partial class EditPieceView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Grandeur> _grandeurs;
        public ObservableCollection<Grandeur> Grandeurs
        {
            get { return _grandeurs; }
            set
            {
                _grandeurs = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Grandeurs"));
            }
        }

        private ObservableCollection<LigneProduit> _lignesProduits;
        public ObservableCollection<LigneProduit> LignesProduits
        {
            get { return _lignesProduits; }
            set
            {
                _lignesProduits = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LignesProduits"));
            }
        }

        private PieceDetachee _selectedPiece;
        public PieceDetachee SelectedPiece
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                dateETb.DisplayDateEnd = DateTime.Today;
                dateSTb.DisplayDateStart = SelectedPiece.DateE;
                dateSTb.DisplayDateEnd = DateTime.Today;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPiece"));
            }
        }

        public EditPieceView(PieceDetachee _input)
        {
            InitializeComponent();
            SelectedPiece = _input;
            Grandeurs = new ObservableCollection<Grandeur>(Grandeur.Ensemble);
            LignesProduits = new ObservableCollection<LigneProduit>(LigneProduit.Ensemble);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            int id = SelectedPiece.Id;
            string reference = SelectedPiece.Reference;
            string nom = SelectedPiece.Nom;
            string description = SelectedPiece.Description;
            DateTime de = SelectedPiece.DateE;
            DateTime ds = SelectedPiece.DateS;

            try
            {
                nom = nomTb.Text;
                reference = refTb.Text;
                description = descTb.Text;
                de = DateTime.Parse(dateETb.Text);
                ds = DateTime.Parse(dateSTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }
            if (!DataAccess.FullyEditPiece(id, reference, nom, description, de, ds)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Modifications effectuées");
                this.Close();
            }
        }
    }
}