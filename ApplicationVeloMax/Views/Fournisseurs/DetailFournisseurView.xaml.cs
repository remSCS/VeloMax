using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using ApplicationVeloMax.Views.Pieces;
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

namespace ApplicationVeloMax.Views.Fournisseurs
{
    /// <summary>
    /// Logique d'interaction pour DetailFournisseurView.xaml
    /// </summary>
    public partial class DetailFournisseurView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Fournisseur _fournisseur;
        public Fournisseur Fournisseur
        {
            get { return _fournisseur; }
            set
            {
                _fournisseur = value;
                Pieces = new ObservableCollection<FournisseurPiece>(FournisseurPiece.Ensemble.FindAll(fp => fp.FournisseurPieceDetachee.Siret == Fournisseur.Siret));
                PropertyChanged(this, new PropertyChangedEventArgs("Fournisseur"));
            }
        }

        private ObservableCollection<FournisseurPiece> _pieces;
        public ObservableCollection<FournisseurPiece> Pieces
        {
            get { return _pieces; }
            set
            {
                _pieces = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Pieces"));
            }
        }

        private FournisseurPiece _selectedPieceFournisseur;
        public FournisseurPiece SelectedPieceFournisseur
        {
            get { return _selectedPieceFournisseur; }
            set
            {
                _selectedPieceFournisseur = value;
                if(SelectedPieceFournisseur != null) SelectedPiece = SelectedPieceFournisseur.PieceDetacheeFournisseur;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPieceFournisseur"));
            }
        }

        private PieceDetachee _selectedPiece;
        public PieceDetachee SelectedPiece
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPiece"));
            }
        }

        public DetailFournisseurView(Fournisseur _input)
        {
            InitializeComponent();
            Fournisseur = _input;
        }

        private void DelPieceButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece != null)
            {
                var toRemove = FournisseurPiece.Ensemble.Find(fp => fp.FournisseurPieceDetachee.Siret == Fournisseur.Siret && fp.PieceDetacheeFournisseur.Id == SelectedPiece.Id);
                if (DataAccess.RemoveFromFournisseurPiece(toRemove))
                {
                    Pieces = new ObservableCollection<FournisseurPiece>(FournisseurPiece.Ensemble.FindAll(fp => fp.FournisseurPieceDetachee.Siret == Fournisseur.Siret));
                    MessageBox.Show("Pièce supprimée du catalogue du fournisseur", "Suppression réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else MessageBox.Show("Erreur BD", "Suppression impossible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Veuillez sélectionner une pièce à supprimer du catalogue du fournisseur", "Suppression impossible", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void AddPieceButton_Click(object sender, RoutedEventArgs e)
        {
            new AddPieceFournisseurView(Fournisseur).ShowDialog();
            this.Close();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailPieceView(SelectedPiece).ShowDialog();
    }
}
