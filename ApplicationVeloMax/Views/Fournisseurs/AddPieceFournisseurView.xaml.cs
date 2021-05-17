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

        private Fournisseur _fournisseurAdd;
        public Fournisseur FournisseurAdd
        {
            get { return _fournisseurAdd; }
            set
            {
                _fournisseurAdd = value;
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
            get
            {
                return new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble.Except(FournisseurPiece.PiecesFournies(FournisseurAdd)));
            }

        }

        public AddPieceFournisseurView(Fournisseur fourni)
        {
            InitializeComponent();
            FournisseurAdd = fourni;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece != null && Decimal.TryParse(PrixBox.Text, out decimal prix) && Int32.TryParse(DelaiBox.Text, out int delaiJ))
            {

            }
            else MessageBox.Show("Vérifiez vos paramètres", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
