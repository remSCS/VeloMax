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

namespace ApplicationVeloMax.Views.Modeles
{
    /// <summary>
    /// Interaction logic for AddCompositionView.xaml
    /// </summary>
    public partial class AddCompositionView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<PieceDetachee> piecesToAdd = new List<PieceDetachee>();
        private Modele selectedModele;

        private ObservableCollection<PieceDetachee> _piecesDispo;
        public ObservableCollection<PieceDetachee> PiecesDispo
        {
            get { return _piecesDispo; }
            set
            {
                _piecesDispo = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PiecesDispo"));
            }
        }

        public AddCompositionView(Modele _inputModele, List<PieceDetachee> _inputPieces)
        {
            InitializeComponent();
            PiecesDispo = new ObservableCollection<PieceDetachee>(_inputPieces);
            selectedModele = _inputModele;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (piecesToAdd.Count() == 0) MessageBox.Show("Veuillez sélectionner 1 pièce au minimum");
            else
            {
                bool success = true;
                foreach(var p in piecesToAdd) if (!DataAccess.AddCompositionPieceModele(selectedModele, p)) success = false;
                if (success)
                {
                    MessageBox.Show("Pièce(s) ajoutée(s) à la composition de ce modèle !");
                    this.Close();
                }
                else MessageBox.Show("Impossible de faire cet ajout");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();

        private void dataGridPieces_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            piecesToAdd = new List<PieceDetachee>();
            foreach (var p in dataGridPieces.SelectedItems) piecesToAdd.Add((PieceDetachee)p);
        }
    }
}
