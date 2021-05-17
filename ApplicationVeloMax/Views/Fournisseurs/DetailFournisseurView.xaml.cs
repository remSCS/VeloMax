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


        public DetailFournisseurView(Fournisseur fourni)
        {
            InitializeComponent();
            Fournisseur = fourni;
        }
    }
}
