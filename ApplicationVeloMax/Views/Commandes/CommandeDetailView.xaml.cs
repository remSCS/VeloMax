using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using ApplicationVeloMax.Views.Clients;
using ApplicationVeloMax.Views.Modeles;
using ApplicationVeloMax.Views.Pieces;
using System;
using System.Collections.Generic;
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
    public partial class CommandeDetailView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Commande _selectedCommande = new Commande();
        public Commande SelectedCommande
        {
            get { return _selectedCommande; }
            set
            {
                _selectedCommande = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCommande"));
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

        public CommandeDetailView(Commande _inputCommande)
        {
            InitializeComponent();
            SelectedCommande = _inputCommande;
            if (SelectedCommande.Statut != "En cours de préparation")
            {
                addModeleButton.Visibility = Visibility.Hidden;
                removeModeleButton.Visibility = Visibility.Hidden;
                addPieceButton.Visibility = Visibility.Hidden;
                removePieceButton.Visibility = Visibility.Hidden;
            }
        }

        private void FactureButton_Click(object sender, RoutedEventArgs e) => new FactureCommande(SelectedCommande).ShowDialog();

        private void removePieceButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPiece == null) MessageBox.Show("Veuillez sélectionner une pièce à supprimer.");
            else
            {
                if (!DataAccess.RemovePieceCompositionCommande(SelectedCommande, SelectedPiece)) MessageBox.Show("Impossible de retirer la pièce de cette commande.");
                else
                {
                    MessageBox.Show("Pièce supprimée !");
                    this.Close();
                }
            }
        }

        private void removeModeleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModele == null) MessageBox.Show("Veuillez sélectionner un modèle à supprimer.");
            else
            {
                if (!DataAccess.RemoveModeleCompositionCommande(SelectedCommande, SelectedModele)) MessageBox.Show("Impossible de retirer le modèle de cette commande.");
                else
                {
                    MessageBox.Show("Modèle supprimé !");
                    this.Close();
                }
            }
        }

        private void addModeleButton_Click(object sender, RoutedEventArgs e) { new AddModeleToCommandeView(SelectedCommande).ShowDialog(); this.Close(); }

        private void addPieceButton_Click(object sender, RoutedEventArgs e) { new AddPieceToCommandeView(SelectedCommande).ShowDialog(); this.Close(); }

        private void piecesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new DetailPieceView(SelectedPiece).ShowDialog();

        private void modelesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) => new detailPieceView(SelectedModele).ShowDialog();

        private void detailClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientPart.EnsembleParticuliers.Contains(SelectedCommande.ClientCommande)) new DetailClientPart((ClientPart)SelectedCommande.ClientCommande).ShowDialog();
            else new DetailClientPro((ClientPro)SelectedCommande.ClientCommande).ShowDialog();
        }
    }
}
