using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class CompoCommandePieces
    {
        static private List<CompoCommandePieces> ensemble = new List<CompoCommandePieces>();

        private Commande commandePiece;
        private PieceDetachee pieceCompoCommande;
        private int quantite;

        public CompoCommandePieces()
        {
            if (ensemble.Find(e => e.commandePiece.Id == this.CommandePiece.Id) == null) ensemble.Add(this);
        }

        public Commande CommandePiece
        {
            get { return commandePiece; }
            set { commandePiece = value; }
        }

        public PieceDetachee PieceCompoCommande
        {
            get { return pieceCompoCommande; }
            set { pieceCompoCommande = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        static public List<CompoCommandePieces> Ensemble
        {
            get { return ensemble; }
        }
    }
}
