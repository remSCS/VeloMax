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

namespace ApplicationVeloMax.Views.Stock
{
    /// <summary>
    /// Logique d'interaction pour StockPieceFournisseurs.xaml
    /// </summary>
    public partial class StockPieceFournisseurs : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PieceDetachee _pieceADetailler;
        public PieceDetachee PieceADetailler
        {
            get { return _pieceADetailler; }
            set
            {
                _pieceADetailler = value;
                PropertyChanged(this,new PropertyChangedEventArgs("PieceADetailler"));
            }
        }

        private ObservableCollection<FournisseurPiece> _fournisseurs;
        public ObservableCollection<FournisseurPiece> Fournisseurs
        {
            get { return _fournisseurs; }
            set
            {
                _fournisseurs=value;
                PropertyChanged(this, new PropertyChangedEventArgs("Fournisseurs"));
            }
        }
        public StockPieceFournisseurs(PieceDetachee pieceADetailler)
        {
            InitializeComponent();
            PieceADetailler = pieceADetailler;
            Fournisseurs = new ObservableCollection<FournisseurPiece>(FournisseurPiece.Ensemble.FindAll(fp => fp.PieceDetacheeFournisseur.Id == pieceADetailler.Id));
        }
    }
}
