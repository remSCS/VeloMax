using ApplicationVeloMax.Models;
using ApplicationVeloMax.Views.Fournisseurs;
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

namespace ApplicationVeloMax.Views.Pieces
{
    /// <summary>
    /// Interaction logic for DetailPieceView.xaml
    /// </summary>
    public partial class DetailPieceView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedModele"));
            }
        }

        private ObservableCollection<FournisseurPiece> _fournisseurs;
        public ObservableCollection<FournisseurPiece> Fournisseurs
        {
            get { return _fournisseurs; }
            set
            {
                _fournisseurs = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Fournisseurs"));
            }
        }

        private FournisseurPiece _selectedFournisseur;
        public FournisseurPiece SelectedFournisseur
        {
            get { return _selectedFournisseur; }
            set
            {
                _selectedFournisseur = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedFournisseur"));
            }
        }

        public DetailPieceView(PieceDetachee _input)
        {
            InitializeComponent();
            SelectedPiece = _input;
            Modeles = new ObservableCollection<Modele>(Modele.Ensemble.FindAll(m => m.PiecesComposition.Contains(SelectedPiece)));
            Fournisseurs = new ObservableCollection<FournisseurPiece>(FournisseurPiece.Ensemble.FindAll(fp => fp.PieceDetacheeFournisseur == SelectedPiece));
        }

        private void modelesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new detailPieceView(SelectedModele).ShowDialog();

        private void fournisseursDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailFournisseurView(SelectedFournisseur.FournisseurPieceDetachee).ShowDialog();
    }
}
