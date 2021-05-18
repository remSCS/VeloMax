using ApplicationVeloMax.Models;
using ApplicationVeloMax.Views.Modeles;
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

namespace ApplicationVeloMax.Views.Commandes
{
    /// <summary>
    /// Interaction logic for AddPieceToCommandeView.xaml
    /// </summary>
    public partial class AddPieceToCommandeView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private PieceDetachee _selectedPiece;
        public PieceDetachee SelectedPiece
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                QteToAdd = 0;
                if (qteTb != null) qteTb.Text = "0";
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPiece"));
            }
        }

        private int _qteToAdd = 0;
        public int QteToAdd
        {
            get { return _qteToAdd; }
            set
            {
                _qteToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedModele"));
            }
        }

        public Commande SelectedCommande { get; set; }

        public AddPieceToCommandeView(Commande _input)
        {
            InitializeComponent();
            SelectedCommande = _input;
            Pieces = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
        }

        private void pieceDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailPieceView(SelectedPiece).ShowDialog();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece == null) MessageBox.Show("Veuillez sélectionner une pièce à ajouter !");
            else
            {
                if (QteToAdd == 0) MessageBox.Show("Veuillez indiquer une quantité à ajouter !");
                else
                {
                    //DataAccess.AddPieceCompositionCommande(SelectedCommande, SelectedModele, QteToAdd);
                    if (SelectedPiece.Quantite - QteToAdd < 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Il ne reste pas suffisamment de pièces en stock.\nVoulez-vous passer commande au près du fournisseur ?", "Stock insufisant", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            MessageBox.Show("je gère");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pièce ajouté à la commande !");
                        this.Close();
                    }
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
