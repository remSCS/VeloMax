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

namespace ApplicationVeloMax.Views.Modeles
{
    /// <summary>
    /// Interaction logic for DetailsModeleView.xaml
    /// </summary>
    public partial class detailPieceView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Modele _selectedModele;
        public Modele SelectedModele
        {
            get { return _selectedModele; }
            set
            {
                _selectedModele = value;
                PiecesModele = new ObservableCollection<PieceDetachee>(SelectedModele.PiecesComposition);
                PiecesNonComprises = PieceDetachee.Ensemble.Except(PiecesModele).ToList<PieceDetachee>();
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedModele"));
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

        private ObservableCollection<PieceDetachee> _piecesModele;
        public ObservableCollection<PieceDetachee> PiecesModele
        {
            get { return _piecesModele; }
            set
            {
                _piecesModele = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PiecesModele"));
            }
        }

        private List<PieceDetachee> _piecesNonComprises = new List<PieceDetachee>();
        public List<PieceDetachee> PiecesNonComprises
        {
            get { return _piecesNonComprises; }
            set
            {
                _piecesNonComprises = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PiecesNonComprises"));
            }
        }

        public detailPieceView(Modele _input)
        {
            InitializeComponent();
            SelectedModele = _input;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailPieceView(SelectedPiece).ShowDialog();

        private void addPieceButton_Click(object sender, RoutedEventArgs e)
        {
            new AddCompositionView(SelectedModele, PiecesNonComprises).ShowDialog();
            this.Close();
        }

        private void deletePieceButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece == null) MessageBox.Show("Veuillez sélectionner une pièce à retirer de la composition de ce modèle");
            else
            {
                if (!DataAccess.RemoveFromComposition(SelectedModele, SelectedPiece)) MessageBox.Show("Erreur de suppression");
                else
                {
                    MessageBox.Show("Pièce retirée de la composition");
                    this.Close();
                }
            }
        }
    }
}
