using ApplicationVeloMax.Models;
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
    /// Logique d'interaction pour AddPieceFournisseurView.xaml
    /// </summary>
    public partial class AddPieceFournisseurView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Fournisseur _fournisseur;

        public Fournisseur FournisseurAdd
        {
            get { return _fournisseur; }
            set
            {
                _fournisseur = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FournisseurAdd"));
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


        public ObservableCollection<PieceDetachee> Pieces
        {
            get { return new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble); }

        }



        public AddPieceFournisseurView(Fournisseur fourni)
        {
            InitializeComponent();
            FournisseurAdd = fourni;

        }
    }
}
