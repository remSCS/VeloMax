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

namespace ApplicationVeloMax.Views.Pieces
{
    /// <summary>
    /// Interaction logic for AddPieceView.xaml
    /// </summary>
    public partial class AddPieceView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PieceDetachee _piece;
        public PieceDetachee Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                if (dateSTb.SelectedDate < dateETb.SelectedDate) dateSTb.SelectedDate = dateETb.SelectedDate;
                dateETb.DisplayDateEnd = DateTime.Today;
                dateSTb.DisplayDateStart = Piece.DateE;
                dateSTb.DisplayDateEnd = DateTime.Today;
                PropertyChanged(this, new PropertyChangedEventArgs("Piece"));
            }
        }

        public AddPieceView()
        {
            InitializeComponent();
            PieceDetachee toAdd = new PieceDetachee()
            {
                Id = DataAccess.GetHighestId("piecedetachee") + 1,
                Nom = "",
                Reference = "",
                Description = "",
                Quantite = 0,
                DateE = DateTime.Today,
                DateS = DateTime.Today
            };
            Piece = toAdd;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            PieceDetachee.Ensemble.Remove(PieceDetachee.Ensemble.Find(p => p.Id == Piece.Id));
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Piece.Id;
            string reference = Piece.Reference;
            string nom = Piece.Nom;
            string description = Piece.Description;
            DateTime de = Piece.DateE;
            DateTime ds = Piece.DateS;

            try
            {
                Piece.Nom = nomTb.Text;
                Piece.Reference = refTb.Text;
                Piece.Description = descTb.Text;
                Piece.DateE = DateTime.Parse(dateETb.Text);
                Piece.DateS = DateTime.Parse(dateSTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }
            if (!DataAccess.AddPiece(Piece)) MessageBox.Show("Modification impossible.");
            else
            {
                MessageBox.Show("Pièce ajoutée !");
                this.Close();
            }
        }

        private void dateETb_SelectedDateChanged(object sender, SelectionChangedEventArgs e) => Piece = Piece;
    }
}
