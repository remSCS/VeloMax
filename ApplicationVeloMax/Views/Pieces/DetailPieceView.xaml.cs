using ApplicationVeloMax.Models;
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
                Modeles = new ObservableCollection<Modele>(Modele.Ensemble.FindAll(m => m.PiecesComposition.Contains(SelectedPiece)));
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

        public DetailPieceView(PieceDetachee _input)
        {
            InitializeComponent();
            SelectedPiece = _input;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailsModeleView(SelectedModele).ShowDialog();
    }
}
