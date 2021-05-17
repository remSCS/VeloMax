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
        private ObservableCollection<PieceDetachee> _pieces;

        public ObservableCollection<PieceDetachee> Pieces
        {
            get { return _pieces; }
            set
            {
                _pieces = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Pieces"));
            }
        }




        private FournisseurPiece _toAdd;

        public FournisseurPiece ToAdd
        {
            get { return _toAdd; }
            set
            {
                _toAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ToAdd"));
            }
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToAdd.Delai = Convert.ToInt32(DelaiBox.Text);
                ToAdd.Prix = Convert.ToDecimal(PrixBox.Text);
            }
            catch
            {
                MessageBox.Show("Vérifiez vos paramètres", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ToAdd != null)
            {
                if (!DataAccess.AddFournisseurPiece(ToAdd))
                {
                    MessageBox.Show("Ajout impossible", "Erreur BD", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Pièce ajouté au catalogue du fournisseur");
                    this.Close();
                }
            }
            else MessageBox.Show("Test");

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            FournisseurPiece.Ensemble.Remove(ToAdd);
            this.Close();
        }
        public AddPieceFournisseurView(Fournisseur fourni)
        {
            InitializeComponent();
            FournisseurAdd = fourni;
            FournisseurPiece temp = new FournisseurPiece(-1, FournisseurAdd.Siret) { Delai = 0, NumCatalogue = "", Prix = 0M };
            ToAdd = temp;
            Pieces = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble.Except(FournisseurPiece.PiecesFournies(FournisseurAdd)));

        }
    }
}
