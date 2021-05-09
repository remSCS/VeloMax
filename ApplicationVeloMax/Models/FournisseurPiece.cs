using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class FournisseurPiece
    {
        static private List<FournisseurPiece> ensemble = new List<FournisseurPiece>();

        private PieceDetachee pieceDetacheeFournisseur;
        private Fournisseur fournisseurPieceDetachee;
        private decimal prix;
        private int delai;
        private string numCatalogue;

        public FournisseurPiece()
        {
            if (ensemble.Find(e => e.FournisseurPieceDetachee.Siret == this.FournisseurPieceDetachee.Siret && e.PieceDetacheeFournisseur.Id == this.PieceDetacheeFournisseur.Id) == null) ensemble.Add(this);
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

        static public List<FournisseurPiece> Ensemble
        {
            get { return ensemble; }
        }
    }
}
