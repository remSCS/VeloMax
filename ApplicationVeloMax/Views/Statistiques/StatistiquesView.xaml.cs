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

namespace ApplicationVeloMax.Views.Statistiques
{
    /// <summary>
    /// Logique d'interaction pour StatistiquesView.xaml
    /// </summary>
    public partial class StatistiquesView : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Modele> _ensembleModeles;
        public ObservableCollection<Modele> EnsembleModeles
        {
            get { return _ensembleModeles; }
            set
            {
                _ensembleModeles = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnsembleModeles"));
            }
        }

        private ObservableCollection<PieceDetachee> _ensemblePieces;
        public ObservableCollection<PieceDetachee> EnsemblePieces
        {
            get { return _ensemblePieces; }
            set
            {
                _ensemblePieces = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EnsemblePieces"));
            }
        }
        public static decimal MontantMoyen()
        {
            var a = Commande.Ensemble.Except(Commande.EnsembleAnnul);
            decimal panierMoyen = 0M;
            if (a.Count() != 0)
            {

                foreach (Commande com in a)
                {
                    panierMoyen += com.MontantCommandeAvecTVAAvecRemise;
                }
                panierMoyen = panierMoyen / a.Count();

            }
            return panierMoyen;
        }

        public static decimal NbMoyen()
        {
            decimal nbMoyen = 0M;
            var a = Commande.Ensemble.Except(Commande.EnsembleAnnul);
            if (a.Count() != 0)
            {


                foreach (Commande com in a)
                {
                    nbMoyen += com.NbArticles;
                }
                nbMoyen= nbMoyen / a.Count();
            }
            return nbMoyen;

        }

        public static decimal ModelesMoyen()
        {
            decimal nbModelesMoyen = 0M;
            var a = Commande.Ensemble.Except(Commande.EnsembleAnnul);
            if (a.Count() != 0)
            {
                foreach (Commande com in a)
                {
                    nbModelesMoyen +=com.ModelesCommande.Count();
                }
                nbModelesMoyen = nbModelesMoyen / a.Count();
            }
            return nbModelesMoyen;
        }

        public static decimal PiecesMoyen()
        {
            decimal nbPiecesMoyen = 0M;
            var a = Commande.Ensemble.Except(Commande.EnsembleAnnul);
            if (a.Count() != 0)
            {
                foreach (Commande com in a)
                {
                    nbPiecesMoyen += com.PiecesCommande.Count();
                }
                nbPiecesMoyen = nbPiecesMoyen / a.Count();
            }
            return nbPiecesMoyen;
        }

        public StatistiquesView()
        {
            InitializeComponent();
            MontantMoyen_Label.Content = Decimal.Round(MontantMoyen(), 2) + " €";
            NbMoyen_Label.Content = Decimal.Round(NbMoyen(), 2) + " €";
            NbModeles_Label.Content= Decimal.Round(ModelesMoyen(), 2);
            NbPièces_Label.Content= Decimal.Round(PiecesMoyen(), 2);
            EnsembleModeles = new ObservableCollection<Modele>(Modele.Ensemble);
            EnsemblePieces = new ObservableCollection<PieceDetachee>(PieceDetachee.Ensemble);
            
            ClassementPieces_DataGrid.Visibility = Visibility.Collapsed;
            ClassementModeles_DataGrid.Visibility = Visibility.Visible;
            SortDataGrid(ClassementModeles_DataGrid, 2);
        }

        private void ChoixStats_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClassementModeles_DataGrid != null && ClassementPieces_DataGrid!=null)
            {
                if (ChoixStats_ComboBox.Text != "Modèles")
                {
                    SortDataGrid(ClassementModeles_DataGrid, 2);
                    ClassementPieces_DataGrid.Visibility = Visibility.Collapsed;
                    ClassementModeles_DataGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    SortDataGrid(ClassementPieces_DataGrid, 2);
                    ClassementModeles_DataGrid.Visibility = Visibility.Collapsed;
                    ClassementPieces_DataGrid.Visibility = Visibility.Visible;
                }
            }
        }

        public static void SortDataGrid(DataGrid datagrid, int colidx, ListSortDirection direction = ListSortDirection.Descending)
        {
            var colonne = datagrid.Columns[colidx];
            datagrid.Items.SortDescriptions.Clear();
            datagrid.Items.SortDescriptions.Add(new SortDescription(colonne.SortMemberPath, direction));
            foreach (var col in datagrid.Columns)
            {
                col.SortDirection = null;
            }
            colonne.SortDirection = direction;
            datagrid.Items.Refresh();
        }
    }
}
