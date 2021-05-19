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

namespace ApplicationVeloMax.Views.Commandes
{
    /// <summary>
    /// Interaction logic for SelectionFournisseurDelaiView.xaml
    /// </summary>
    public partial class SelectionFournisseurDelaiView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<FournisseurPiece> _fournisseursPiece;
        public ObservableCollection<FournisseurPiece> FournisseursPiece
        {
            get { return _fournisseursPiece; }
            set
            {
                _fournisseursPiece = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FournisseursPiece"));
            }
        }

        private FournisseurPiece _selectedFournisseurPiece;
        public FournisseurPiece SelectedFournisseurPiece
        {
            get { return _selectedFournisseurPiece; }
            set
            {
                _selectedFournisseurPiece = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedFournisseurPiece"));
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

        private int _quantiteToAdd;
        public int QuantiteToAdd
        {
            get { return _quantiteToAdd; }
            set
            {
                _quantiteToAdd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QuantiteToAdd"));
            }
        }

        private int quantiteMinimale;
        private Commande commandeConcernee;

        public SelectionFournisseurDelaiView(PieceDetachee _input, int minToAdd, Commande com)
        {
            InitializeComponent();
            SelectedPiece = _input;
            FournisseursPiece = new ObservableCollection<FournisseurPiece>(FournisseurPiece.Ensemble.FindAll(fp => fp.PieceDetacheeFournisseur == SelectedPiece));
            QuantiteToAdd = minToAdd;
            quantiteMinimale = minToAdd;
            commandeConcernee = com;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFournisseurPiece == null) MessageBox.Show("Veuillez sélectionner un fournisseur.");
            else
            {
                if (QuantiteToAdd < quantiteMinimale) MessageBox.Show($"Veuillez sélectionner au minimum {quantiteMinimale} pièces à commander chez {SelectedFournisseurPiece.FournisseurPieceDetachee.Nom}.");
                else
                {
                    DateTime estimatedDate = commandeConcernee.DateE.AddDays(SelectedFournisseurPiece.Delai);
                    if (commandeConcernee.DateS > estimatedDate && commandeConcernee.DateS != estimatedDate) MessageBox.Show($"Cette commande n'influencera pas la date de livraison définie au {commandeConcernee.DateS.ToString("dd/MM/yyyy")}.");
                    else MessageBox.Show($"La date de livraison prévue au {commandeConcernee.DateS.ToString("dd/MM/yyyy")} ne pourra pas être maintenue. Elle sera déplacée au {estimatedDate.ToString("dd/MM/yyyy")}");
                    MessageBoxResult result = MessageBox.Show("Souhaitez-vous maintenir l'ajout de cette pièce ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No) this.Close();
                    else
                    {
                        commandeConcernee.DateS = commandeConcernee.DateE.AddDays(SelectedFournisseurPiece.Delai);
                        DataAccess.EditOrderDueDate(commandeConcernee);
                        DataAccess.ModifyStockPiece(SelectedPiece, QuantiteToAdd);
                        DataAccess.AddPieceCompositionCommande(commandeConcernee, SelectedPiece, quantiteMinimale);
                        this.Close();
                    }
                }
            }
        }
    }
}
