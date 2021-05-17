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

        public FournisseurPiece(int idPiece, int idFournisseur)
        {
            PieceDetachee p = PieceDetachee.Ensemble.Find(e => e.Id == idPiece);
            if (p != null) this.PieceDetacheeFournisseur = p;
            Fournisseur f = Fournisseur.Ensemble.Find(e => e.Siret == idFournisseur);
            if (f != null) this.FournisseurPieceDetachee = f;
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

        static public List<PieceDetachee> PiecesFournies(Fournisseur fourni)
        {
            var a=Ensemble.FindAll(fp => fp.FournisseurPieceDetachee.Siret == fourni.Siret);
            var b = new List<PieceDetachee>();
            foreach(FournisseurPiece fp in a)
            {
                b.Add(fp.PieceDetacheeFournisseur);
            }
            return b;
        }
    }
}
