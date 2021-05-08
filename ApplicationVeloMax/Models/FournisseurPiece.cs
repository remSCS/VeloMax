using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class FournisseurPiece
    {
        private PieceDetachee pieceDetacheeFournisseur;
        private Fournisseur fournisseurPieceDetachee;
        private decimal prix;
        private int delai;
        private string numCatalogue;

        public FournisseurPiece()
        {

        }

        public PieceDetachee PieceDetacheeFournisseur
        {
            get { return pieceDetacheeFournisseur; }
            set { pieceDetacheeFournisseur = value; }
        }
 
        public Fournisseur FournisseurPieceDetachee
        {
            get { return fournisseurPieceDetachee; }
            set { fournisseurPieceDetachee = value; }
        }

        public decimal Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public int Delai
        {
            get { return delai; }
            set { delai = value; }
        }
  
        public string NumCatalogue
        {
            get { return numCatalogue; }
            set { numCatalogue = value; }
        }
    }
}
